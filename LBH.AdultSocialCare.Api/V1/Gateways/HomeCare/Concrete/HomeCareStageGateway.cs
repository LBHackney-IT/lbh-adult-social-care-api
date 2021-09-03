using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCare.Concrete
{
    public class HomeCareStageGateway : IHomeCareStageGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;

        public HomeCareStageGateway(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<StageDomain>> ListAsync()
        {
            var res = await _databaseContext.PackageStages
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }
    }
}
