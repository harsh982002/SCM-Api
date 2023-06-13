using Common.Helpers;
using Data.Context;
using Data.Entities;
using Data.Repository;
using Data.StoreProcedureModel;
using Microsoft.EntityFrameworkCore;
using Services.Contract;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class ItemService : RepositoryBase<Item>, IItemService
    {
        public ItemService(Context context) : base(context)
        {

        }

        /// <summary>
        /// Verify wheather the Item already exist or not.
        /// </summary>
        /// <param name="model">model.</param>
        /// <returns>The bool response.</returns>
        public async Task<bool> AlreadyExist(ItemModel model)
        {
            var ExistedItem = await this.Find(x => x.Name == model.Name && x.ItemSegment == model.ItemSegment).AnyAsync();
            if (ExistedItem)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Delete Item data.
        /// </summary>
        /// <param name="item">item.</param>
        /// <returns>The ItemId.</returns>
        public async Task<int> Delete(Item item)
        {
            item.DeletedTime = Helper.GetCurrentUTCDateTime();
            this.UpdateEntity(item);
            await this.SaveAsync();
            return (item.ItemId);
        }

        /// <summary>
        /// Get Item data by ItemId.
        /// </summary>
        /// <param name="ItemId">The ItemId.</param>
        /// <returns>The Item model.</returns>
        public async Task<Item?> GetById(int ItemId) =>
            await this.Find(x => x.ItemId == ItemId).FirstOrDefaultAsync();

        /// <summary>
        /// Save Item data.
        /// </summary>
        /// <param name="item">item.</param>
        /// <returns>The ItemId.</returns>
        public async Task<int> Save(Item item)
        {
            item.CreatedTime = Helper.GetCurrentUTCDateTime();
            this.CreateEntity(item);
            await this.SaveAsync();
            return (item.ItemId);
        }

        /// <summary>
        /// Update Item data.
        /// </summary>
        /// <param name="item">item.</param>
        /// <returns>The ItemId.</returns>
        public async Task<int> Update(Item item)
        {
            item.UpdatedTime = Helper.GetCurrentUTCDateTime();
            this.UpdateEntity(item);
            await this.SaveAsync();
            return (item.ItemId);
        }

        /// <summary>
        /// Update Item Status.
        /// </summary>
        /// <param name="item">item.</param>
        /// <param name="Status">Status.</param>
        public async Task UpdateItemStatus(Item item, byte Status)
        {
            item.StatusId = Status;
            this.UpdateEntity(item);
            await this.SaveAsync();
        }

        /// <summary>
        /// Get Item list with filter and pagination.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The SP_ItemListModel.</returns>
        public async Task<IEnumerable<SP_ItemListModel>> GetItemList(SP_ItemFilterModel filter)=>
            await this.ExecuteStoredProcedureListAsync<SP_ItemListModel>($"EXEC [dbo].[GetItemList] @SearchText = {filter.SearchText}, @SortColumn = {filter.SortColumn},@SortOrder = {filter.SortOrder},@PageNumber = {filter.PageNumber},@PageSize = {filter.PageSize},@CompanyId = {filter.CompanyId},@PurchaseCategoryId = {filter.PurchaseCategoryId},@ItemUOMId = {filter.ItemUOMId},@AvailabilityId = {filter.AvailabilityId},@StatusId = {filter.StatusId},@ReasonCodeId = {filter.ReasonCodeId}");
        
    }
}
