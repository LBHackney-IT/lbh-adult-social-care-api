using Amazon.XRay.Recorder.Handlers.AwsSdk;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1;
using LBH.AdultSocialCare.Api.V1.Exceptions.Filters;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCareCollegeGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCarePackageOpportunityGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCareRequestMoreInformationGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApproveBrokeredGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApprovePackageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareBrokerageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareRequestMoreInformationGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCareStageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApproveCommercialGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApprovePackageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCareRequestMoreInformationGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.OpportunityLengthOptionGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.OpportunityTimesPerMonthOptionGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApprovalHistoryGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApproveBrokeredGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareApprovePackageGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareRequestMoreInformationGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.SupplierCostGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.SupplierGateways;
using LBH.AdultSocialCare.Api.V1.Gateways.TermTimeConsiderationOptionGateways;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.UseCase.ClientsUseCases;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCareCollegeUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCareCollegeUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageOpportunityUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCarePackageUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCareRequestMoreInformationUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.DayCareRequestMoreInformationUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCare;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovalHistoryUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovalHistoryUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApproveBrokeredUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApproveBrokeredUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovePackageUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareApprovePackageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareBrokerageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareRequestMoreInformationUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.HomeCareRequestMoreInformationUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovalHistoryUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovalHistoryUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApproveCommercialUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApproveCommercialUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovePackageUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApprovePackageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareRequestMoreInformationUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareRequestMoreInformationUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.OpportunityLengthOptionUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.OpportunityLengthOptionUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.OpportunityTimesPerMonthOptionUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.OpportunityTimesPerMonthOptionUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.PackageStatusUseCases;
using LBH.AdultSocialCare.Api.V1.UseCase.PackageUseCases;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApproveBrokeredUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApproveBrokeredUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApprovePackageUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialApprovePackageUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareApprovalHistoryUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareApprovalHistoryUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareRequestMoreInformationUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareRequestMoreInformationUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.ResidentialCareUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.RolesUseCases;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierCostUseCase.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierCostUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.SupplierUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.TermTimeConsiderationOptionUseCases.Concrete;
using LBH.AdultSocialCare.Api.V1.UseCase.TermTimeConsiderationOptionUseCases.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.UserUseCases;
using LBH.AdultSocialCare.Api.Versioning;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
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

            /*services.AddDbContext<DatabaseContext>(
                opt => opt.UseNpgsql(connectionString, b => b.MigrationsAssembly(assemblyName)).AddXRayInterceptor(true));*/

            services.AddDbContext<DatabaseContext>(opt
                => opt.UseNpgsql(connectionString, b => b.MigrationsAssembly(assemblyName)));
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
            services.AddScoped<IPackageGateway, PackageGateway>();
            services.AddScoped<IHomeCareServiceTypeGateway, HomeCareServiceTypeGateway>();
            services.AddScoped<IRolesGateway, RoleGateway>();
            services.AddScoped<ITimeSlotShiftsGateway, TimeSlotShiftsGateway>();
            services.AddScoped<IHomeCarePackageGateway, HomeCarePackageGateway>();
            services.AddScoped<IDayCarePackageGateway, DayCarePackageGateway>();
            services.AddScoped<IDayCareBrokerageInfoGateway, DayCareBrokerageInfoGateway>();
            services.AddScoped<IDayCarePackageOpportunityGateway, DayCarePackageOpportunityGateway>();
            services.AddScoped<IClientsGateway, ClientsGateway>();
            services.AddScoped<IHomeCarePackageSlotsGateway, HomeCarePackageSlotsGateway>();
            services.AddScoped<IUsersGateway, UsersGateway>();
            services.AddScoped<IStatusGateway, StatusGateway>();
            services.AddScoped<IResidentialCarePackageGateway, ResidentialCarePackageGateway>();
            services.AddScoped<INursingCarePackageGateway, NursingCarePackageGateway>();
            services.AddScoped<INursingCareAdditionalNeedsGateway, NursingCareAdditionalNeedsGateway>();
            services.AddScoped<IResidentialCareAdditionalNeedsGateway, ResidentialCareAdditionalNeedsGateway>();
            services.AddScoped<ITermTimeConsiderationOptionGateway, TermTimeConsiderationOptionGateway>();
            services.AddScoped<IOpportunityLengthOptionGateway, OpportunityLengthOptionGateway>();
            services.AddScoped<IOpportunityTimesPerMonthOptionGateway, OpportunityTimesPerMonthOptionGateway>();
            services.AddScoped<IHomeCareBrokerageGateway, HomeCareBrokerageGateway>();
            services.AddScoped<ISupplierGateway, SupplierGateway>();
            services.AddScoped<ISupplierCostGateway, SupplierCostGateway>();
            services.AddScoped<IHomeCareStageGateway, HomeCareStageGateway>();
            services.AddScoped<IApprovalHistoryGateway, ApprovalHistoryGateway>();
            services.AddScoped<IHomeCareApprovePackageGateway, HomeCareApprovePackageGateway>();
            services.AddScoped<IHomeCareApproveBrokeredGateway, HomeCareApproveBrokeredGateway>();
            services.AddScoped<INursingCareApprovalHistoryGateway, NursingCareApprovalHistoryGateway>();
            services.AddScoped<INursingCareApprovePackageGateway, NursingCareApprovePackageGateway>();
            services.AddScoped<INursingCareApproveCommercialGateway, NursingCareApproveCommercialGateway>();
            services.AddScoped<IResidentialCareApprovalHistoryGateway, ResidentialCareApprovalHistoryGateway>();
            services.AddScoped<IResidentialCareApprovePackageGateway, ResidentialCareApprovePackageGateway>();
            services.AddScoped<IResidentialCareApproveBrokeredGateway, ResidentialCareApproveBrokeredGateway>();
            services.AddScoped<IHomeCareRequestMoreInformationGateway, HomeCareRequestMoreInformationGateway>();
            services.AddScoped<IDayCareCollegeGateway, DayCareCollegeGateway>();
            services.AddScoped<IDayCareRequestMoreInformationGateway, DayCareRequestMoreInformationGateway>();
            services.AddScoped<INursingCareRequestMoreInformationGateway, NursingCareRequestMoreInformationGateway>();
            services.AddScoped<IResidentialCareRequestMoreInformationGateway, ResidentialCareRequestMoreInformationGateway>();
        }

        private static void RegisterUseCases(IServiceCollection services)
        {
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

            #region HomeCarePackage

            services.AddScoped<IUpsertHomeCarePackageUseCase, UpsertHomeCarePackageUseCase>();
            services.AddScoped<IChangeStatusHomeCarePackageUseCase, ChangeStatusHomeCarePackageUseCase>();
            services.AddScoped<IGetAllHomeCarePackageUseCase, GetAllHomeCarePackageUseCase>();

            #endregion HomeCarePackage

            #region DayCarePackage

            services.AddScoped<ICreateDayCarePackageUseCase, CreateDayCarePackageUseCase>();
            services.AddScoped<IGetDayCarePackageUseCase, GetDayCarePackageUseCase>();
            services.AddScoped<IGetDayCarePackageListUseCase, GetDayCarePackageListUseCase>();
            services.AddScoped<IUpdateDayCarePackageUseCase, UpdateDayCarePackageUseCase>();
            services.AddScoped<IGetDayCarePackageForApprovalDetailsUseCase, GetDayCarePackageForApprovalDetailsUseCase>();
            services.AddScoped<ICreateDayCarePackageHistoryUseCase, CreateDayCarePackageHistoryUseCase>();
            services.AddScoped<IChangeDayCarePackageStatusUseCase, ChangeDayCarePackageStatusUseCase>();

            #endregion DayCarePackage

            #region DayCarePackageOpportunity

            services.AddScoped<ICreateDayCarePackageOpportunityUseCase, CreateDayCarePackageOpportunityUseCase>();
            services.AddScoped<IGetDayCarePackageOpportunityListUseCase, GetDayCarePackageOpportunityListUseCase>();
            services.AddScoped<IGetDayCarePackageOpportunityUseCase, GetDayCarePackageOpportunityUseCase>();
            services.AddScoped<IUpdateDayCarePackageOpportunityUseCase, UpdateDayCarePackageOpportunityUseCase>();

            #endregion DayCarePackageOpportunity

            #region HomeCarePackageSlots

            services.AddScoped<IUpsertHomeCarePackageSlotsUseCase, UpsertHomeCarePackageSlotsUseCase>();

            #endregion HomeCarePackageSlots

            #region TimeSlotShift

            services.AddScoped<IUpsertTimeSlotShiftsUseCase, UpsertTimeSlotShiftsUseCase>();
            services.AddScoped<IGetTimeSlotShiftsUseCase, GetTimeSlotShiftsUseCase>();
            services.AddScoped<IGetAllTimeSlotShiftsUseCase, GetAllTimeSlotShiftsUseCase>();
            services.AddScoped<IDeleteTimeSlotShiftsUseCase, DeleteTimeSlotShiftsUseCase>();

            #endregion TimeSlotShift

            #region Client

            services.AddScoped<IUpsertClientsUseCase, UpsertClientsUseCase>();
            services.AddScoped<IGetClientsUseCase, GetClientsUseCase>();
            services.AddScoped<IDeleteClientsUseCase, DeleteClientsUseCase>();

            #endregion Client

            #region User

            services.AddScoped<IUpsertUsersUseCase, UpsertUsersUseCase>();
            services.AddScoped<IGetUsersUseCase, GetUsersUseCase>();
            services.AddScoped<IDeleteUsersUseCase, DeleteUsersUseCase>();

            #endregion User

            #region PackageStatuses

            services.AddScoped<IUpsertStatusUseCase, UpsertStatusUseCase>();
            services.AddScoped<IGetStatusUseCase, GetStatusUseCase>();
            services.AddScoped<IGetAllStatusUseCase, GetAllStatusUseCase>();
            services.AddScoped<IDeleteStatusUseCase, DeleteStatusUseCase>();

            #endregion PackageStatuses

            #region ResidentialCarePackages

            services.AddScoped<IUpdateResidentialCarePackageUseCase, UpdateResidentialCarePackageUseCase>();
            services.AddScoped<IGetResidentialCarePackageUseCase, GetResidentialCarePackageUseCase>();
            services.AddScoped<IGetResidentialCareAdditionalNeedsUseCase, GetResidentialCareAdditionalNeedsUseCase>();
            services.AddScoped<IUpsertResidentialCareAdditionalNeedsUseCase, UpsertResidentialCareAdditionalNeedsUseCase>();
            services.AddScoped<IChangeStatusResidentialCarePackageUseCase, ChangeStatusResidentialCarePackageUseCase>();
            services.AddScoped<IGetAllResidentialCarePackageUseCase, GetAllResidentialCarePackageUseCase>();
            services.AddScoped<IGetAllResidentialCareHomeTypeUseCase, GetAllResidentialCareHomeTypeUseCase>();
            services.AddScoped<IGetAllResidentialCareTypeOfStayOptionUseCase, GetAllResidentialCareTypeOfStayOptionUseCase>();
            services.AddScoped<ICreateResidentialCarePackageUseCase, CreateResidentialCarePackageUseCase>();
            services.AddScoped<IDeleteResidentialCareAdditionalNeedsUseCase, DeleteResidentialCareAdditionalNeedsUseCase>();

            #endregion ResidentialCarePackages

            #region NursingCarePackages

            services.AddScoped<IUpdateNursingCarePackageUseCase, UpdateNursingCarePackageUseCase>();
            services.AddScoped<IGetNursingCarePackageUseCase, GetNursingCarePackageUseCase>();
            services.AddScoped<IGetNursingCareAdditionalNeedsUseCase, GetNursingCareAdditionalNeedsUseCase>();
            services.AddScoped<IUpsertNursingCareAdditionalNeedsUseCase, UpsertNursingCareAdditionalNeedsUseCase>();
            services.AddScoped<IChangeStatusNursingCarePackageUseCase, ChangeStatusNursingCarePackageUseCase>();
            services.AddScoped<IGetAllNursingCarePackageUseCase, GetAllNursingCarePackageUseCase>();
            services.AddScoped<IGetAllNursingCareHomeTypeUseCase, GetAllNursingCareHomeTypeUseCase>();
            services.AddScoped<IGetAllNursingCareTypeOfStayOptionUseCase, GetAllNursingCareTypeOfStayOptionUseCase>();
            services.AddScoped<ICreateNursingCarePackageUseCase, CreateNursingCarePackageUseCase>();
            services.AddScoped<IDeleteNursingCareAdditionalNeedsUseCase, DeleteNursingCareAdditionalNeedsUseCase>();

            #endregion NursingCarePackages

            #region TermTimeConsiderationOptions

            services.AddScoped<IGetTermTimeConsiderationOptionsListUseCase, GetTermTimeConsiderationOptionsListUseCase>();

            #endregion TermTimeConsiderationOptions

            #region OpportunityLengthOptions

            services.AddScoped<IGetOpportunityLengthOptionsListUseCase, GetOpportunityLengthOptionsListUseCase>();

            #endregion OpportunityLengthOptions

            #region OpportunityTimesPerMonthOptions

            services
                .AddScoped<IGetOpportunityTimesPerMonthOptionsListUseCase, GetOpportunityTimesPerMonthOptionsListUseCase
                >();

            #endregion OpportunityTimesPerMonthOptions

            #region HomeCareBrokerage

            services.AddScoped<IGetAllHomeCareStageUseCase, GetAllHomeCareStageUseCase>();
            services.AddScoped<IGetHomeCareBrokerageUseCase, GetHomeCareBrokerageUseCase>();
            services.AddScoped<ICreateHomeCareBrokerageUseCase, CreateHomeCareBrokerageUseCase>();
            services.AddScoped<ICreateHomeCareRequestMoreInformationUseCase, CreateHomeCareRequestMoreInformationUseCase>();

            #endregion HomeCareBrokerage

            #region Supplier

            services.AddScoped<ICreateSupplierUseCase, CreateSupplierUseCase>();
            services.AddScoped<IGetAllSupplierUseCase, GetAllSupplierUseCase>();
            services.AddScoped<IGetSupplierCostUseCase, GetSupplierCostUseCase>();
            services.AddScoped<ICreateSupplierCostUseCase, CreateSupplierCostUseCase>();

            #endregion Supplier

            #region HomeCareApprovalHistory

            services.AddScoped<IGetAllHomeCareApprovalHistoryUseCase, GetAllHomeCareApprovalHistoryUseCase>();

            #endregion HomeCareApprovalHistory

            #region HomeCareApprovePackage

            services.AddScoped<IGetHomeCareApprovePackageUseCase, GetHomeCareApprovePackageUseCase>();

            #endregion HomeCareApprovePackage

            #region HomeCareApproveBrokered

            services.AddScoped<IGetHomeCareApproveBrokeredUseCase, GetHomeCareApproveBrokeredUseCase>();

            #endregion HomeCareApproveBrokered

            #region NursingCareApprovalHistory

            services.AddScoped<IGetAllNursingCareApprovalHistoryUseCase, GetAllNursingCareApprovalHistoryUseCase>();

            #endregion NursingCareApprovalHistory

            #region NursingCareApprovePackage

            services.AddScoped<IGetNursingCareApprovePackageUseCase, GetNursingCareApprovePackageUseCase>();

            #endregion NursingCareApprovePackage

            #region NursingCareApproveCommercial

            services.AddScoped<IGetNursingCareApproveCommercialUseCase, GetNursingCareApproveCommercialUseCase>();

            #endregion NursingCareApproveCommercial

            #region ResidentialCareApprovalHistory

            services.AddScoped<IGetAllResidentialCareApprovalHistoryUseCase, GetAllResidentialCareApprovalHistoryUseCase>();

            #endregion ResidentialCareApprovalHistory

            #region ResidentialCareApprovePackage

            services.AddScoped<IGetResidentialCareApprovePackageUseCase, GetResidentialCareApprovePackageUseCase>();

            #endregion ResidentialCareApprovePackage

            #region ResidentialCareApproveBrokered

            services.AddScoped<IGetResidentialCareApproveBrokeredUseCase, GetResidentialCareApproveBrokeredUseCase>();

            #endregion ResidentialCareApproveBrokered

            #region DayCareCollege

            services.AddScoped<ICreateDayCareCollegeUseCase, CreateDayCareCollegeUseCase>();
            services.AddScoped<IGetDayCareCollegeUseCase, GetDayCareCollegeUseCase>();
            services.AddScoped<IGetDayCareCollegeListUseCase, GetDayCareCollegeListUseCase>();

            #endregion DayCareCollege

            #region DayCareBrokerage

            services.AddScoped<ICreateDayCareRequestMoreInformationUseCase, CreateDayCareRequestMoreInformationUseCase>();
            services.AddScoped<IDayCarePackageBrokerageUseCase, DayCarePackageBrokerageUseCase>();

            #endregion DayCareBrokerage

            #region NursingCareBrokerage

            services.AddScoped<ICreateNursingCareRequestMoreInformationUseCase, CreateNursingCareRequestMoreInformationUseCase>();

            #endregion NursingCareBrokerage

            #region ResidentialCareBrokerage

            services.AddScoped<ICreateResidentialCareRequestMoreInformationUseCase, CreateResidentialCareRequestMoreInformationUseCase>();

            #endregion ResidentialCareBrokerage
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (IServiceScope appScope = app.ApplicationServices.CreateScope())
            {
                DatabaseContext databaseContext = appScope.ServiceProvider.GetRequiredService<DatabaseContext>();

                // Create if not exists
                // This next section is the reason devs are forgetting to create migrations. Leave commented
                /*if (!((RelationalDatabaseCreator) databaseContext.Database.GetService<IDatabaseCreator>()).Exists())
                {
                    databaseContext.Database.EnsureCreated();
                }*/
                if (databaseContext.Database.GetPendingMigrations().Any())
                {
                    // Perform migrations
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
