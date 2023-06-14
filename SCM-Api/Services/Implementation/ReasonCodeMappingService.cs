using Data.Context;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Contract;

namespace Services.Implementation
{
    public class ReasonCodeMappingService : RepositoryBase<ItemReasoncodesMapping>, IReasonCodeMappingService
    {
        public ReasonCodeMappingService(Context context) : base(context)
        {

        }

        /// <summary>
        /// Delete ItemReasoncodesMapping data.
        /// </summary>
        /// <param name="itemReasoncodesMapping">itemReasoncodesMapping.</param>
        /// <returns>The bool response.</returns>
        public async Task<bool> Delete(ItemReasoncodesMapping itemReasoncodesMapping)
        {
            this.DeleteEntity(itemReasoncodesMapping);
            await this.SaveAsync();
            return true;
        }

        /// <summary>
        /// Get ItemReasoncodesMapping list based on ItemId.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ItemReasoncodesMapping Model.</returns>
        public async Task<IEnumerable<ItemReasoncodesMapping?>> GetItemReasonCodeList(int ItemId) =>
            await this.Find(x => x.ItemId == ItemId).ToListAsync();

        /// <summary>
        /// Save ItemReasoncodesMapping data.
        /// </summary>
        /// <param name="itemReasoncodesMapping">itemReasoncodesMapping.</param>
        /// <returns>The ItemReasoncodeId.</returns>
        public async Task<int> Save(ItemReasoncodesMapping itemReasoncodesMapping)
        {
            this.CreateEntity(itemReasoncodesMapping);
            await this.SaveAsync();
            return itemReasoncodesMapping.ItemReasoncodeId;
        }

        /// <summary>
        /// Save multiple data to ItemReasoncodesMapping Model
        /// </summary>
        /// <param name="itemReasoncodesMappings">itemReasoncodesMappings</param>
        public async Task SaveMultipleReasonCodes(List<ItemReasoncodesMapping> itemReasoncodesMappings)
        {
            this.CreateMultipleEntity(itemReasoncodesMappings);
            await this.SaveAsync();
        }
    }
}
