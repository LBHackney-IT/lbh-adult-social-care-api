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
    public class CarePackageDetailGateway : ICarePackageDetailGateway
    {
        private readonly DatabaseContext _dbContext;
        private readonly IMapper _mapper;
        public CarePackageDetailGateway(DatabaseContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CarePackageDetailDomain>> GetCarePackageDetails(Guid carePackageId)
        {
            var carePackageDetails = await _dbContext.CarePackageDetails
                                                    .Where(cpr => cpr.CarePackageId == carePackageId)
                                                    .Select(cpr => _mapper.Map<CarePackageDetailDomain>(cpr))
                                                    .ToListAsync();

            return carePackageDetails;
        }
    }
}
