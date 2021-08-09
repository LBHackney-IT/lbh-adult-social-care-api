using AutoMapper;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCareApprovalHistoryGateways
{
    public class HomeCareApprovalHistoryGateway : IHomeCareApprovalHistoryGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public HomeCareApprovalHistoryGateway(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<HomeCareApprovalHistoryDomain>> ListAsync(Guid homeCarePackageId)
        {
            var homeCareApprovalHistories = await _databaseContext.HomeCareApprovalHistories
                .Where(ah => ah.HomeCarePackageId.Equals(homeCarePackageId))
                .ToListAsync().ConfigureAwait(false);
            return homeCareApprovalHistories?.ToDomain();
        }

        public async Task<HomeCareApprovalHistoryDomain> CreateAsync(HomeCareApprovalHistory homeCareApprovalHistory)
        {
            var entry = await _databaseContext.HomeCareApprovalHistories.AddAsync(homeCareApprovalHistory).ConfigureAwait(false);
            try
            {
                await _databaseContext.SaveChangesAsync().ConfigureAwait(false);
                return entry.Entity.ToDomain();
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save approval history to database");
            }
        }
    }
}
