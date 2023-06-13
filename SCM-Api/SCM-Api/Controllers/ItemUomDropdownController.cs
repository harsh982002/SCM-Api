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
    public class ItemUomDropdownController : ControllerBase
    {
        private readonly IItemUomService _itemUomService;
        private readonly IMapper _mapper;

        public ItemUomDropdownController(IItemUomService itemUomService,IMapper mapper)
        {
            _itemUomService = itemUomService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get the list of ItemUOM for dropdown.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ApiResponse.</returns>
        [HttpGet("/getitemuomlist")]
        public async Task<IActionResult> GetItemUomList()
        {
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: await _itemUomService.GetItemUomList()));
        }
    }
}
