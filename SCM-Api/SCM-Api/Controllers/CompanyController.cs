namespace SCM_Api.Controllers
{
    using Common.Constant;
    using Common.Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contract;
    using System.Net;

    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        /// <summary>
        /// Get the list of Company for dropdown.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ApiResponse.</returns>
        [HttpGet("GetCompanyList")]
        public async Task<IActionResult> GetCompanyList()
        {
            return Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, await _companyService.GetCompanyList()));
        }
    }
}
