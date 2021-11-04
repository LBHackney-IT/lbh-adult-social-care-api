using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.AppConstants.Enums;
using Common.Extensions;
using HttpServices.Models.Features;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Boundary.Common.Response;
using LBH.AdultSocialCare.Api.V1.Boundary.PayRuns.Response;
using LBH.AdultSocialCare.Api.V1.Infrastructure.RequestFeatures.Parameters;
using LBH.AdultSocialCare.Api.V1.UseCase.Payments.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Payments.Concrete
{
    public class GetPayRunListUseCase : IGetPayRunListUseCase
    {
        public async Task<PagedResponse<PayRunListResponse>> GetPayRunList(PayRunListParameters parameters)
        {
            var result = new PagedResponse<PayRunListResponse>
            {
                PagingMetaData =
                    new PagingMetaData
                    {
                        CurrentPage = 1,
                        TotalPages = 1,
                        PageSize = 1,
                        TotalCount = 1
                    },
                Data = new List<PayRunListResponse>()
                {
                    new PayRunListResponse
                    {
                        PayRunId = Guid.NewGuid(),
                        PayRunTypeId = (int) PayrunType.ResidentialRecurring,
                        PayRunTypeName = PayrunType.ResidentialRecurring.ToDescription(),
                        PayRunStatusId = (int) PayrunStatus.Approved,
                        PayRunStatusName = PayrunStatus.Approved.GetDisplayName(),
                        TotalAmountPaid = 25000M,
                        TotalAmountHeld = 0,
                        DateFrom = DateTimeOffset.Now.AddYears(-10),
                        DateTo = DateTimeOffset.Now.AddYears(-1),
                        DateCreated = DateTimeOffset.Now.AddDays(-1),
                    }
                }
            };

            return await Task.FromResult(result);
        }
    }
}
