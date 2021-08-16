using LBH.AdultSocialCare.Api.V1.Domain.InvoiceDomains;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.PackageUseCases.Interfaces
{
    public interface IResetPackagePaidUpToDateUseCase
    {
        Task<bool> ExecuteAsync(List<InvoiceDomain> invoices);
    }
}
