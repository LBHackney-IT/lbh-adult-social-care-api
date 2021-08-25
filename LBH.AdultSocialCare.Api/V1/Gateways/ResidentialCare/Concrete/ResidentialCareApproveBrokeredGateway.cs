using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Domain.ResidentialCare;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using LBH.AdultSocialCare.Api.V1.UseCase.Security.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LBH.AdultSocialCare.Api.V1.Gateways.ResidentialCare.Concrete
{
    public class ResidentialCareApproveBrokeredGateway : IResidentialCareApproveBrokeredGateway
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IIdentityHelperUseCase _identityHelperUseCase;

        public ResidentialCareApproveBrokeredGateway(DatabaseContext databaseContext, IIdentityHelperUseCase identityHelperUseCase)
        {
            _databaseContext = databaseContext;
            _identityHelperUseCase = identityHelperUseCase;
        }

        public async Task<ResidentialCareApproveBrokeredDomain> GetAsync(Guid residentialCarePackageId)
        {
            var residentialCarePackage = await _databaseContext.ResidentialCarePackages
                .Where(item => item.Id == residentialCarePackageId)
                .Include(item => item.ResidentialCareAdditionalNeeds)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (residentialCarePackage == null)
            {
                throw new ApiException($"Could not find the Residential Care Package {residentialCarePackageId}");
            }

            var costOfCare = await _databaseContext.ResidentialCareBrokerageInfos
                .Where(a => a.ResidentialCarePackageId.Equals(residentialCarePackageId))
                .Select(a => a.ResidentialCore)
                .SingleOrDefaultAsync().ConfigureAwait(false);

            var costOfAdditionalNeeds = await _databaseContext.ResidentialCareBrokerageInfos
                .Where(a => a.ResidentialCarePackageId.Equals(residentialCarePackageId))
                .Select(a => a.AdditionalNeedsPayment)
                .SingleOrDefaultAsync().ConfigureAwait(false);

            var residentialCareApproveBrokeredDomain = new ResidentialCareApproveBrokeredDomain()
            {
                ResidentialCarePackage = residentialCarePackage.ToDomain(),
                CostOfCare = costOfCare,
                CostOfAdditionalNeeds = costOfAdditionalNeeds,
                TotalPerWeek = costOfCare + costOfAdditionalNeeds
            };

            return residentialCareApproveBrokeredDomain;
        }

        public async Task<InvoiceDomain> GetInvoiceDetail(Guid residentialCarePackageId)
        {
            var residentialCarePackage = await _databaseContext.ResidentialCarePackages
                .Where(item => item.Id == residentialCarePackageId)
                .Include(item => item.ResidentialCareAdditionalNeeds)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (residentialCarePackage == null)
                throw new ApiException($"Could not find the Residential Care Package {residentialCarePackageId}");

            var residentialCareBrokerage = await _databaseContext.ResidentialCareBrokerageInfos
                .Where(item => item.ResidentialCarePackageId == residentialCarePackageId)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            if (residentialCareBrokerage == null)
                throw new ApiException($"Residential Care Brokerage not completed");

            var additionalNeedsCount = residentialCarePackage.ResidentialCareAdditionalNeeds.Count;

            var invoiceItems = new List<InvoiceItemDomain>()
            {
                new InvoiceItemDomain()
                {
                    ItemName = "Residential Care Core",
                    PricePerUnit = residentialCareBrokerage.ResidentialCore,
                    Quantity = 1,
                    CreatorId = _identityHelperUseCase.GetUserId()
                },
                new InvoiceItemDomain()
                {
                    ItemName = "Additional Needs",
                    PricePerUnit = residentialCareBrokerage.AdditionalNeedsPayment,
                    Quantity = additionalNeedsCount,
                    CreatorId = _identityHelperUseCase.GetUserId()
                }
            };

            if (residentialCareBrokerage.AdditionalNeedsPaymentOneOff > 0)
            {
                var additionalNeedsPaymentOneOff = new InvoiceItemDomain()
                {
                    ItemName = "Additional Needs One Off",
                    PricePerUnit = residentialCareBrokerage.AdditionalNeedsPaymentOneOff,
                    Quantity = 1,
                    CreatorId = _identityHelperUseCase.GetUserId()
                };
                invoiceItems.Add(additionalNeedsPaymentOneOff);
            }

            var invoiceDomain = new InvoiceDomain
            {
                SupplierId = residentialCarePackage.SupplierId,
                PackageTypeId = PackageTypesConstants.ResidentialCarePackageId,
                ServiceUserId = residentialCarePackage.ClientId,
                InvoiceItems = invoiceItems,
                CreatorId = _identityHelperUseCase.GetUserId()
            };

            return invoiceDomain;
        }
    }
}