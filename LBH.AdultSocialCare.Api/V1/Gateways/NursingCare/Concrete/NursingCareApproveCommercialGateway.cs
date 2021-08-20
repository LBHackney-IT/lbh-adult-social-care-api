using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.NursingCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.NursingCare.Concrete
{
    public class NursingCareApproveCommercialGateway : INursingCareApproveCommercialGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IIdentityHelperUseCase _identityHelperUseCase;

        public NursingCareApproveCommercialGateway(DatabaseContext databaseContext, IIdentityHelperUseCase identityHelperUseCase)
        {
            _databaseContext = databaseContext;
            _identityHelperUseCase = identityHelperUseCase;
        }

        public async Task<NursingCareApproveCommercialDomain> GetAsync(Guid nursingCarePackageId)
        {
            var nursingCarePackage = await _databaseContext.NursingCarePackages
                .Where(item => item.Id == nursingCarePackageId)
                .Include(item => item.NursingCareAdditionalNeeds)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (nursingCarePackage == null)
            {
                throw new ApiException($"Could not find the Nursing Care Package {nursingCarePackageId}");
            }

            var costOfCare = await _databaseContext.NursingCareBrokerageInfos
                .Where(a => a.NursingCarePackageId.Equals(nursingCarePackageId))
                .Select(a => a.NursingCore)
                .SingleOrDefaultAsync().ConfigureAwait(false);

            var costOfAdditionalNeeds = await _databaseContext.NursingCareBrokerageInfos
                .Where(a => a.NursingCarePackageId.Equals(nursingCarePackageId))
                .Select(a => a.AdditionalNeedsPayment)
                .SingleOrDefaultAsync().ConfigureAwait(false);

            var nursingCareApproveCommercialDomain = new NursingCareApproveCommercialDomain()
            {
                NursingCarePackage = nursingCarePackage.ToDomain(),
                CostOfCare = costOfCare,
                CostOfAdditionalNeeds = costOfAdditionalNeeds,
                TotalPerWeek = costOfCare + costOfAdditionalNeeds
            };

            return nursingCareApproveCommercialDomain;
        }

        public async Task<InvoiceDomain> GetInvoiceDetail(Guid nursingCarePackageId)
        {
            var nursingCarePackage = await _databaseContext.NursingCarePackages
                .Where(item => item.Id == nursingCarePackageId)
                .Include(item => item.NursingCareAdditionalNeeds)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (nursingCarePackage == null)
                throw new ApiException($"Could not find the Nursing Care Package {nursingCarePackageId}");

            var nursingCareBrokerage = await _databaseContext.NursingCareBrokerageInfos
                .Where(item => item.NursingCarePackageId == nursingCarePackageId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (nursingCareBrokerage == null)
                throw new ApiException($"Nursing Care Brokerage not completed");

            var additionalNeedsCount = nursingCarePackage.NursingCareAdditionalNeeds.Count;

            var invoiceItems = new List<InvoiceItemDomain>()
            {
                new InvoiceItemDomain()
                {
                    ItemName = "Nursing Care Core",
                    PricePerUnit = nursingCareBrokerage.NursingCore,
                    Quantity = 1,
                    CreatorId = _identityHelperUseCase.GetUserId()
                },
                new InvoiceItemDomain()
                {
                    ItemName = "Additional Needs",
                    PricePerUnit = nursingCareBrokerage.AdditionalNeedsPayment,
                    Quantity = additionalNeedsCount,
                    CreatorId = _identityHelperUseCase.GetUserId()
                }
            };

            if (nursingCareBrokerage.AdditionalNeedsPaymentOneOff > 0)
            {
                var additionalNeedsPaymentOneOff = new InvoiceItemDomain()
                {
                    ItemName = "Additional Needs One Off",
                    PricePerUnit = nursingCareBrokerage.AdditionalNeedsPaymentOneOff,
                    Quantity = 1,
                    CreatorId = _identityHelperUseCase.GetUserId()
                };
                invoiceItems.Add(additionalNeedsPaymentOneOff);
            }

            var invoiceDomain = new InvoiceDomain
            {
                SupplierId = nursingCarePackage.SupplierId,
                PackageTypeId = PackageTypesConstants.NursingCarePackageId,
                ServiceUserId = nursingCarePackage.ClientId,
                InvoiceItems = invoiceItems,
                CreatorId = _identityHelperUseCase.GetUserId()
            };

            return invoiceDomain;
        }
    }
}
