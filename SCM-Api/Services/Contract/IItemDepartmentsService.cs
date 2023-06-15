using Data.Entities;

namespace Services.Contract
{
    public interface IItemDepartmentsService
    {
        /// <summary>
        /// Delete ItemDepartmentMapping data.
        /// </summary>
        /// <param name="itemDepartmentMapping">itemDepartmentMapping.</param>
        /// <returns>The bool response.</returns>
        Task<bool> Delete(ItemDepartmentMapping itemDepartmentMapping);

        /// <summary>
        /// Get ItemDepartmentMapping list based on ItemId.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ItemDepartmentMapping Model.</returns>
        Task<IEnumerable<ItemDepartmentMapping?>> GetItemDepartmentList(int ItemId);

        /// <summary>
        /// Save ItemDepartmentMapping data.
        /// </summary>
        /// <param name="itemDepartmentMapping">itemDepartmentMapping.</param>
        /// <returns>The ItemDepartmentId.</returns>
        Task<int> Save(ItemDepartmentMapping itemDepartmentMapping);

        /// <summary>
        /// Save multiple data to ItemDepartmentMapping Model
        /// </summary>
        /// <param name="itemDepartmentMappings">itemDepartmentMappings</param>
        Task SaveMultiple(List<ItemDepartmentMapping> itemDepartmentMappings);
    }
}
