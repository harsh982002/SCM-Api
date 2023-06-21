namespace SCM_Api.Controllers
{
    using AutoMapper;
    using Common.Constant;
    using Common.Helpers;
    using Data.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using Services.Contract;
    using Services.Models;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class BidSbdDocumentController : ControllerBase
    {
        private readonly IBidSbdDocumentService _bidSbdDocumentService;
        private readonly ISbdDocumentService _sbdDocumentService;
        private readonly IMapper _mapper;

        public BidSbdDocumentController(IBidSbdDocumentService bidSbdDocumentService, IMapper mapper, ISbdDocumentService sbdDocumentService)
        {
            _bidSbdDocumentService = bidSbdDocumentService;
            _sbdDocumentService = sbdDocumentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get BidSbdDocument data by Id.
        /// </summary>
        /// <param name="bidSbdDocumentId"></param>
        /// <returns>The Api Response.</returns>
        [HttpGet("GetBidSbdDocumentById/{bidSbdDocumentId}")]
        public async Task<IActionResult> GetBidSbdDocumentById(int bidSbdDocumentId)
        {
            BidSbdDocument? bidSbdDocument = await _bidSbdDocumentService.GetById(bidSbdDocumentId);
            if (bidSbdDocument == null)
            {
                return this.Ok(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"BidSbdDocument data not found." }, bidSbdDocumentId));
            }

            return Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, bidSbdDocument));
        }

        /// <summary>
        /// Add/Update BidSbdDocument Data.
        /// </summary>
        /// <param name="model"></param>
        /// <returns>The Api Response.</returns>
        [HttpPost("AddUpdate")]
        public async Task<IActionResult> AddUpdate(BidSbdDocumentModel model)
        {
            BidSbdDocument bidSbdDocument = _mapper.Map<BidSbdDocument>(model);

            List<object> sbdDocumentValueList = new();
            if (model.SbdDocumentValue != null && model.SbdDocumentValue.Any())
            {
                foreach (SbdBidDocumentValueJsonModel sbdDocumentValue in model.SbdDocumentValue)
                {
                    sbdDocumentValueList.Add(new
                    {
                        name = sbdDocumentValue?.Name,
                        value = sbdDocumentValue?.Value?.ToString(),
                        controlType = sbdDocumentValue?.ControlType
                    });
                }

                bidSbdDocument.SbdDocumentValue = JsonConvert.SerializeObject(sbdDocumentValueList);
            }
            else if (model.SbdDocumentValue is null)
            {
                SbdDocument? sbdDocument = await _sbdDocumentService.GetById(bidSbdDocument.SbdDocumentId);
                if (sbdDocument != null)
                { 
                    bidSbdDocument.SbdDocumentValue = sbdDocument.JsonFormatString;
                }
            }

            int bidSbdDocumentId = await _bidSbdDocumentService.SaveUpdate(bidSbdDocument);
            return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, bidSbdDocumentId));
        }
    }
}
