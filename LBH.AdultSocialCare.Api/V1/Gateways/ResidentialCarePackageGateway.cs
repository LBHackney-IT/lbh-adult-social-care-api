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

        public async Task<ResidentialCarePackage> UpsertAsync(ResidentialCarePackage residentialCarePackage)
        {
            ResidentialCarePackage residentialCarePackageToUpdate = await _databaseContext.ResidentialCarePackage.
                FirstOrDefaultAsync(item => item.Id == residentialCarePackage.Id).ConfigureAwait(false);
            if (residentialCarePackageToUpdate == null)
            {
                residentialCarePackageToUpdate = new ResidentialCarePackage();
                await _databaseContext.ResidentialCarePackage.AddAsync(residentialCarePackageToUpdate).ConfigureAwait(false);
            }
            residentialCarePackageToUpdate.ClientId = residentialCarePackage.ClientId;
            residentialCarePackageToUpdate.Clients = await _databaseContext.Clients.FirstOrDefaultAsync(item => item.Id == residentialCarePackage.ClientId).ConfigureAwait(false);
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
            residentialCarePackageToUpdate.Status = await _databaseContext.Status.FirstOrDefaultAsync(item => item.Id == residentialCarePackageToUpdate.StatusId).ConfigureAwait(false);
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess ? residentialCarePackageToUpdate : null;
        }
    }
}
