using Amazon.XRay.Recorder.Handlers.AwsSdk;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Controllers;
using LBH.AdultSocialCare.Api.V1.Exceptions.Filters;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageOpportunityGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.UseCase;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using LBH.AdultSocialCare.Api.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using LBH.AdultSocialCare.Api.V1;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

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
                })
                .AddNewtonsoftJson(x
                    => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
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

            services.AddSwaggerGen(c =>
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
                        Description =
                            $"{ApiName} version {version}. Please check older versions for depreciated endpoints."
                    });
                }

                c.CustomSchemaIds(x => x.FullName);

                // Set the comments path for the Swagger JSON and UI.
                string xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                string xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                if (File.Exists(xmlPath))
                    c.IncludeXmlComments(xmlPath);
            });

            // Add auto mapper
            services.AddAutoMapper(typeof(Startup));

            ConfigureLogging(services, Configuration);

            ConfigureDbContext(services);

            RegisterGateways(services);
            RegisterUseCases(services);
        }

        private void ConfigureDbContext(IServiceCollection services)
        {
            string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                                      Configuration.GetConnectionString("DatabaseConnectionString");

            string assemblyName = Assembly.GetCallingAssembly().GetName().Name;

            services.AddDbContext<DatabaseContext>(opt
                => opt.UseSqlServer(connectionString, b => b.MigrationsAssembly(assemblyName)));
        }

        private static void ConfigureLogging(IServiceCollection services, IConfiguration configuration)
        {
            // We rebuild the logging stack so as to ensure the console logger is not used in production.
            // See here: https://weblog.west-wind.com/posts/2018/Dec/31/Dont-let-ASPNET-Core-Default-Console-Logging-Slow-your-App-down
            services.AddLogging(config =>
            {
                // Clear out default configuration
                config.ClearProviders();

                config.AddConfiguration(configuration.GetSection("Logging"));
                config.AddDebug();
                config.AddEventSourceLogger();

                if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == Environments.Development)
                {
                    config.AddConsole();
                }
            });
        }

        private static void RegisterGateways(IServiceCollection services)
        {
            services.AddScoped<IExampleGateway, ExampleGateway>();
            services.AddScoped<IPackageGateway, PackageGateway>();
            services.AddScoped<IHomeCareServiceTypeGateway, HomeCareServiceTypeGateway>();
            services.AddScoped<IRolesGateway, RoleGateway>();
            services.AddScoped<ITimeSlotTypesGateway, TimeSlotTypesGateway>();
            services.AddScoped<ITimeSlotShiftsGateway, TimeSlotShiftsGateway>();
            services.AddScoped<IHomeCarePackageGateway, HomeCarePackageGateway>();
            services.AddScoped<IDayCarePackageGateway, DayCarePackageGateway>();
            services.AddScoped<IDayCarePackageOpportunityGateway, DayCarePackageOpportunityGateway>();
            services.AddScoped<IClientsGateway, ClientsGateway>();
            services.AddScoped<IHomeCarePackageSlotsGateway, HomeCarePackageSlotsGateway>();
            services.AddScoped<IUsersGateway, UsersGateway>();
            services.AddScoped<IStatusGateway, StatusGateway>();
            services.AddScoped<IResidentialCarePackageGateway, ResidentialCarePackageGateway>();
            services.AddScoped<INursingCarePackageGateway, NursingCarePackageGateway>();
        }

        private static void RegisterUseCases(IServiceCollection services)
        {
            services.AddScoped<IGetAllUseCase, GetAllUseCase>();
            services.AddScoped<IGetByIdUseCase, GetByIdUseCase>();

            #region Package

            services.AddScoped<IUpsertPackageUseCase, UpsertPackageUseCase>();
            services.AddScoped<IGetPackageUseCase, GetPackageUseCase>();
            services.AddScoped<IGetAllPackageUseCase, GetAllPackageUseCase>();
            services.AddScoped<IDeletePackageUseCase, DeletePackageUseCase>();

            #endregion Package

            #region Service

            services.AddScoped<IUpsertServiceUseCase, UpsertServiceUseCase>();
            services.AddScoped<IGetServiceUseCase, GetServiceUseCase>();
            services.AddScoped<IGetAllHomeCareServiceTypesUseCase, GetAllHomeCareServiceTypesUseCase>();
            services.AddScoped<IDeleteServiceUseCase, DeleteServiceUseCase>();

            #endregion Service

            #region Role

            services.AddScoped<IUpsertRoleUseCase, UpsertRoleUseCase>();
            services.AddScoped<IGetRoleUseCase, GetRoleUseCase>();
            services.AddScoped<IGetAllRoleUseCase, GetAllRoleUseCase>();
            services.AddScoped<IDeleteRoleUseCase, DeleteRoleUseCase>();

            #endregion Role

            #region TimeSlotTypes

            services.AddScoped<IUpsertTimeSlotTypesUseCase, UpsertTimeSlotTypesUseCase>();
            services.AddScoped<IGetTimeSlotTypesUseCase, GetTimeSlotTypesUseCase>();
            services.AddScoped<IGetAllTimeSlotTypesUseCase, GetAllTimeSlotTypesUseCase>();
            services.AddScoped<IDeleteTimeSlotTypesUseCase, DeleteTimeSlotTypesUseCase>();

            #endregion TimeSlotTypes

            #region HomeCarePackage

            services.AddScoped<IUpsertHomeCarePackageUseCase, UpsertHomeCarePackageUseCase>();
            services.AddScoped<IChangeStatusHomeCarePackageUseCase, ChangeStatusHomeCarePackageUseCase>();

            #endregion HomeCarePackage

            #region DayCarePackage

            services.AddScoped<ICreateDayCarePackageUseCase, CreateDayCarePackageUseCase>();
            services.AddScoped<IGetDayCarePackageUseCase, GetDayCarePackageUseCase>();
            services.AddScoped<IGetDayCarePackageListUseCase, GetDayCarePackageListUseCase>();
            services.AddScoped<IUpdateDayCarePackageUseCase, UpdateDayCarePackageUseCase>();

            #endregion DayCarePackage

            #region DayCarePackageOpportunity

            services.AddScoped<ICreateDayCarePackageOpportunityUseCase, CreateDayCarePackageOpportunityUseCase>();
            services.AddScoped<IGetDayCarePackageOpportunityListUseCase, GetDayCarePackageOpportunityListUseCase>();
            services.AddScoped<IGetDayCarePackageOpportunityUseCase, GetDayCarePackageOpportunityUseCase>();
            services.AddScoped<IUpdateDayCarePackageOpportunityUseCase, UpdateDayCarePackageOpportunityUseCase>();

            #endregion DayCarePackageOpportunity

            #region HomeCarePackageSlots

            services.AddScoped<IUpsertHomeCarePackageSlotsUseCase, UpsertHomeCarePackageSlotsUseCase>();
            services.AddScoped<IDeleteHomeCarePackageSlotsUseCase, DeleteHomeCarePackageSlotsUseCase>();

            #endregion HomeCarePackageSlots

            #region TimeSlotShift

            services.AddScoped<IUpsertTimeSlotShiftsUseCase, UpsertTimeSlotShiftsUseCase>();
            services.AddScoped<IGetTimeSlotShiftsUseCase, GetTimeSlotShiftsUseCase>();
            services.AddScoped<IGetAllTimeSlotShiftsUseCase, GetAllTimeSlotShiftsUseCase>();
            services.AddScoped<IDeleteTimeSlotShiftsUseCase, DeleteTimeSlotShiftsUseCase>();

            #endregion TimeSlotShift

            #region Clients

            services.AddScoped<IUpsertClientsUseCase, UpsertClientsUseCase>();
            services.AddScoped<IGetClientsUseCase, GetClientsUseCase>();
            services.AddScoped<IDeleteClientsUseCase, DeleteClientsUseCase>();

            #endregion Clients

            #region Users

            services.AddScoped<IUpsertUsersUseCase, UpsertUsersUseCase>();
            services.AddScoped<IGetUsersUseCase, GetUsersUseCase>();
            services.AddScoped<IDeleteUsersUseCase, DeleteUsersUseCase>();

            #endregion Users

            #region Status

            services.AddScoped<IUpsertStatusUseCase, UpsertStatusUseCase>();
            services.AddScoped<IGetStatusUseCase, GetStatusUseCase>();
            services.AddScoped<IGetAllStatusUseCase, GetAllStatusUseCase>();
            services.AddScoped<IDeleteStatusUseCase, DeleteStatusUseCase>();

            #endregion Status

            #region ResidentialCarePackage

            services.AddScoped<IUpsertResidentialCarePackageUseCase, UpsertResidentialCarePackageUseCase>();
            services.AddScoped<IGetResidentialCarePackageUseCase, GetResidentialCarePackageUseCase>();

            #endregion ResidentialCarePackage

            #region NursingCarePackage

            services.AddScoped<IUpsertNursingCarePackageUseCase, UpsertNursingCarePackageUseCase>();
            services.AddScoped<IGetNursingCarePackageUseCase, GetNursingCarePackageUseCase>();

            #endregion NursingCarePackage
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (IServiceScope appScope = app.ApplicationServices.CreateScope())
            {
                DatabaseContext databaseContext = appScope.ServiceProvider.GetRequiredService<DatabaseContext>();

                // Create if not exists
                /*if (!((RelationalDatabaseCreator) databaseContext.Database.GetService<IDatabaseCreator>()).Exists())
                {
                    databaseContext.Database.EnsureCreated();
                }*/

                // Perform migrations
                if (databaseContext.Database.GetPendingMigrations().Any())
                {
                    databaseContext.Database.Migrate();
                }
            }

            app.UseCors(options => options.WithOrigins("http://localhost:3000").AllowAnyMethod().AllowAnyHeader());
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
            IMapper mapper = app.ApplicationServices.GetService<IMapper>();
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

            app.UseEndpoints(endpoints =>
            {
                // SwaggerGen won't find controllers that are routed via this technique.
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
