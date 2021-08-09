using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.HomeCareBrokerageDomains;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ApprovalHistoryGateways
{
    public class ApprovalHistoryGateway : IApprovalHistoryGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public ApprovalHistoryGateway(DatabaseContext databaseContext, IMapper mapper)
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
    }
}
