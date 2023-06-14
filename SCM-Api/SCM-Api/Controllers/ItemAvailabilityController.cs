using Common.Constant;
using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using System.Net;

namespace SCM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemAvailabilityController : ControllerBase
    {
        private readonly IItemAvailabilityService _itemAvailabilityService;

        public ItemAvailabilityController(IItemAvailabilityService itemAvailabilityService)
        {
            _itemAvailabilityService = itemAvailabilityService;
        }

        /// <summary>
        /// Get the list of ItemAvalability for dropdown.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ApiResponse.</returns>
        [HttpGet("/getitemAvailabilitylist")]
        public async Task<IActionResult> GetItemAvailabilityList()
        {
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: await _itemAvailabilityService.GetItemAvailabilityList()));
        }
    }
}
