using Common.Helpers;
using Data.Context;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Contract;

namespace Services.Implementation
{
    public class DepartmentMappingService : RepositoryBase<ItemDepartmentMapping>, IDepartmentMappingService
    {
        public DepartmentMappingService(Context context) : base(context)
        {

        }

        /// <summary>
        /// Delete ItemDepartmentMapping data.
        /// </summary>
        /// <param name="itemDepartmentMapping">itemDepartmentMapping.</param>
        /// <returns>The bool response.</returns>
        public async Task<bool> Delete(ItemDepartmentMapping itemDepartmentMapping)
        {
            this.DeleteEntity(itemDepartmentMapping);
            await this.SaveAsync();
            return true;
        }

        /// <summary>
        /// Get ItemDepartmentMapping list based on ItemId.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ItemDepartmentMapping Model.</returns>
        public async Task<IEnumerable<ItemDepartmentMapping?>> GetItemDepartmentList(int ItemId) =>
            await this.Find(x => x.ItemId == ItemId).ToListAsync();

        /// <summary>
        /// Save ItemDepartmentMapping data.
        /// </summary>
        /// <param name="itemDepartmentMapping">itemDepartmentMapping.</param>
        /// <returns>The ItemDepartmentId.</returns>
        public async Task<int> Save(ItemDepartmentMapping itemDepartmentMapping)
        {
            this.CreateEntity(itemDepartmentMapping);
            await this.SaveAsync();
            return itemDepartmentMapping.ItemDepartmentId;
        }

        /// <summary>
        /// Save multiple data to ItemDepartmentMapping Model
        /// </summary>
        /// <param name="itemDepartmentMappings">itemDepartmentMappings</param>
        public async Task SaveMultiple(List<ItemDepartmentMapping> itemDepartmentMappings)
        {
            this.CreateMultipleEntity(itemDepartmentMappings);
            await this.SaveAsync();
        }
    }
}
