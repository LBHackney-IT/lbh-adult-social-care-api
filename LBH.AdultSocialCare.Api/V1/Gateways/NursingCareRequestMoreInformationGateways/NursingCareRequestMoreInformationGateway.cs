using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.NursingCareBrokerage;
using System;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCareRequestMoreInformationGateways
{
    public class NursingCareRequestMoreInformationGateway : INursingCareRequestMoreInformationGateway
    {
        private readonly DatabaseContext _databaseContext;

        public NursingCareRequestMoreInformationGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> CreateAsync(NursingCareRequestMoreInformation nursingCareRequestMoreInformationCreation)
        {
            await _databaseContext.NursingCareRequestMoreInformations.AddAsync(nursingCareRequestMoreInformationCreation).ConfigureAwait(false);
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
