using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.V1.Boundary.ApprovedPackagesBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Factories;
using LBH.AdultSocialCare.Api.V1.Gateways.ApprovedPackagesGateways;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestExtensions;
using LBH.AdultSocialCare.Api.V1.UseCase.ApprovedPackagesUseCases.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.ApprovedPackagesUseCases.Concrete
{
    public class GetApprovedPackagesUseCase : IGetApprovedPackagesUseCase
    {
        private readonly IApprovedPackagesGateway _approvedPackagesGateway;

        public GetApprovedPackagesUseCase(IApprovedPackagesGateway approvedPackagesGateway)
        {
            _approvedPackagesGateway = approvedPackagesGateway;
        }

        public async Task<PagedApprovedPackagesResponse> GetApprovedPackages(ApprovedPackagesParameters parameters, int statusId)
        {
            var result = await _approvedPackagesGateway.GetApprovedPackages(parameters, statusId).ConfigureAwait(false);
            return new PagedApprovedPackagesResponse()
            {
                PagingMetaData = result.PagingMetaData,
                Data = result.ToResponse()
            };
        }
    }
}
