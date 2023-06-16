namespace SCM_Api.Controllers
{
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

    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;
        private readonly IItemDepartmentsService _itemDepartmentsService;
        private readonly IItemReasonCodesService _itemReasonCodesService;
        private readonly IMapper _mapper;

        public ItemController(IItemService itemService, IItemDepartmentsService itemDepartmentsService, IItemReasonCodesService itemReasonCodesService, IMapper mapper)
        {
            _itemService = itemService;
            _itemDepartmentsService = itemDepartmentsService;
            _itemReasonCodesService = itemReasonCodesService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Item by Id based on ItemId.
        /// </summary>
        /// <param name="ItemId">The ItemId.</param>
        /// <returns>The ApiResponse.</returns>
        [HttpGet("GetItemById/{ItemId}")]
        public async Task<IActionResult> GetItemById(int ItemId)
        {
            var Item = await _itemService.GetById(ItemId);
            if (Item == null)
            {
                return this.NotFound(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"Item data not found." }, ItemId));
            }

            return Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, _mapper.Map<ItemModel>(Item)));
        }

        /// <summary>
        /// Save the new item data.
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>The ApiResponse.</returns>
        [HttpPost("AddItem")]
        public async Task<IActionResult> AddItem(ItemModel model)
        {
            var ExistedItem = await _itemService.AlreadyExist(model);
            if (ExistedItem)
            {
                return BadRequest(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.DuplicateEntry, $"Item of name:{model.Name} already exist!" }));
            }

            int AddedItem = await _itemService.Save(_mapper.Map<Item>(model));
            if (AddedItem > 0)
            {
                foreach (var departmentId in model.Departments)
                {
                    ItemDepartment itemDepartments = new()
                    {
                        DepartmentId = departmentId,
                        ItemId = AddedItem
                    };

                    await _itemDepartmentsService.Save(itemDepartments);
                }

                foreach (var ReasonCodeId in model.ReasonCodes)
                {
                    ItemReasoncode itemReasoncode = new()
                    {
                        ReasonCodeId = ReasonCodeId,
                        ItemId = AddedItem
                    };

                    await _itemReasonCodesService.Save(itemReasoncode);
                }
            }

            return Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, AddedItem));
        }

        /// <summary>
        /// update the existing item data.
        /// </summary>
        /// <param name="ItemId">ItemId</param>
        /// <param name="model">model</param>
        /// <returns>The ApiResponse.</returns>
        [HttpPost("UpdateItem/{ItemId}")]
        public async Task<IActionResult> UpdateItem(int ItemId, ItemModel model)
        {
            Item? oldItem = await _itemService.GetById(ItemId);
            if (oldItem != null)
            {
                var ExistedItem = await _itemService.AlreadyExist(model, ItemId);
                if (ExistedItem)
                {
                    return BadRequest(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.DuplicateEntry, $"Item of name:{model.Name} already exist!" }));
                }

                Item updateditem = this._mapper.Map<Item>(model);
                updateditem.CreatedTime = oldItem.CreatedTime;
                updateditem.ItemId = oldItem.ItemId;
                int Item = await _itemService.Update(updateditem);

                var itemdepartment = await _itemDepartmentsService.GetItemDepartmentList(ItemId);
                if (itemdepartment.Any())
                {
                    foreach (ItemDepartment? item in itemdepartment)
                    {
                        if (model.Departments.Contains((int)item.ItemId) is true)
                        {
                            await _itemDepartmentsService.Delete(item);
                            model.Departments.Remove((int)item.ItemId);
                        }
                    }
                }

                if (model.Departments.Any())
                {
                    List<ItemDepartment> itemDepartments = new();
                    model.Departments.ForEach(id =>
                    {
                        if (!itemdepartment.Any(x => x?.DepartmentId == id))
                        {
                            ItemDepartment itemDepartment = new()
                            {
                                ItemId = ItemId,
                                DepartmentId = id,
                            };

                            itemDepartments.Add(itemDepartment);
                        }
                    });

                    await _itemDepartmentsService.SaveMultiple(itemDepartments);
                }

                var itemreasoncode = await _itemReasonCodesService.GetItemReasonCodeList(ItemId);
                if (itemreasoncode.Any())
                {
                    foreach (ItemReasoncode? item in itemreasoncode)
                    {
                        if (model.ReasonCodes.Contains((byte)item.ItemId) is true)
                        {
                            await _itemReasonCodesService.Delete(item);
                            model.ReasonCodes.Remove((byte)item.ItemId);
                        }
                    }
                }

                if (model.ReasonCodes.Any())
                {
                    List<ItemReasoncode> itemReasoncodes = new();
                    model.ReasonCodes.ForEach(id =>
                    {
                        if (!itemreasoncode.Any(x => x?.ReasonCodeId == id))
                        {
                            ItemReasoncode itemReasoncode = new()
                            {
                                ItemId = ItemId,
                                ReasonCodeId = id,
                            };

                            itemReasoncodes.Add(itemReasoncode);
                        }
                    });

                    await _itemReasonCodesService.SaveMultipleReasonCodes(itemReasoncodes);
                }

                return Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, Item));

            }

            return this.NotFound(new ApiResponse(HttpStatusCode.BadRequest, new List<string> { $"Item data not found." }, ItemId));
        }

        /// <summary>
        /// delete the existing item data with their connected mappers.
        /// </summary>
        /// <param name="ItemId">ItemId</param>
        /// <returns>The ApiResponse.</returns>
        [HttpDelete("DeleteItem/{ItemId}")]
        public async Task<IActionResult> DeleteItem(int ItemId)
        {
            Item? item = await _itemService.GetById(ItemId);
            if (item != null && item.DeletedTime == null)
            {
                await _itemService.Delete(item);
                var itemdepartment = await _itemDepartmentsService.GetItemDepartmentList(ItemId);
                if (itemdepartment.Any())
                {
                    foreach (var department in itemdepartment)
                    {
                        await _itemDepartmentsService.Delete(department);
                    }
                }

                var itemreasoncode = await _itemReasonCodesService.GetItemReasonCodeList(ItemId);
                if (itemreasoncode.Any())
                {
                    foreach (var reasoncode in itemreasoncode)
                    {
                        await _itemReasonCodesService.Delete(reasoncode);
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
        [HttpPost("UpdateItemStatus/{ItemId}")]
        public async Task<IActionResult> UpdateItemStatus(int ItemId, byte Status)
        {
            var item = await _itemService.GetById(ItemId);
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
        [HttpPost("GetItemList")]
        public async Task<IActionResult> GetItemList([FromForm] SP_ItemFilterModel filter) =>
          this.Ok(new ApiResponse(HttpStatusCode.OK, new List<string> { MessageConstant.RequestSuccessful }, await _itemService.GetItemList(filter)));

        /// <summary>
        /// Get the Item list to Csv.
        /// </summary>
        /// <param name="filter">filter</param>
        /// <returns>Result inform of Text/Csv File</returns>
        [HttpPost("ConvertToCsv")]
        public async Task<IActionResult> ConvertToCsv(SP_ItemFilterModel filter)
        {
            var ListOfItems = _mapper.Map<IEnumerable<GetItemCsvModel>>(await _itemService.GetItemList(filter));
            return new FileContentResult(Encoding.ASCII.GetBytes(Helper.ConvertToCSV(ListOfItems.ToList())), "text/csv");
        }
    }
}
