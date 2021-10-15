using System;
using System.IO;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.CarePackages;
using LBH.AdultSocialCare.Api.V1.Services.IO;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class AssignCarePlanUseCase : IAssignCarePlanUseCase
    {
        private readonly IGetServiceUserUseCase _getServiceUserUseCase;
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IDatabaseManager _dbManager;
        private readonly IFileStorage _fileStorage;

        public AssignCarePlanUseCase(
            IGetServiceUserUseCase getServiceUserUseCase, ICarePackageGateway carePackageGateway,
            IDatabaseManager dbManager, IFileStorage fileStorage)
        {
            _getServiceUserUseCase = getServiceUserUseCase;
            _carePackageGateway = carePackageGateway;
            _dbManager = dbManager;
            _fileStorage = fileStorage;
        }

        public async Task ExecuteAsync(CarePlanAssignmentDomain carePlanAssignment)
        {
            var serviceUser = await _getServiceUserUseCase.GetServiceUserInformation(carePlanAssignment.HackneyUserId);
            var packagesCount = await _carePackageGateway.GetServiceUserActivePackagesCount(serviceUser.Id, carePlanAssignment.PackageType);

            if (packagesCount > 0)
            {
                throw new ApiException($"User has an active {carePlanAssignment.PackageType.GetDisplayName()} already");
            }

            var carePlanFileUrl = await UploadCarePlan(carePlanAssignment.CarePlanFile);

            var package = new CarePackage
            {
                ServiceUserId = serviceUser.Id,
                BrokerId = carePlanAssignment.BrokerId,
                PackageType = carePlanAssignment.PackageType,
                Status = PackageStatus.New,
                DateAssigned = DateTimeOffset.Now,
                SocialWorkerCarePlanFileUrl = carePlanFileUrl
            };

            package.Histories.Add(new CarePackageHistory
            {
                Status = HistoryStatus.NewPackage,
                Description = carePlanAssignment.Notes
            });

            _carePackageGateway.Create(package);
            await _dbManager.SaveAsync();
        }

        private async Task<string> UploadCarePlan(IFormFile carePlanFile)
        {
            if (carePlanFile != null)
            {
                using (var stream = new MemoryStream())
                {
                    carePlanFile.CopyTo(stream);
                    var bytes = stream.ToArray();

                    return await _fileStorage.SaveFileAsync(bytes);
                }
            }
            else
            {
                return null;
            }
        }
    }
}
