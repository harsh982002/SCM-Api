using Common.Constant;
using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using System.Net;

namespace SCM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseCategoryController : ControllerBase
    {
        private readonly IPurchaseCategoryService _purchaseCategoryService;

        public PurchaseCategoryController(IPurchaseCategoryService purchaseCategoryService)
        {
            _purchaseCategoryService = purchaseCategoryService;
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
