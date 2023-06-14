﻿using Common.Constant;
using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using System.Net;

namespace SCM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReasonCodeController : ControllerBase
    {
        private readonly IReasonCodeService _reasonCodeService;

        public ReasonCodeController(IReasonCodeService reasonCodeService)
        {
            _reasonCodeService = reasonCodeService;
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
