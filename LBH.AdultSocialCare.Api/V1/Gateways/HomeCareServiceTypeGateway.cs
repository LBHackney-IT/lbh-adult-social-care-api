using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Gateways.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.Gateways
{

    public class HomeCareServiceTypeGateway : IHomeCareServiceTypeGateway
    {

        private readonly DatabaseContext _databaseContext;

        public HomeCareServiceTypeGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> DeleteAsync(Guid serviceId)
        {
            _databaseContext.HomeCareServiceTypes.Remove(new HomeCareServiceType
            {
                Id = serviceId
            });

            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;

            return isSuccess;
        }

        public async Task<HomeCareServiceType> GetAsync(Guid serviceId)
        {
            var result = await _databaseContext.HomeCareServiceTypes.FirstOrDefaultAsync(item => item.Id == serviceId)
                .ConfigureAwait(false);

            return result;
        }

        public async Task<IList<HomeCareServiceType>> ListAsync()
        {
            return await _databaseContext.HomeCareServiceTypes.ToListAsync().ConfigureAwait(false);
        }

        public async Task<HomeCareServiceType> UpsertAsync(HomeCareServiceType service)
        {
            HomeCareServiceType serviceToUpdate = await _databaseContext.HomeCareServiceTypes
                .FirstOrDefaultAsync(item => item.ServiceName == service.ServiceName)
                .ConfigureAwait(false);

            if (serviceToUpdate == null)
            {
                serviceToUpdate = new HomeCareServiceType
                {
                    ServiceName = service.ServiceName,
                    CreatorId = service.CreatorId,
                    UpdatorId = service.UpdatorId,
                    DateUpdated = service.DateUpdated
                };

                await _databaseContext.HomeCareServiceTypes.AddAsync(serviceToUpdate).ConfigureAwait(false);
            }
            else
            {
                throw new ErrorException($"This record already exist Service Name: {service.ServiceName}");
            }

            await _databaseContext.SaveChangesAsync().ConfigureAwait(false);

            return serviceToUpdate;
        }

    }

}