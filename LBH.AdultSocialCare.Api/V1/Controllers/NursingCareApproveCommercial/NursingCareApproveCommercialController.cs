using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HttpServices.Models.Requests;
using HttpServices.Services.Contracts;
using LBH.AdultSocialCare.Api.V1.AppConstants;
using LBH.AdultSocialCare.Api.V1.Boundary.NursingCareApproveCommercialBoundary.Response;
using LBH.AdultSocialCare.Api.V1.Extensions;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareApproveCommercialUseCase.Interfaces;
using LBH.AdultSocialCare.Api.V1.UseCase.NursingCareUseCases.Interfaces;
using Microsoft.AspNetCore.Http;

namespace LBH.AdultSocialCare.Api.V1.Controllers.NursingCareApproveCommercial
{
    [Route("api/v1/nursing-care-packages/{nursingCarePackageId}/approve-commercials")]
    [Produces("application/json")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    [ApiVersion("1.0")]
    public class NursingCareApproveCommercialController : Controller
    {
        private readonly IGetNursingCareApproveCommercialUseCase _getNursingCareApproveCommercialUseCase;
        private readonly IChangeStatusNursingCarePackageUseCase _changeStatusNursingCarePackageUseCase;
        private readonly IGetNursingCareInvoiceDetailUseCase _getNursingCareInvoiceDetailUseCase;
        private readonly ITransactionsService _transactionsService;
        private readonly IMapper _mapper;

        public NursingCareApproveCommercialController(IGetNursingCareApproveCommercialUseCase getNursingCareApproveCommercialUseCase,
            IChangeStatusNursingCarePackageUseCase changeStatusNursingCarePackageUseCase,
            IGetNursingCareInvoiceDetailUseCase getNursingCareInvoiceDetailUseCase,
            ITransactionsService transactionsService,
            IMapper mapper)
        {
            _getNursingCareApproveCommercialUseCase = getNursingCareApproveCommercialUseCase;
            _changeStatusNursingCarePackageUseCase = changeStatusNursingCarePackageUseCase;
            _getNursingCareInvoiceDetailUseCase = getNursingCareInvoiceDetailUseCase;
            _transactionsService = transactionsService;
            _mapper = mapper;
        }

        /// <summary>Gets the specified nursing care approve commercials contents identifier.</summary>
        /// <param name="nursingCarePackageId">The nursing care package identifier.</param>
        /// <returns>The nursing care approve commercials contents response.</returns>
        [HttpGet]
        public async Task<ActionResult<NursingCareApproveCommercialResponse>> GetNursingCareApproveCommercials(Guid nursingCarePackageId)
        {
            var nursingCareApproveCommercialResponse = await _getNursingCareApproveCommercialUseCase.Execute(nursingCarePackageId).ConfigureAwait(false);
            return Ok(nursingCareApproveCommercialResponse);
        }

        [HttpPut]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<bool>> ApprovePackage(Guid nursingCarePackageId)
        {
            var result = await _changeStatusNursingCarePackageUseCase.UpdateAsync(nursingCarePackageId, ApprovalHistoryConstants.PackageBrokeredId).ConfigureAwait(false);
            //TODO: get invoice detail and create pay run invoice
            var invoiceResponse = await _getNursingCareInvoiceDetailUseCase.GetNursingCareInvoiceDetail(nursingCarePackageId).ConfigureAwait(false);
            //create an invoice
            var invoiceCreationRequest = new InvoiceForCreationRequest();
            _mapper.Map(invoiceResponse, invoiceCreationRequest);
            await _transactionsService.CreateInvoiceUseCase(invoiceCreationRequest).ConfigureAwait(false);
            return Ok(result);
        }
    }
}
