using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Extensions;
using LBH.AdultSocialCare.Api.V1.Gateways;
using LBH.AdultSocialCare.Api.V1.Gateways.CarePackages.Interfaces;
using LBH.AdultSocialCare.Api.V1.Gateways.Enums;
using LBH.AdultSocialCare.Api.V1.Services.IO;
using LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Interfaces;
using LBH.AdultSocialCare.Data.Constants.Enums;
using LBH.AdultSocialCare.Data.Entities.CarePackages;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.UseCase.CarePackages.Concrete
{
    public class CreatePackageResourceUseCase: ICreatePackageResourceUseCase
    {
        private readonly ICarePackageGateway _gateway;
        private readonly IDatabaseManager _dbManager;
        private readonly IFileStorage _fileStorage;

        public CreatePackageResourceUseCase(ICarePackageGateway gateway, IDatabaseManager dbManager, IFileStorage fileStorage)
        {
            _gateway = gateway;
            _dbManager = dbManager;
            _fileStorage = fileStorage;
        }

        public async Task<Guid> CreateFileAsync(Guid carePackageId, PackageResourceType type, IFormFile file)
        {
            var package = await _gateway.GetPackageAsync(carePackageId, PackageFields.None, true)
                .EnsureExistsAsync($"Care package with id {carePackageId} not found");

            var documentResponse = await _fileStorage.SaveFileAsync(ConvertCarePlan(file), file.FileName);

            var resourceToCreate = new CarePackageResource
            {
                Type = type,
                Name = documentResponse.FileName,
                FileExtension = Path.GetExtension(file.FileName),
                FileId = documentResponse.FileId,
                PackageId = carePackageId
            };

            package.Resources.Add(resourceToCreate);

            await _dbManager.SaveAsync();

            return resourceToCreate.Id;
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
