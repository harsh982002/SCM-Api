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

        [HttpGet("/getcompanybyid/{CompanyId}")]
        public async Task<IActionResult> GetCompanyById(byte CompanyId)
        {
            var company = await _companyService.GetCompanyDetailById(CompanyId);
            if(company == null)
            {
                return NotFound(new ApiResponse(statusCode: HttpStatusCode.NotFound,messages: new List<string> { MessageConstant.RequestnotFound,$"Company of id:{CompanyId} doesn't exist!"}));
            }
            return Ok(new ApiResponse (statusCode: HttpStatusCode.OK,messages: new List<string> {MessageConstant.RequestSuccessful},result: _mapper.Map<CompanyModel>(company)));
        }

        [HttpGet("/getcompanylist")]
        public async Task<IActionResult> GetCompanyList()
        {
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: await _companyService.GetCompanyList()));
        }
    }
}
