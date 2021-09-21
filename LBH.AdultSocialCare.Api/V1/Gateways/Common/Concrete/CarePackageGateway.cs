using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete
{
    public class CarePackageGateway : ICarePackageGateway
    {
        private readonly DatabaseContext _dbContext;

        public CarePackageGateway(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(CarePackage newCarePackage)
        {
            _dbContext.CarePackages.Add(newCarePackage);
        }
    }
}
