using System.Collections.Generic;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Domain.Common;

namespace LBH.AdultSocialCare.Api.V1.UseCase.PackageUseCases.Interfaces
{
    public interface IResetPackagePaidUpToDateUseCase
    {
        Task<bool> ExecuteAsync(List<InvoiceForResetDomain> invoiceForResetDomains);
    }
}
