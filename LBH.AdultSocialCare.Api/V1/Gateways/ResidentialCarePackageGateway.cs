using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways
{
    public class ResidentialCarePackageGateway : IResidentialCarePackageGateway
    {
        private readonly DatabaseContext _databaseContext;

        public ResidentialCarePackageGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<ResidentialCarePackage> GetAsync(Guid residentialCarePackageId)
        {
            var result = await _databaseContext.ResidentialCarePackage
                .Include(item => item.Clients)
                .Include(item => item.Status)
                .FirstOrDefaultAsync(item => item.Id == residentialCarePackageId).ConfigureAwait(false);
            return result;
        }

        public async Task<ResidentialCarePackage> UpsertAsync(ResidentialCarePackage residentialCarePackage)
        {
            ResidentialCarePackage residentialCarePackageToUpdate = await _databaseContext.ResidentialCarePackage
                .Include(item => item.Clients)
                .Include(item => item.Status)
                .FirstOrDefaultAsync(item => item.Id == residentialCarePackage.Id).ConfigureAwait(false);
            if (residentialCarePackageToUpdate == null)
            {
                residentialCarePackageToUpdate = new ResidentialCarePackage();
                await _databaseContext.ResidentialCarePackage.AddAsync(residentialCarePackageToUpdate).ConfigureAwait(false);
            }
            residentialCarePackageToUpdate.ClientId = residentialCarePackage.ClientId;
            residentialCarePackageToUpdate.StartDate = residentialCarePackage.StartDate;
            residentialCarePackageToUpdate.EndDate = residentialCarePackage.EndDate;
            residentialCarePackageToUpdate.IsRespiteCare = residentialCarePackage.IsRespiteCare;
            residentialCarePackageToUpdate.IsDischargePackage = residentialCarePackage.IsDischargePackage;
            residentialCarePackageToUpdate.IsImmediateReenablementPackage = residentialCarePackage.IsImmediateReenablementPackage;
            residentialCarePackageToUpdate.IsExpectedStayOver52Weeks = residentialCarePackage.IsExpectedStayOver52Weeks;
            residentialCarePackageToUpdate.IsThisUserUnderS117 = residentialCarePackage.IsThisUserUnderS117;
            residentialCarePackageToUpdate.NeedToAddress = residentialCarePackage.NeedToAddress;
            residentialCarePackageToUpdate.TypeOfCareHome = residentialCarePackage.TypeOfCareHome;
            residentialCarePackageToUpdate.Weekly = residentialCarePackage.Weekly;
            residentialCarePackageToUpdate.OneOff = residentialCarePackage.OneOff;
            residentialCarePackageToUpdate.AdditionalNeedToAddress = residentialCarePackage.AdditionalNeedToAddress;
            residentialCarePackageToUpdate.CreatorId = residentialCarePackage.CreatorId;
            residentialCarePackageToUpdate.DateCreated = residentialCarePackage.DateCreated;
            residentialCarePackageToUpdate.UpdatorId = residentialCarePackage.UpdatorId;
            residentialCarePackageToUpdate.DateUpdated = residentialCarePackage.DateUpdated;
            residentialCarePackageToUpdate.StatusId = residentialCarePackage.StatusId;
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess ? residentialCarePackageToUpdate : null;
        }
    }
}
