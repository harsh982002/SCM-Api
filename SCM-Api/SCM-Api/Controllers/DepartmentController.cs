namespace SCM_Api.Controllers
{
    using Common.Helpers;
    using Microsoft.AspNetCore.Mvc;
    using Services.Contract;
    using System.Net;

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
            return Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { Common.Constant.MessageConstant.RequestSuccessful }, await _departmentService.GetDepartmentList()));
        }
    }
}
