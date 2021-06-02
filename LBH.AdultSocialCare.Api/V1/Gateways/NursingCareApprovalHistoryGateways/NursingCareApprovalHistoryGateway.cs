using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCareBrokerageDomains;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCareApprovalHistoryGateways
{
    public class NursingCareApprovalHistoryGateway : INursingCareApprovalHistoryGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public NursingCareApprovalHistoryGateway(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<NursingCareApprovalHistoryDomain>> ListAsync(Guid nursingCarePackageId)
        {
            var nursingCareApprovalHistories = await _databaseContext.NursingCareApprovalHistories
                .Where(a => a.NursingCarePackageId.Equals(nursingCarePackageId))
                .ToListAsync().ConfigureAwait(false);
            return nursingCareApprovalHistories?.ToDomain();
        }

        public async Task<NursingCareApprovalHistoryDomain> CreateAsync(NursingCareApprovalHistory nursingCareApprovalHistory)
        {
            var entry = await _databaseContext.NursingCareApprovalHistories.AddAsync(nursingCareApprovalHistory).ConfigureAwait(false);
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
