using Common.Constant;
using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using System.Net;

namespace SCM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        /// <summary>
        /// Get the list of departments for dropdown.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ApiResponse.</returns>
        [HttpGet("GetDepartmentList")]
        public async Task<IActionResult> GetDepartmentList()
        {
            return Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, await _departmentService.GetDepartmentList()));
        }
    }
}
