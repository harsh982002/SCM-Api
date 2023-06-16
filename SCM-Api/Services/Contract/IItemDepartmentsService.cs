namespace Services.Contract
{
    using Data.Entities;

    public interface IItemDepartmentsService
    {
        /// <summary>
        /// Delete ItemDepartment data.
        /// </summary>
        /// <param name="itemDepartment">itemDepartment.</param>
        /// <returns>The bool response.</returns>
        Task<bool> Delete(ItemDepartment itemDepartment);

        /// <summary>
        /// Get ItemDepartment list based on ItemId.
        /// </summary>
        /// <param name="ItemId">ItemId</param>
        /// <returns>The ItemDepartment Model.</returns>
        Task<IEnumerable<ItemDepartment?>> GetItemDepartmentList(int ItemId);

        /// <summary>
        /// Save ItemDepartment data.
        /// </summary>
        /// <param name="itemDepartment">itemDepartment.</param>
        /// <returns>The ItemDepartmentId.</returns>
        Task<int> Save(ItemDepartment itemDepartment);

        /// <summary>
        /// Save multiple data to ItemDepartment Model
        /// </summary>
        /// <param name="itemDepartment">itemDepartment</param>
        Task SaveMultiple(List<ItemDepartment> itemDepartment);
    }
}
