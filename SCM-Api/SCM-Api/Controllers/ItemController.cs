using AutoMapper;
using Common.Constant;
using Common.Helpers;
using Data.Entities;
using Data.StoreProcedureModel;
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

        public ItemController(IItemService itemService, IDepartmentMappingService departmentMappingService, IReasonCodeMappingService reasonCodeMappingService, IMapper mapper)
        {
            _itemService = itemService;
            _departmentMappingService = departmentMappingService;
            _reasonCodeMappingService = reasonCodeMappingService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Item by Id based on ItemId.
        /// </summary>
        /// <param name="ItemId">The ItemId.</param>
        /// <returns>The ApiResponse.</returns>
        [HttpGet("/Getitembyid/{ItemId}")]
        public async Task<IActionResult> GetItemById(int ItemId)
        {
            var Item = await _itemService.GetById(ItemId);
            if (Item == null)
            {
                return this.NotFound(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"Item data not found." }, ItemId));
            }
            return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: _mapper.Map<ItemModel>(Item)));
        }

        /// <summary>
        /// Save the new item data.
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>The ApiResponse.</returns>
        [HttpPost("/AddNewItem")]
        public async Task<IActionResult> AddItem([FromForm] ItemModel model)
        {
            var ExistedItem = await _itemService.AlreadyExist(model);
            if (ExistedItem)
            {
                return BadRequest(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.DuplicateEntry, $"Item of name:{model.Name} already exist!" }));
            }
            int AddedItem = await _itemService.Save(_mapper.Map<Item>(model));
            if (AddedItem > 0)
            {
                foreach (var departmentId in model.Departments)
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

        /// <summary>
        /// update the existing item data.
        /// </summary>
        /// <param name="ItemId">ItemId</param>
        /// <param name="model">model</param>
        /// <returns>The ApiResponse.</returns>
        [HttpPost("/UpdateItem/{ItemId}")]
        public async Task<IActionResult> UpdateItem(int ItemId, [FromForm] ItemUpdateModel model)
        {
            Item? oldItem = await _itemService.GetById(ItemId);
            if (oldItem != null)
            {
                if (ItemId == model.ItemId)
                {
                    Item updateditem = this._mapper.Map<Item>(model);
                    updateditem.CreatedTime = oldItem.CreatedTime;
                    int Item = await _itemService.Update(updateditem);
                    if (Item > 0)
                    {
                        foreach (var departmentId in model.Departments)
                        {
                            ItemDepartmentMapping itemDepartmentMapping = new()
                            {
                                DepartmentId = departmentId,
                                ItemId = Item
                            };
                            await _departmentMappingService.Save(itemDepartmentMapping);
                        }

                        foreach (var ReasonCodeId in model.ReasonCodes)
                        {
                            ItemReasoncodesMapping itemReasoncodesMapping = new()
                            {
                                ReasonCodeId = ReasonCodeId,
                                ItemId = Item
                            };
                            await _reasonCodeMappingService.Save(itemReasoncodesMapping);
                        }
                    }
                    return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: Item));
                }
            }
            return this.NotFound(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"Item data not found." }, ItemId));
        }

        /// <summary>
        /// delete the existing item data with their connected mappers.
        /// </summary>
        /// <param name="ItemId">ItemId</param>
        /// <returns>The ApiResponse.</returns>
        [HttpDelete("/DeleteItem/{ItemId}")]
        public async Task<IActionResult> DeleteItem(int ItemId)
        {
            Item? item = await _itemService.GetById(ItemId);
            if (item != null && item.DeletedTime == null)
            {
                await _itemService.Delete(item);
                var itemdepartment = await _departmentMappingService.GetItemDepartmentList(ItemId);
                if (itemdepartment.Any())
                {
                    foreach (var department in itemdepartment)
                    {
                        await _departmentMappingService.Delete(department);
                    }
                }
                var itemreasoncode = await _reasonCodeMappingService.GetItemReasonCodeList(ItemId);
                if (itemreasoncode.Any())
                {
                    foreach (var reasoncode in itemreasoncode)
                    {
                        await _reasonCodeMappingService.Delete(reasoncode);
                    }
                }
                return this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }));
            }
            return this.NotFound(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"Item data not found."}, ItemId));
        }

        /// <summary>
        /// update the existing item's Status.
        /// </summary>
        /// <param name="ItemId">ItemId</param>
        /// <param name="Status">Status</param>
        /// <returns>The ApiResponse.</returns>
        [HttpPost("/UpdateItemStatus/{ItemId}")]
        public async Task<IActionResult> UpdateItemStatus(int ItemId, byte Status)
        {
            var item = await
                _itemService.GetById(ItemId);
            if (item != null)
            {
                await _itemService.UpdateItemStatus(item, Status);
                return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }));
            }
            return this.NotFound(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"Data not found." }));
        }

        /// <summary>
        /// Get the list of items with filter and pagination.
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>The ApiResponse.</returns>
        [HttpPost("/GetItemList")]
        public async Task<IActionResult> GetItemList([FromForm]SP_ItemFilterModel filter)=>
          this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful },result: await _itemService.GetItemList(filter)));

    }
}
