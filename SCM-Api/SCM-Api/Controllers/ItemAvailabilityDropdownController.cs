using AutoMapper;
using Common.Constant;
using Common.Helpers;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using Services.Models;
using System.Net;

namespace SCM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemAvailabilityDropdownController : ControllerBase
    {
        private readonly IItemAvailabilityService _itemAvailabilityService;
        private readonly IMapper _mapper;

        public ItemAvailabilityDropdownController(IItemAvailabilityService itemAvailabilityService, IMapper mapper)
        {
            _itemAvailabilityService = itemAvailabilityService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get the ItemAvailability data based on ItemAvailabilityId.
        /// </summary>
        /// <param name="ItemAvailabilityId">ItemAvailabilityId</param>
        /// <returns>The ApiResponse.</returns>
        [HttpGet("/getitemAvailabilitybyid/{ItemAvailabilityId}")]
        public async Task<IActionResult> GetItemAvailabilityById(byte ItemAvailabilityId)
        {
            var ItemAvailability = await _itemAvailabilityService.GetItemAvailabilityById(ItemAvailabilityId);
            if (ItemAvailability == null)
            {
                return NotFound(new ApiResponse(statusCode: HttpStatusCode.NotFound, messages: new List<string> { MessageConstant.RequestnotFound, $"ItemAvailability of id:{ItemAvailabilityId} doesn't exist!" }));
            }
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: _mapper.Map<ItemAvailabilityModel>(ItemAvailability)));
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
