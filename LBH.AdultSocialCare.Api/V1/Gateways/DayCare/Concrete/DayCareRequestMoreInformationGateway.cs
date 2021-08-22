using System;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.DayCareBrokerage;

namespace LBH.AdultSocialCare.Api.V1.Gateways.DayCare.Concrete
{
    public class DayCareRequestMoreInformationGateway : IDayCareRequestMoreInformationGateway
    {
        private readonly DatabaseContext _databaseContext;

        public DayCareRequestMoreInformationGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> CreateAsync(DayCareRequestMoreInformation dayCareRequestMoreInformationCreation)
        {
            await _databaseContext.DayCareRequestMoreInformations.AddAsync(dayCareRequestMoreInformationCreation).ConfigureAwait(false);
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
