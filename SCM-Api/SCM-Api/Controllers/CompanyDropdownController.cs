using AutoMapper;
using Common.Constant;
using Common.Helpers;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using Services.Models;
using System.Net;

namespace SCM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDropdownController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyDropdownController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;

        }

        /// <summary>
        /// Get the list of Company for dropdown.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ApiResponse.</returns>
        [HttpGet("/getcompanylist")]
        public async Task<IActionResult> GetCompanyList()
        {
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: await _companyService.GetCompanyList()));
        }
    }
}
