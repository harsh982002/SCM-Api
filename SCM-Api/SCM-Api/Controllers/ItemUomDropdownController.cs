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

        [HttpGet("/getitemuombyid/{ItemUomId}")]
        public async Task<IActionResult> GetItemUomById(byte ItemUomId)
        {
            var ItemUom = await _itemUomService.GetItemUomById(ItemUomId);
            if (ItemUom == null)
            {
                return NotFound(new ApiResponse(statusCode: HttpStatusCode.NotFound, messages: new List<string> { MessageConstant.RequestnotFound, $"ItemUom of id:{ItemUomId} doesn't exist!" }));
            }
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: _mapper.Map<ItemUomModel>(ItemUom)));
        }

        [HttpGet("/getitemuomlist")]
        public async Task<IActionResult> GetItemUomList()
        {
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: await _itemUomService.GetItemUomList()));
        }
    }
}
