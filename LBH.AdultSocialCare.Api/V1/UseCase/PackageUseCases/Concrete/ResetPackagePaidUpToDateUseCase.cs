using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.InvoiceDomains;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCarePackageGateways;
using LBH.AdultSocialCare.Api.V1.UseCase.PackageUseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LBH.AdultSocialCare.Api.V1.UseCase.PackageUseCases.Concrete
{
    public class ResetPackagePaidUpToDateUseCase : IResetPackagePaidUpToDateUseCase
    {
        private readonly INursingCarePackageGateway _nursingCarePackageGateway;

        public ResetPackagePaidUpToDateUseCase(INursingCarePackageGateway nursingCarePackageGateway)
        {
            _nursingCarePackageGateway = nursingCarePackageGateway;
        }

        public async Task<bool> ExecuteAsync(List<InvoiceDomain> invoices)
        {
            var nursingCarePackageIds = new List<Guid>();
            var residentialCarePackageIds = new List<Guid>();

            foreach (var invoice in invoices)
            {
                switch (invoice.PackageTypeId)
                {
                    case PackageTypesConstants.NursingCarePackageId:
                        {
                            if (invoice.PackageId != null) nursingCarePackageIds.Add((Guid) invoice.PackageId);
                            break;
                        }
                    case PackageTypesConstants.ResidentialCarePackageId:
                        {
                            if (invoice.PackageId != null) residentialCarePackageIds.Add((Guid) invoice.PackageId);
                            break;
                        }
                }
            }

            nursingCarePackageIds = nursingCarePackageIds.Distinct().ToList();
            residentialCarePackageIds = residentialCarePackageIds.Distinct().ToList();

            // Reset nursing care invoices
            await _nursingCarePackageGateway.ResetInvoicePaidUpToDate(nursingCarePackageIds).ConfigureAwait(false);

            // TODO: Reset residential care invoices

            return true;
        }
    }
}
