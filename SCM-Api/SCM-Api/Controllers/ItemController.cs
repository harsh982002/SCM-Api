using AutoMapper;
using Common.Constant;
using Common.Helpers;
using Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using Services.Models;
using System.Net;

namespace SCM_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IDepartmentMappingService _departmentMappingService;
        private readonly IReasonCodeMappingService _reasonCodeMappingService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService,IDepartmentMappingService departmentMappingService,IReasonCodeMappingService reasonCodeMappingService, IMapper mapper)
        {
            _itemService = itemService;
            _departmentMappingService = departmentMappingService;
            _reasonCodeMappingService = reasonCodeMappingService;
            _mapper = mapper;
        }

        [HttpPost("/AddNewItem")]
        public async Task<IActionResult> AddItem([FromForm] ItemModel model)
        {
            var ExistedItem = await _itemService.AlreadyExist(model);
            if (ExistedItem)
            {
                return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.DuplicateEntry, $"Item of name:{model.Name} already exist!" }));
            }
            int AddedItem = await _itemService.Save(_mapper.Map<Item>(model));
            if (AddedItem > 0)
            {
                foreach(var departmentId in model.Departments)
                {
                    ItemDepartmentMapping itemDepartmentMapping = new()
                    {
                        DepartmentId = departmentId,
                        ItemId = AddedItem
                    };
                    await _departmentMappingService.Save(itemDepartmentMapping);
                }

                foreach (var ReasonCodeId in model.ReasonCodes)
                {
                    ItemReasoncodesMapping itemReasoncodesMapping = new()
                    {
                        ReasonCodeId = ReasonCodeId,
                        ItemId = AddedItem
                    };
                    await _reasonCodeMappingService.Save(itemReasoncodesMapping);
                }
            }
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: AddedItem));
        }

        [HttpPost("/updateItem")]
        public async Task<IActionResult> UpdateItem(int ItemId, [FromForm] ItemModel model)
        {
            Item? item = await _itemService.GetById(ItemId);
            if (item != null)
            {
                var ExistedItem = await _itemService.AlreadyExist(model);
                if (ExistedItem)
                {
                    return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.DuplicateEntry, $"Item of name:{model.Name} already exist!" }));
                }
                Item updatedItem = _mapper.Map<Item>(model);
                updatedItem.ItemId = (byte)ItemId;
                await _itemService.Update(updatedItem);
                return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: updatedItem.ItemId));
            }

            return this.Ok(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"Item data not found." }, ItemId));
        }

        [HttpPost("/DeleteItemDepartmentMapping")]
        public async Task<IActionResult> DeleteItemDepartmentMapping([FromForm] ItemDepartmentMappingModel model)
        {
            ItemDepartmentMapping? itemDepartmentMapping = await _departmentMappingService.GetById(model);
            if (itemDepartmentMapping != null)
            {
                bool response = await _departmentMappingService.Delete(_mapper.Map<ItemDepartmentMapping>(model));
                if (response)
                {
                    return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }));
                }
            }
            return this.Ok(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"Data not found." }));
        }

        [HttpPost("/DeleteItemReasonCodeMapping")]
        public async Task<IActionResult> DeleteItemReasonCodeMapping([FromForm] ItemReasonCodeMappingModel model)
        {
            ItemReasoncodesMapping? itemReasoncodesMapping = await _reasonCodeMappingService.GetById(model);
            if(itemReasoncodesMapping != null)
            {
                bool response = await _reasonCodeMappingService.Delete(_mapper.Map<ItemReasoncodesMapping>(model));
                if (response)
                {
                    return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }));
                }
            }
            return this.Ok(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"Data not found." }));
        }
    }
}
