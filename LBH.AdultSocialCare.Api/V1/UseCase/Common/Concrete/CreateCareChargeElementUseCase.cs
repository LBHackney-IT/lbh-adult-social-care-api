using System.Threading.Tasks;
using LBH.AdultSocialCare.Api.Helpers;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.AppConstants.Enums;
using LBH.AdultSocialCare.Api.V1.Domain.Common;
using LBH.AdultSocialCare.Api.V1.Gateways.Common.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.Common.Interfaces;

namespace LBH.AdultSocialCare.Api.V1.UseCase.Common.Concrete
{
    public class CreateCareChargeElementUseCase : ICreateCareChargeElementUseCase
    {
        private readonly ICareChargesGateway _gateway;

        internal ICurrentDateTimeOffsetProvider DateTimeProvider { get; set; } = new CurrentDateTimeOffsetProvider();

        public CreateCareChargeElementUseCase(ICareChargesGateway gateway)
        {
            _gateway = gateway;
        }
        public async Task<CareChargeElementPlainDomain> ExecuteAsync(CareChargeElementPlainDomain element)
        {
            element.StatusId ??= CalculateElementStatus(element);

            return await _gateway.CreateCareChargeElementAsync(element).ConfigureAwait(false);
        }

        private int CalculateElementStatus(CareChargeElementPlainDomain element)
        {
            int statusId;

            // TODO: VK: Active and Future seems to be UI-calculated statuses
            if (element.StartDate <= DateTimeProvider.Now)
            {
                if (element.EndDate is null || element.EndDate > DateTimeProvider.Now)
                {
                    statusId = (int) CareChargeElementStatusEnum.Active;
                }
                else
                {
                    statusId = (int) CareChargeElementStatusEnum.Ended;
                }
            }
            else
            {
                statusId = (int) CareChargeElementStatusEnum.Future;
            }

            return statusId;
        }
    }
}
