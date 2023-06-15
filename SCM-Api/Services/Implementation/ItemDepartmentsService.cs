using Data.Context;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Contract;

namespace Services.Implementation
{
    public class ItemDepartmentsService : RepositoryBase<ItemDepartment>, IItemDepartmentsService
    {
        public ItemDepartmentsService(Context context) : base(context)
        {

        }

        /// <summary>
        /// Delete ItemDepartment data.
        /// </summary>
        /// <param name="itemDepartment">itemDepartment.</param>
        /// <returns>The bool response.</returns>
        public async Task<bool> Delete(ItemDepartment itemDepartment)
        {
            this.DeleteEntity(itemDepartment);
            await this.SaveAsync();
            return true;
        }

        /// <summary>
        /// Get ItemDepartment list based on ItemId.
        /// </summary>
        /// <param name="ItemId">ItemId</param>
        /// <returns>The ItemDepartment Model.</returns>
        public async Task<IEnumerable<ItemDepartment?>> GetItemDepartmentList(int ItemId) =>
            await this.Find(x => x.ItemId == ItemId).ToListAsync();

        /// <summary>
        /// Save ItemDepartment data.
        /// </summary>
        /// <param name="itemDepartment">itemDepartment.</param>
        /// <returns>The ItemDepartmentId.</returns>
        public async Task<int> Save(ItemDepartment itemDepartment)
        {
            this.CreateEntity(itemDepartment);
            await this.SaveAsync();
            return itemDepartment.ItemDepartmentId;
        }

        /// <summary>
        /// Save multiple data to ItemDepartment Model
        /// </summary>
        /// <param name="itemDepartment">itemDepartment</param>
        public async Task SaveMultiple(List<ItemDepartment> itemDepartment)
        {
            this.CreateMultipleEntity(itemDepartment);
            await this.SaveAsync();
        }
    }
}
