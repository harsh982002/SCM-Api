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
        /// Get the PurchaseCategory data based on PurchaseCategoryId.
        /// </summary>
        /// <param name="PurchaseCategoryId">PurchaseCategoryId</param>
        /// <returns>The ApiResponse.</returns>
        [HttpGet("/getpurchasecategorybyid/{PurchaseCategoryId}")]
        public async Task<IActionResult> GetPurchaseCategoryById(byte PurchaseCategoryId)
        {
            var PurchaseCategory = await _purchaseCategoryService.GetPurchaseCategoryById(PurchaseCategoryId);
            if (PurchaseCategory == null)
            {
                return NotFound(new ApiResponse(statusCode: HttpStatusCode.NotFound, messages: new List<string> { MessageConstant.RequestnotFound, $"Company of id:{PurchaseCategoryId} doesn't exist!" }));
            }
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: _mapper.Map<PurchaseCategoryModel>(PurchaseCategory)));
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
