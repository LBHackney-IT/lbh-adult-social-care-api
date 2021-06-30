using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.HomeCareBrokerage;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.HomeCareRequestMoreInformationGateways
{
    public class HomeCareRequestMoreInformationGateway : IHomeCareRequestMoreInformationGateway
    {
        private readonly DatabaseContext _databaseContext;

        public HomeCareRequestMoreInformationGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> CreateAsync(HomeCareRequestMoreInformation homeCareRequestMoreInformationCreation)
        {
            await _databaseContext.HomeCareRequestMoreInformations.AddAsync(homeCareRequestMoreInformationCreation).ConfigureAwait(false);
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
