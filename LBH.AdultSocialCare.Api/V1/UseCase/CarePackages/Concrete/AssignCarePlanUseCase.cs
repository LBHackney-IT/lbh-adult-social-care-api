using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Domain.CarePackages;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Services.IO;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Threading.Tasks;
using HttpServices.Models.Responses;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class AssignCarePlanUseCase : IAssignCarePlanUseCase
    {
        private readonly IGetServiceUserUseCase _getServiceUserUseCase;
        private readonly ICarePackageGateway _carePackageGateway;
        private readonly IEnsureSingleActivePackageTypePerUserUseCase _ensureSingleActivePackageTypePerUserUseCase;
        private readonly IDatabaseManager _dbManager;
        private readonly IFileStorage _fileStorage;

        public AssignCarePlanUseCase(
            IGetServiceUserUseCase getServiceUserUseCase, ICarePackageGateway carePackageGateway,
            IEnsureSingleActivePackageTypePerUserUseCase ensureSingleActivePackageTypePerUserUseCase,
            IDatabaseManager dbManager, IFileStorage fileStorage)
        {
            _getServiceUserUseCase = getServiceUserUseCase;
            _carePackageGateway = carePackageGateway;
            _ensureSingleActivePackageTypePerUserUseCase = ensureSingleActivePackageTypePerUserUseCase;
            _dbManager = dbManager;
            _fileStorage = fileStorage;
        }

        public async Task<Guid> ExecuteAsync(CarePlanAssignmentDomain carePlanAssignment)
        {
            var serviceUser = await _getServiceUserUseCase.GetServiceUserInformation(carePlanAssignment.HackneyUserId);
            await _ensureSingleActivePackageTypePerUserUseCase.ExecuteAsync(serviceUser.Id, carePlanAssignment.PackageType);

            var documentResponse = new DocumentResponse();

            if (carePlanAssignment.CarePlanFileId == Guid.Empty && carePlanAssignment.CarePlanFile != null)
            {
                documentResponse = await _fileStorage.SaveFileAsync(ConvertCarePlan(carePlanAssignment.CarePlanFile), carePlanAssignment.CarePlanFile?.FileName);
            }

            var package = new CarePackage
            {
                ServiceUserId = serviceUser.Id,
                BrokerId = carePlanAssignment.BrokerId,
                PackageType = carePlanAssignment.PackageType,
                Status = PackageStatus.New,
                DateAssigned = DateTimeOffset.Now,
                PackageScheduling = PackageScheduling.Temporary, // TODO: Review if package scheduling can be made nullable
            };

            if (documentResponse.FileId != Guid.Empty)
            {
                package.Resources.Add(new CarePackageResource()
                {
                    FileId = documentResponse.FileId,
                    FileExtension = Path.GetExtension(documentResponse.FileName),
                    Name = documentResponse.FileName,
                    Type = PackageResourceType.CarePlanFile,
                });
            }

            package.Histories.Add(new CarePackageHistory
            {
                Status = HistoryStatus.NewPackage,
                Description = HistoryStatus.NewPackage.GetDisplayName(),
                RequestMoreInformation = carePlanAssignment.Notes
            });

            _carePackageGateway.Create(package);
            await _dbManager.SaveAsync();
            return package.Id;
        }

        private static string ConvertCarePlan(IFormFile carePlanFile)
        {
            if (carePlanFile != null)
            {
                using (var stream = new MemoryStream())
                {
                    carePlanFile.CopyTo(stream);

                    var bytes = stream.ToArray();
                    return $"data:{carePlanFile.ContentType};base64,{Convert.ToBase64String(bytes)}";
                }
            }

            return null;
        }
    }
}
