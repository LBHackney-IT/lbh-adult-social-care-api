using Amazon.XRay.Recorder.Handlers.AwsSdk;
using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1;
using LBH.AdultSocialCare.Api.V1.Exceptions.Filters;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using HttpServices.Services.Concrete;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace LBH.AdultSocialCare.Api
{

    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            AWSSDKHandler.RegisterXRayForAllServices();
        }

        public IConfiguration Configuration { get; }

        private static List<ApiVersionDescription> _apiVersions { get; set; }
        private const string ApiName = "Adult Social Care API";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(config =>
                {
                    config.ReturnHttpNotAcceptable = true;
                    config.Filters.Add(typeof(LBHExceptionFilter));

                    var policy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
                    config.Filters.Add(new AuthorizeFilter(policy));
                })
                .AddNewtonsoftJson(x
                    => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .ConfigureApiBehaviorOptions(opt => opt.InvalidModelStateResponseFactory = (context
                    => throw new InvalidModelStateException(context.ModelState.AllModelStateErrors(),
                        "There are some validation errors. Please correct and try again")))
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);

                // assume that the caller wants the default version if they don't specify
                o.AssumeDefaultVersionWhenUnspecified = true;

                // read the version number from the url segment header)
                o.ApiVersionReader = new UrlSegmentApiVersionReader();
            });

            services.AddSingleton<IApiVersionDescriptionProvider, DefaultApiVersionDescriptionProvider>();

            ConfigureSwagger(services);

            // Add auto mapper
            services.AddAutoMapper(typeof(Startup));

            services.ConfigureLogging(Configuration);

            services.ConfigureDbContext(Configuration);
            services.AddAuthentication();
            services.ConfigureIdentityService();
            services.ConfigureJWT(Configuration);

            services.AddScoped<IAuthenticationManager, AuthenticationManager>();

            services.AddHttpContextAccessor();

            services.AddScoped<ITransactionManager, TransactionManager>();
            services.RegisterGateways();
            services.RegisterUseCases();

            // Configure transaction API client
            services.AddScoped<IRestClient, JsonRestClient>();
            services.AddScoped<ITransactionsService, TransactionsService>();
            services.ConfigureTransactionsApiClient(Configuration);
        }

        private static void ConfigureSwagger(IServiceCollection services) => services.AddSwaggerGen(c =>
        {
            c.AddSecurityDefinition("Token", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Your Hackney API Key",
                Name = "X-Api-Key",
                Type = SecuritySchemeType.ApiKey
            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme, Id = "Token"
                        }
                    },
                    new List<string>()
                }
            });

            // Looks at the APIVersionAttribute [ApiVersion("x")] on controllers and decides whether or not
            // to include it in that version of the swagger document
            // Controllers must have this [ApiVersion("x")] to be included in swagger documentation!!
            c.DocInclusionPredicate((docName, apiDesc) =>
            {
                apiDesc.TryGetMethodInfo(out MethodInfo methodInfo);

                List<ApiVersion> versions = methodInfo?.DeclaringType?.GetCustomAttributes()
                    .OfType<ApiVersionAttribute>()
                    .SelectMany(attr => attr.Versions)
                    .ToList();

                return versions?.Any(v => $"{v.GetFormattedApiVersion()}" == docName) ?? false;
            });

            // Get every ApiVersion attribute specified and create swagger docs for them
            foreach (string version in _apiVersions.Select(apiVersion => $"v{apiVersion.ApiVersion}"))
            {
                c.SwaggerDoc(version, new OpenApiInfo
                {
                    Title = $"{ApiName}-api {version}",
                    Version = version,
                    Description = $"{ApiName} version {version}. Please check older versions for depreciated endpoints."
                });
            }

            c.CustomSchemaIds(x => x.FullName);

            // Set the comments path for the Swagger JSON and UI.
            string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

            if (File.Exists(xmlPath))
                c.IncludeXmlComments(xmlPath);
        });

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var appScope = app.ApplicationServices.CreateScope())
            {
                var databaseContext = appScope.ServiceProvider.GetRequiredService<DatabaseContext>();

                // Uncomment next line to delete and recreate DB
                //databaseContext.Database.EnsureDeleted();

                if (!databaseContext.Database.ProviderName.Equals("Microsoft.EntityFrameworkCore.InMemory") &&
                    !databaseContext.Database.ProviderName.Equals("Microsoft.EntityFrameworkCore.Sqlite")) // disable migrations for test in-memory databases
                {
                    // Run pending database migrations
                    if (databaseContext.Database.GetPendingMigrations().Any())
                    {
                        // Perform migrations
                        databaseContext.Database.Migrate();
                    }
                }
            }

            app.UseCors(options => options.WithOrigins("http://localhost:3000", "https://d1ewp85mz183f9.cloudfront.net",
                    "https://social-care-care-packages-staging.hackney.gov.uk", "https://d2s6rc0vyqw6a1.cloudfront.net",
                    "https://social-care-care-packages.hackney.gov.uk")
                .AllowAnyMethod()
                .AllowAnyHeader());
            app.UseCorrelation();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            // Configure extension methods to use auto mapper
            var mapper = app.ApplicationServices.GetService<IMapper>();
            ApiToDomainFactory.Configure(mapper);
            DomainToEntityFactory.Configure(mapper);
            EntityToDomainFactory.Configure(mapper);
            ResponseFactory.Configure(mapper);

            // TODO
            // If you DON'T use the renaming script, PLEASE replace with your own API name manually
            app.UseXRay("base-api");

            //Get All ApiVersions,
            IApiVersionDescriptionProvider api = app.ApplicationServices.GetService<IApiVersionDescriptionProvider>();
            _apiVersions = api.ApiVersionDescriptions.ToList();

            // Swagger ui to view the swagger.json file
            app.UseSwaggerUI(c =>
            {
                foreach (ApiVersionDescription apiVersionDescription in _apiVersions)
                {
                    // Create a swagger endpoint for each swagger version
                    c.SwaggerEndpoint($"{apiVersionDescription.GetFormattedApiVersion()}/swagger.json",
                        $"{ApiName}-api {apiVersionDescription.GetFormattedApiVersion()}");
                }
            });
            app.UseSwagger();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                // SwaggerGen won't find controllers that are routed via this technique.
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }

    }

}
