using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IDepartmentMappingService
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
    }
}
