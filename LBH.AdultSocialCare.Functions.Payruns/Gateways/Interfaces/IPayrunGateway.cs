using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Data.Entities.Payments;

namespace LBH.AdultSocialCare.Functions.Payruns.Gateways.Interfaces
{
    public interface IPayrunGateway : IGateway
    {
        Task<IList<Payrun>> GetDraftPayrunsAsync();
    }
}
