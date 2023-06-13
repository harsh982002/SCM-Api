using AutoMapper;
using Common.Constant;
using Common.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using Services.Models;
using System.Net;

namespace SCM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReasonCodeDropdownController : ControllerBase
    {
        private readonly IReasonCodeService _reasonCodeService;
        private readonly IMapper _mapper;

        public ReasonCodeDropdownController(IReasonCodeService reasonCodeService,IMapper mapper)
        {
            _reasonCodeService = reasonCodeService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get the ReasonCode data based on ReasonCodeId.
        /// </summary>
        /// <param name="ReasonCodeId">ReasonCodeId</param>
        /// <returns>The ApiResponse.</returns>
        [HttpGet("/getreasoncodebyid/{ReasonCodeId}")]
        public async Task<IActionResult> GetReasonCodebyId(byte ReasonCodeId)
        {
            var ReasonCode = await _reasonCodeService.GetReasonCodeById(ReasonCodeId);
            if (ReasonCode == null)
            {
                return NotFound(new ApiResponse(statusCode: HttpStatusCode.NotFound, messages: new List<string> { MessageConstant.RequestnotFound, $"ReasonCode of id:{ReasonCodeId} doesn't exist!" }));
            }
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: _mapper.Map<ReasonCodeModel>(ReasonCode)));
        }

        /// <summary>
        /// Get the list of ReasonCodes for dropdown.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ApiResponse.</returns>
        [HttpGet("/getresoncodelist")]
        public async Task<IActionResult> GetReasonCodeList()
        {
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: await _reasonCodeService.GetReasonCodeList()));
        }
    }
}
