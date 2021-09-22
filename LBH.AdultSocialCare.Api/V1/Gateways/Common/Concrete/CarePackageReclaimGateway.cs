using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class CarePackageReclaimGateway : ICarePackageReclaimGateway
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        public CarePackageReclaimGateway(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarePackageReclaimDomain>> GetCarePackageReclaims(Guid carePackageId)
        {
            var carePackageReclaims = await _dbContext.CarePackageReclaims
                                                     .Where(cpr => cpr.CarePackageId == carePackageId)
                                                     .Select(cpr => _mapper.Map<CarePackageReclaimDomain>(cpr))
                                                     .ToListAsync();

            return carePackageReclaims;
        }
    }
}
