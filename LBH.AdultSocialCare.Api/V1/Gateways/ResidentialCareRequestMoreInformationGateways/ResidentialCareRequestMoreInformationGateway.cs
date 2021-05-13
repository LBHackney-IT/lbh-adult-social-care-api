using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.ResidentialCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCareRequestMoreInformationGateways
{
    public class ResidentialCareRequestMoreInformationGateway : IResidentialCareRequestMoreInformationGateway
    {
        private readonly DatabaseContext _databaseContext;

        public ResidentialCareRequestMoreInformationGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> CreateAsync(ResidentialCareRequestMoreInformation residentialCareRequestMoreInformationCreation)
        {
            await _databaseContext.ResidentialCareRequestMoreInformations.AddAsync(residentialCareRequestMoreInformationCreation).ConfigureAwait(false);
            try
            {
                var isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
                return isSuccess;
            }
            catch (Exception)
            {
                throw new DbSaveFailedException("Could not save Request More Information to database");
            }
        }
    }
}
