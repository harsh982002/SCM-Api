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
    public class PurchaseCategoryDropdownController : ControllerBase
    {
        private readonly IPurchaseCategoryService _purchaseCategoryService;
        private readonly IMapper _mapper;

        public PurchaseCategoryDropdownController(IPurchaseCategoryService purchaseCategoryService,IMapper mapper)
        {
            _purchaseCategoryService = purchaseCategoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get the list of PurchaseCategory for dropdown.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ApiResponse.</returns>
        [HttpGet("/getpurchasecategorylist")]
        public async Task<IActionResult> GetPurchaseCategoryList()
        {
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: await _purchaseCategoryService.GetPurchaseCategoryList()));
        }
    }
}
