using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities.Common;

namespace LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces
{
    public interface ICarePackageGateway
    {
        void Create(CarePackage newCarePackage);
    }
}
