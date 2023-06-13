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
    public class DepartmentDropdownController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;

        public DepartmentDropdownController(IDepartmentService departmentService,IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get the list of departments for dropdown.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ApiResponse.</returns>
        [HttpGet("/getdepartmentlist")]
        public async Task<IActionResult> GetDepartmentList()
        {
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: await _departmentService.GetDepartmentList()));

        }
    }
}
