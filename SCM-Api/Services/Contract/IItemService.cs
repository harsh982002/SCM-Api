namespace Services.Contract
{
    using Data.Entities;
    using Data.StoreProcedureModel;
    using Services.Models;

    public interface IItemService
    {
        /// <summary>
        /// Save Item data.
        /// </summary>
        /// <param name="item">item.</param>
        /// <returns>The ItemId.</returns>
        Task<int> Save(Item item);

        /// <summary>
        /// Verify wheather the Item already exist or not.
        /// </summary>
        /// <param name="model">model.</param>
        /// <returns>The bool response.</returns>
        Task<bool> AlreadyExist(ItemModel model, int ItemId = 0);

        /// <summary>
        /// Get Item data by ItemId.
        /// </summary>
        /// <param name="ItemId">The ItemId.</param>
        /// <returns>The Item model.</returns>
        Task<Item?> GetById(int ItemId);

        /// <summary>
        /// Update Item data.
        /// </summary>
        /// <param name="item">item.</param>
        /// <returns>The ItemId.</returns>
        Task<int> Update(Item item);

        /// <summary>
        /// Delete Item data.
        /// </summary>
        /// <param name="item">item.</param>
        /// <returns>The ItemId.</returns>
        Task<int> Delete(Item item);

        /// <summary>
        /// Update Item Status.
        /// </summary>
        /// <param name="item">item.</param>
        /// <param name="Status">Status.</param>
        Task UpdateItemStatus(Item item, byte Status);

        /// <summary>
        /// Get Item list with filter and pagination.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>The SP_ItemListModel.</returns>
        Task<IEnumerable<SP_ItemListModel>> GetItemList(SP_ItemFilterModel filter);
    }
}
