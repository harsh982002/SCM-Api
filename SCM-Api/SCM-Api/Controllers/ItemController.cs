using AutoMapper;
using Common.Constant;
using Common.Helpers;
using Data.Entities;
using Data.StoreProcedureModel;
using Microsoft.AspNetCore.Mvc;
using Services.Contract;
using Services.Models;
using System.Net;
using System.Text;

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
        public async Task<IActionResult> AddItem(ItemModel model)
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
        public async Task<IActionResult> UpdateItem(int ItemId, ItemModel model)
        {
            Item? oldItem = await _itemService.GetById(ItemId);
            if (oldItem != null)
            {
                var ExistedItem = await _itemService.AlreadyExist(model, ItemId);
                if (ExistedItem)
                {
                    return BadRequest(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.DuplicateEntry, $"Item of name:{model.Name} already exist!" }));
                }
                Item updateditem = this._mapper.Map<Item>(model);
                updateditem.CreatedTime = oldItem.CreatedTime;
                updateditem.ItemId = oldItem.ItemId;
                int Item = await _itemService.Update(updateditem);
                var itemdepartment = await _departmentMappingService.GetItemDepartmentList(ItemId);
                if (itemdepartment.Any())
                {
                    foreach (ItemDepartmentMapping? item in itemdepartment)
                    {
                        if (model.Departments.Contains((int)item.ItemId) is true)
                        {
                            await _departmentMappingService.Delete(item);
                            model.Departments.Remove((int)item.ItemId);
                        }
                    }
                }
                if (model.Departments.Any())
                {
                    List<ItemDepartmentMapping> itemDepartmentMappings = new List<ItemDepartmentMapping>();
                    model.Departments.ForEach(id =>
                    {
                        if (!itemdepartment.Any(x => x?.DepartmentId == id))
                        {
                            ItemDepartmentMapping itemDepartmentMapping = new()
                            {
                                ItemId = ItemId,
                                DepartmentId = id,
                            };
                            itemDepartmentMappings.Add(itemDepartmentMapping);
                        }
                    });
                    await _departmentMappingService.SaveMultiple(itemDepartmentMappings);
                }
                var itemreasoncode = await _reasonCodeMappingService.GetItemReasonCodeList(ItemId);
                if (itemreasoncode.Any())
                {
                    foreach (ItemReasoncodesMapping? item in itemreasoncode)
                    {
                        if (model.ReasonCodes.Contains((byte)item.ItemId) is true)
                        {
                            await _reasonCodeMappingService.Delete(item);
                            model.ReasonCodes.Remove((byte)item.ItemId);
                        }
                    }
                }
                if (model.ReasonCodes.Any())
                {
                    List<ItemReasoncodesMapping> itemReasoncodesMappings = new List<ItemReasoncodesMapping>();
                    model.ReasonCodes.ForEach(id =>
                    {
                        if (!itemreasoncode.Any(x => x?.ReasonCodeId == id))
                        {
                            ItemReasoncodesMapping itemReasoncodesMapping = new()
                            {
                                ItemId = ItemId,
                                ReasonCodeId = id,
                            };
                            itemReasoncodesMappings.Add(itemReasoncodesMapping);
                        }
                    });
                    await _reasonCodeMappingService.SaveMultipleReasonCodes(itemReasoncodesMappings);
                }
                return Ok(new ApiResponse(statusCode: HttpStatusCode.OK, messages: new List<string> { MessageConstant.RequestSuccessful }, result: Item));

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
            return this.NotFound(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"Item data not found." }, ItemId));
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
        public async Task<IActionResult> GetItemList(SP_ItemFilterModel filter) =>
          this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, result: await _itemService.GetItemList(filter)));

        /// <summary>
        /// Get the Item list to Csv.
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>Result inform of Text/Csv File</returns>
        [HttpPost("/GetCsvForItem")]
        public async Task<IActionResult> ConvertToCsv(SP_ItemFilterModel filter)
        {
            var listOfProgrammes = _mapper.Map<IEnumerable<GetItemCsvModel>>(await _itemService.GetItemList(filter));
            return new FileContentResult(Encoding.ASCII.GetBytes(Helper.ConvertToCSV(listOfProgrammes.ToList())), "text/csv");
        }
    }
}
