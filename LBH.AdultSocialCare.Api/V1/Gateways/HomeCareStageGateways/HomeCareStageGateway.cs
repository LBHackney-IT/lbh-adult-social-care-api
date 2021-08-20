using AutoMapper;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCareStageGateways
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
            var res = await _databaseContext.HomeCareStages
                .ToListAsync().ConfigureAwait(false);
            return res?.ToDomain();
        }
    }
}
