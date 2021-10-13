using System;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Common.Exceptions.CustomExceptions;
using FluentAssertions;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Concrete;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.Infrastructure.Entities;
using Xunit;

namespace LBH.AdultSocialCare.Api.Tests.V1.Gateways.Common
{
    public class SupplierGatewayTests : BaseInMemoryDatabaseTest
    {
        private readonly ISupplierGateway _gateway;
        private readonly Faker<Supplier> _supplierFaker;

        public SupplierGatewayTests()
        {
            _gateway = new SupplierGateway(Context, Mapper);
            _supplierFaker = new Faker<Supplier>()
                .RuleFor(s => s.SupplierName, f => f.Company.CompanyName())
                .RuleFor(s => s.PackageTypeId, f => PackageTypesConstants.DayCarePackageId);
        }

        [Fact]
        public async Task UpdateShouldSaveChangesToDatabase()
        {
            var supplier = _supplierFaker.Generate();

            Context.Suppliers.Add(supplier);
            Context.SaveChanges();

            var supplierDomain = supplier.ToDomain();

            supplierDomain.SupplierName = String.Concat(supplier.SupplierName.Reverse());
            supplierDomain.PackageTypeId = PackageTypesConstants.NursingCarePackageId;

            var updatedSupplier = await _gateway.UpdateAsync(supplierDomain).ConfigureAwait(false);

            updatedSupplier.Should()
                .BeEquivalentTo(supplierDomain, config => config
                .Excluding(s => s.UpdaterId)); // just created entity doesn't have UpdaterId
        }

        [Fact]
        public async Task ShouldThrowErrorOnUpdatingNonExistingSupplier()
        {
            var supplier = _supplierFaker.Generate();

            Task Update() => _gateway
                .UpdateAsync(supplier.ToDomain());

            await Assert.ThrowsAsync<EntityNotFoundException>(Update).ConfigureAwait(false);
        }
    }
}
