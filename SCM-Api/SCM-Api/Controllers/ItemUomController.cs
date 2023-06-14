using Common.Constant;
using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using System.Net;

namespace SCM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemUomController : ControllerBase
    {
        private readonly IItemUomService _itemUomService;

        public ItemUomController(IItemUomService itemUomService)
        {
            _itemUomService = itemUomService;
        }

        /// <summary>
        /// Get the list of ItemUOM for dropdown.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ApiResponse.</returns>
        [HttpGet("GetItemUomList")]
        public async Task<IActionResult> GetItemUomList()
        {
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: await _itemUomService.GetItemUomList()));
        }
    }
}
