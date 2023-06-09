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

        [HttpGet("/getdepartmentbyid/{DepartmentId}")]
        public async Task<IActionResult> GetDepartmentById(byte DepartmentId)
        {
            var Department = await _departmentService.GetDepartmentDetailById(DepartmentId);
            if (Department == null)
            {
                return NotFound(new ApiResponse(statusCode: HttpStatusCode.NotFound, messages: new List<string> { MessageConstant.RequestnotFound, $"Department of id:{DepartmentId} doesn't exist!" }));
            }
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: _mapper.Map<DepartmentModel>(Department)));
        }

        [HttpGet("/getdepartmentlist")]
        public async Task<IActionResult> GetDepartmentList()
        {
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: await _departmentService.GetDepartmentList()));

        }
    }
}
