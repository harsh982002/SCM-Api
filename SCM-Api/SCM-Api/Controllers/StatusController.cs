﻿namespace SCM_Api.Controllers
{
    using Common.Constant;
    using Common.Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contract;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;
        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        /// <summary>
        /// Get the list of Status for dropdown.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ApiResponse.</returns>
        [HttpGet("GetStatusList")]
        public async Task<IActionResult> GetStatusList()
        {
            return Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, await _statusService.GetStatusList()));
        }
    }
}
