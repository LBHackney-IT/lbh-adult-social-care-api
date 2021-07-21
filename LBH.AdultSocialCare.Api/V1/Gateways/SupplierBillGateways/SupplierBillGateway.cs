using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Common.Exceptions.CustomExceptions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Domain.BillDomains;
using LBH.AdultSocialCare.Api.V1.Exceptions;
using LBH.AdultSocialCare.Api.V1.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Extensions;

namespace LBH.AdultSocialCare.Api.V1.Gateways.SupplierBillGateways
{
    public class SupplierBillGateway : ISupplierBillGateway
    {
        private readonly DatabaseContext _databaseContext;

        public SupplierBillGateway(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<SupplierBillDomain> GetSupplierBill(Guid packageId)
        {
            return await GetPackageDetails(packageId).ConfigureAwait(false);
        }

        private async Task<SupplierBillDomain> GetPackageDetails(Guid packageId)
        {
            if (await CheckDayCarePackage(packageId)
                .ConfigureAwait(false) > 0)
                return await GetDayCarePackageDetail(packageId).ConfigureAwait(false);
            else if (await CheckEscortPackage(packageId)
                .ConfigureAwait(false) > 0)
                return await GetEscortPackageDetail(packageId).ConfigureAwait(false);
            else if (await CheckTransportPackage(packageId)
                .ConfigureAwait(false) > 0)
                return await GetTransportPackageDetail(packageId).ConfigureAwait(false);
            else if (await CheckTransportEscortPackage(packageId)
                .ConfigureAwait(false) > 0)
                return await GetTransportEscortPackageDetail(packageId).ConfigureAwait(false);
            else
                throw new EntityNotFoundException($"Package with id {packageId} not found");
        }

        private async Task<int> CheckDayCarePackage(Guid packageId)
        {
            return await _databaseContext.DayCarePackages
                .CountAsync(item => item.DayCarePackageId == packageId)
                .ConfigureAwait(false);
        }

        private async Task<int> CheckEscortPackage(Guid packageId)
        {
            return await _databaseContext.EscortPackages
                .CountAsync(item => item.EscortPackageId == packageId)
                .ConfigureAwait(false);
        }

        private async Task<int> CheckTransportPackage(Guid packageId)
        {
            return await _databaseContext.TransportPackages
                .CountAsync(item => item.TransportPackageId == packageId)
                .ConfigureAwait(false);
        }

        private async Task<int> CheckTransportEscortPackage(Guid packageId)
        {
            return await _databaseContext.TransportEscortPackages
                .CountAsync(item => item.TransportEscortPackageId == packageId)
                .ConfigureAwait(false);
        }

        private async Task<SupplierBillDomain> GetDayCarePackageDetail(Guid packageId)
        {
            var dayCarePackage = await _databaseContext.DayCarePackages
                .Where(item => item.DayCarePackageId == packageId)
                .Include(item => item.Client)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            var dayCarePackageDetail = await _databaseContext.DayCareBrokerageInfo
                .Where(dc => dc.DayCarePackageId.Equals(packageId))
                .Include(item => item.CorePackageSupplier)
                .FirstOrDefaultAsync().ConfigureAwait(false);

            var supplierBillItem = new List<SupplierBillItemDomain>()
            {
                new SupplierBillItemDomain()
                {
                    ItemName = "Day Care Core",
                    ItemDescription = "Day Care Core",
                    CostCentre = "Day Care Centre",
                    TaxRatePercentage = 0,
                    UnitPrice = dayCarePackageDetail.CorePackageCostPerDay
                },
                new SupplierBillItemDomain()
                {
                    ItemName = "Day Care Opportunities",
                    ItemDescription = "Day Care Opportunities",
                    CostCentre = "Day Care Centre",
                    TaxRatePercentage = 0,
                    UnitPrice = dayCarePackageDetail.DayCareOpportunitiesCostPerHour
                }
            };

            return new SupplierBillDomain()
            {
                SupplierName = dayCarePackageDetail.CorePackageSupplier.SupplierName,
                BillTitle = dayCarePackage.Client != null ? $"Day Care Invoice from {dayCarePackageDetail.CorePackageSupplier.SupplierName} For {dayCarePackage.Client.FirstName} {dayCarePackage.Client.MiddleName} {dayCarePackage.Client.LastName}" : null,
                SupplierBillItem = supplierBillItem
            };
        }

        private async Task<SupplierBillDomain> GetEscortPackageDetail(Guid packageId)
        {
            var escortPackage = await _databaseContext.EscortPackages
                .Where(item => item.EscortPackageId == packageId)
                .Include(item => item.Client)
                .Include(item => item.Supplier)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            var supplierBillItem = new List<SupplierBillItemDomain>()
            {
                new SupplierBillItemDomain()
                {
                    ItemName = "Escort",
                    ItemDescription = "Escort Package Core",
                    CostCentre = escortPackage.Destination,
                    TaxRatePercentage = 0,
                    UnitPrice = escortPackage.EscortCostPerHour
                }
            };

            return new SupplierBillDomain()
            {
                SupplierName = escortPackage.Supplier.SupplierName,
                BillTitle = escortPackage.Client != null ? $"Escort Care Invoice from {escortPackage.Supplier.SupplierName} For {escortPackage.Client.FirstName} {escortPackage.Client.MiddleName} {escortPackage.Client.LastName}" : null,
                SupplierBillItem = supplierBillItem
            };
        }

        private async Task<SupplierBillDomain> GetTransportPackageDetail(Guid packageId)
        {
            var transportPackage = await _databaseContext.TransportPackages
                .Where(item => item.TransportPackageId == packageId)
                .Include(item => item.Client)
                .Include(item => item.Supplier)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            var supplierBillItem = new List<SupplierBillItemDomain>()
            {
                new SupplierBillItemDomain()
                {
                    ItemName = "Transport Care",
                    ItemDescription = "Transport Care Core",
                    CostCentre = transportPackage.Destination,
                    TaxRatePercentage = 0,
                    UnitPrice = transportPackage.TransportCostPerDay
                }
            };

            return new SupplierBillDomain()
            {
                SupplierName = transportPackage.Supplier.SupplierName,
                BillTitle = transportPackage.Client != null ? $"Transport Care Invoice from {transportPackage.Supplier.SupplierName} For {transportPackage.Client.FirstName} {transportPackage.Client.MiddleName} {transportPackage.Client.LastName}" : null,
                SupplierBillItem = supplierBillItem
            };
        }

        private async Task<SupplierBillDomain> GetTransportEscortPackageDetail(Guid packageId)
        {
            var transportEscortPackage = await _databaseContext.TransportEscortPackages
                .Where(item => item.TransportEscortPackageId == packageId)
                .Include(item => item.Client)
                .Include(item => item.Supplier)
                .FirstOrDefaultAsync()
                .ConfigureAwait(false);

            var supplierBillItem = new List<SupplierBillItemDomain>()
            {
                new SupplierBillItemDomain()
                {
                    ItemName = "Day Care Core",
                    ItemDescription = "Day Care Core",
                    CostCentre = transportEscortPackage.Destination,
                    TaxRatePercentage = 0,
                    UnitPrice = transportEscortPackage.TransportEscortCostPerWeek
                }
            };

            return new SupplierBillDomain()
            {
                SupplierName = transportEscortPackage.Supplier.SupplierName,
                BillTitle = transportEscortPackage.Client != null ? $"Day Care Invoice from {transportEscortPackage.Supplier.SupplierName} For {transportEscortPackage.Client.FirstName} {transportEscortPackage.Client.MiddleName} {transportEscortPackage.Client.LastName}" : null,
                SupplierBillItem = supplierBillItem
            };
        }
    }
}
