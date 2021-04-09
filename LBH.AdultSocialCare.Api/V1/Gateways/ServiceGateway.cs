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
    public class ServiceGateway : IServiceGateway
    {
        private readonly DatabaseContext _databaseContext;

        public ServiceGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<bool> DeleteAsync(Guid serviceId)
        {
            var result = _databaseContext.PackageServices.Remove(new PackageServices() { Id = serviceId });
            bool isSuccess = await _databaseContext.SaveChangesAsync().ConfigureAwait(false) == 1;
            return isSuccess;
        }

        public async Task<PackageServices> GetAsync(Guid serviceId)
        {
            var result = await _databaseContext.PackageServices.FirstOrDefaultAsync(item => item.Id == serviceId).ConfigureAwait(false);
            result.Package = await _databaseContext.Packages.FirstOrDefaultAsync(item => item.Id == result.PackageId).ConfigureAwait(false);
            return result;
        }

        public async Task<IList<PackageServices>> ListAsync()
        {
            return await _databaseContext.GetServicesAsync().ConfigureAwait(false);
        }

        public async Task<PackageServices> UpsertAsync(PackageServices service)
        {
            PackageServices serviceToUpdate = await _databaseContext.PackageServices.FirstOrDefaultAsync(item => item.ServiceName == service.ServiceName).ConfigureAwait(false);
            if (serviceToUpdate == null)
            {
                serviceToUpdate = new PackageServices();
                await _databaseContext.PackageServices.AddAsync(serviceToUpdate).ConfigureAwait(false);
                serviceToUpdate.ServiceName = service.ServiceName;
                serviceToUpdate.PackageId = service.PackageId;
                serviceToUpdate.Package = await _databaseContext.Packages.FirstOrDefaultAsync(item => item.Id == service.PackageId).ConfigureAwait(false);
                serviceToUpdate.CreatorId = service.CreatorId;
                serviceToUpdate.DateCreated = service.DateCreated;
                serviceToUpdate.UpdatorId = service.UpdatorId;
                serviceToUpdate.DateUpdated = service.DateUpdated;
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
