namespace SCM_Api.Controllers
{
    using AutoMapper;
    using Common.Constant;
    using Common.Helpers;
    using Data.Entities;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contract;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class SbdDocumentController : ControllerBase
    {
        private readonly ISbdDocumentService _sbdDocumentService;
        private readonly IMapper _mapper;

        public SbdDocumentController(ISbdDocumentService sbdDocumentService, IMapper mapper)
        {
            _sbdDocumentService = sbdDocumentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get SbdDocument data by Id.
        /// </summary>
        /// <param name="sbdDocumentId"></param>
        /// <returns>The ApiResponse</returns>
        [HttpGet("GetSbdDocumentById/{sbdDocumentId}")]
        public async Task<IActionResult> GetSbdDocumentById(int sbdDocumentId)
        {
            SbdDocument? sbdDocument = await _sbdDocumentService.GetById(sbdDocumentId);
            if(sbdDocument == null)
            {
                return Ok(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"SbdDocument data not found." }, sbdDocumentId));
            }

            return Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, sbdDocument));
        }
    }
}
