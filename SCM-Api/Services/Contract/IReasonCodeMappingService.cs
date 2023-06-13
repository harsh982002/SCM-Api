using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IReasonCodeMappingService
    {
        /// <summary>
        /// Save ItemReasoncodesMapping data.
        /// </summary>
        /// <param name="itemReasoncodesMapping">itemReasoncodesMapping.</param>
        /// <returns>The ItemReasoncodeId.</returns>
        Task<int> Save(ItemReasoncodesMapping itemReasoncodesMapping);

        /// <summary>
        /// Delete ItemReasoncodesMapping data.
        /// </summary>
        /// <param name="itemReasoncodesMapping">itemReasoncodesMapping.</param>
        /// <returns>The bool response.</returns>
        Task<bool> Delete(ItemReasoncodesMapping itemReasoncodesMapping);

        /// <summary>
        /// Get ItemReasoncodesMapping list based on ItemId.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ItemReasoncodesMapping Model.</returns>
        Task<IEnumerable<ItemReasoncodesMapping?>> GetItemReasonCodeList(int ItemId);
    }
}
