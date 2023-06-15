using Data.Context;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Contract;

namespace Services.Implementation
{
    public class ItemReasonCodesService : RepositoryBase<ItemReasoncode>, IItemReasonCodesService
    {
        public ItemReasonCodesService(Context context) : base(context)
        {

        }

        /// <summary>
        /// Delete ItemReasoncode data.
        /// </summary>
        /// <param name="itemReasoncode">itemReasoncode.</param>
        /// <returns>The bool response.</returns>
        public async Task<bool> Delete(ItemReasoncode itemReasoncode)
        {
            this.DeleteEntity(itemReasoncode);
            await this.SaveAsync();
            return true;
        }

        /// <summary>
        /// Get ItemReasoncode list based on ItemId.
        /// </summary>
        /// <param name="ItemId">ItemID</param>
        /// <returns>The ItemReasoncode Model.</returns>
        public async Task<IEnumerable<ItemReasoncode?>> GetItemReasonCodeList(int ItemId) =>
            await this.Find(x => x.ItemId == ItemId).ToListAsync();

        /// <summary>
        /// Save ItemReasoncode data.
        /// </summary>
        /// <param name="itemReasoncode">itemReasoncode.</param>
        /// <returns>The ItemReasoncodeId.</returns>
        public async Task<int> Save(ItemReasoncode itemReasoncode)
        {
            this.CreateEntity(itemReasoncode);
            await this.SaveAsync();
            return itemReasoncode.ItemReasoncodeId;
        }

        /// <summary>
        /// Save multiple data to ItemReasoncodesMapping Model
        /// </summary>
        /// <param name="itemReasoncodesMappings">itemReasoncodesMappings</param>
        public async Task SaveMultipleReasonCodes(List<ItemReasoncode> itemReasoncode)
        {
            this.CreateMultipleEntity(itemReasoncode);
            await this.SaveAsync();
        }
    }
}
