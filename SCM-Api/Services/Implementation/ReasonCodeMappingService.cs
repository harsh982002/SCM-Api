using Common.Helpers;
using Data.Context;
using Data.Entities;
using Data.Repository;
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
            itemReasoncodesMapping.DeletedTime = Helper.GetCurrentUTCDateTime();
            this.UpdateEntity(itemReasoncodesMapping);
            await this.SaveAsync();
            return true;
        }

        /// <summary>
        /// Get ItemReasonCodeMapping data.
        /// </summary>
        /// <param name="itemReasonCodeMappingModel">itemReasonCodeMappingModel.</param>
        /// <returns>The ItemReasonCodeMappingModel model.</returns>
        public async Task<ItemReasoncodesMapping?> GetById(ItemReasonCodeMappingModel itemReasonCodeMappingModel) =>
            await this.Find(x => x.ItemId == itemReasonCodeMappingModel.ItemId && x.ReasonCodeId == itemReasonCodeMappingModel.ReasonCodeId).FirstOrDefaultAsync();

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
    }
}
