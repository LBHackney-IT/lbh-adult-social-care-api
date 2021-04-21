using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCare;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways
{

    public class NursingCarePackageGateway : INursingCarePackageGateway
    {

        private readonly DatabaseContext _databaseContext;

        public NursingCarePackageGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<NursingCarePackage> GetAsync(Guid nursingCarePackageId)
        {
            var result = await _databaseContext.NursingCarePackage
                .Include(item => item.TypeOfCareHome)
                .Include(item => item.Clients)
                .Include(item => item.Status)
                .Include(item => item.NursingCareAdditionalNeeds)
                .FirstOrDefaultAsync(item => item.Id == nursingCarePackageId).ConfigureAwait(false);
            return result;
        }

        public async Task<NursingCarePackage> UpsertAsync(NursingCarePackage nursingCarePackage)
        {
            NursingCarePackage nursingCarePackageToUpdate = await _databaseContext.NursingCarePackage
                .Include(item => item.TypeOfCareHome)
                .Include(item => item.TypeOfStayOption)
                .Include(item => item.Clients)
                .Include(item => item.Status)
                .Include(item => item.NursingCareAdditionalNeeds)
                .FirstOrDefaultAsync(item => item.Id == nursingCarePackage.Id).ConfigureAwait(false);
            if (nursingCarePackageToUpdate == null)
            {
                nursingCarePackageToUpdate = new NursingCarePackage();
                await _databaseContext.NursingCarePackage.AddAsync(nursingCarePackageToUpdate).ConfigureAwait(false);
            }

            nursingCarePackageToUpdate.ClientId = nursingCarePackage.ClientId;
            nursingCarePackageToUpdate.IsFixedPeriod = nursingCarePackage.IsFixedPeriod;
            nursingCarePackageToUpdate.StartDate = nursingCarePackage.StartDate;
            nursingCarePackageToUpdate.EndDate = nursingCarePackage.EndDate;
            nursingCarePackageToUpdate.IsRespiteCare = nursingCarePackage.IsRespiteCare;
            nursingCarePackageToUpdate.IsDischargePackage = nursingCarePackage.IsDischargePackage;
            nursingCarePackageToUpdate.IsThisAnImmediateService = nursingCarePackage.IsThisAnImmediateService;
            nursingCarePackageToUpdate.IsThisUserUnderS117 = nursingCarePackage.IsThisUserUnderS117;
            nursingCarePackageToUpdate.TypeOfStayId = nursingCarePackage.TypeOfStayId;
            nursingCarePackageToUpdate.NeedToAddress = nursingCarePackage.NeedToAddress;
            nursingCarePackageToUpdate.TypeOfNursingCareHomeId = nursingCarePackage.TypeOfNursingCareHomeId;
            nursingCarePackageToUpdate.CreatorId = nursingCarePackage.CreatorId;
            nursingCarePackageToUpdate.UpdatorId = nursingCarePackage.UpdatorId;
            nursingCarePackageToUpdate.DateUpdated = nursingCarePackage.DateUpdated;
            nursingCarePackageToUpdate.StatusId = nursingCarePackage.StatusId;

            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess
                ? nursingCarePackageToUpdate
                : null;
        }

        public async Task<NursingCarePackage> ChangeStatusAsync(Guid nursingCarePackageId, int statusId)
        {
            NursingCarePackage nursingCarePackageToUpdate = await _databaseContext.NursingCarePackage
                .Include(item => item.TypeOfCareHome)
                .Include(item => item.TypeOfStayOption)
                .Include(item => item.Clients)
                .Include(item => item.Status)
                .Include(item => item.NursingCareAdditionalNeeds)
                .FirstOrDefaultAsync(item => item.Id == nursingCarePackageId)
                .ConfigureAwait(false);

            if (nursingCarePackageToUpdate == null)
            {
                throw new ErrorException($"Couldn't find the record: {nursingCarePackageId}");
            }
            nursingCarePackageToUpdate.StatusId = statusId;
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess
                ? nursingCarePackageToUpdate
                : null;
        }

        public async Task<IList<NursingCarePackage>> ListAsync()
        {
            return await _databaseContext.NursingCarePackage
                .Include(item => item.TypeOfCareHome)
                .Include(item => item.TypeOfStayOption)
                .Include(item => item.Clients)
                .Include(item => item.Status)
                .Include(item => item.NursingCareAdditionalNeeds)
                .ToListAsync().ConfigureAwait(false);
        }

        public async Task<IList<TypeOfNursingCareHome>> GetListOfTypeOfNursingCareHomeAsync()
        {
            return await _databaseContext.TypesOfNursingCareHome
                .ToListAsync().ConfigureAwait(false);
        }

        public async Task<IList<NursingCareTypeOfStayOption>> GetListOfNursingCareTypeOfStayOptionAsync()
        {
            return await _databaseContext.NursingCareTypeOfStayOption
                .ToListAsync().ConfigureAwait(false);
        }
    }

}
