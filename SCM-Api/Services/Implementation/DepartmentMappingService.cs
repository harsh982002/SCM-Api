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
            itemDepartmentMapping.DeletedTime = Helper.GetCurrentUTCDateTime();
            this.UpdateEntity(itemDepartmentMapping);
            await this.SaveAsync();
            return true;
        }

        /// <summary>
        /// Get ItemDepartmentMapping data.
        /// </summary>
        /// <param name="itemDepartmentMapping">itemDepartmentMapping.</param>
        /// <returns>The ItemDepartmentMapping model.</returns>
        public async Task<ItemDepartmentMapping?> GetById(ItemDepartmentMappingModel itemDepartmentMapping) =>
            await this.Find(x => x.ItemId == itemDepartmentMapping.ItemId && x.DepartmentId == itemDepartmentMapping.DepartmentId).FirstOrDefaultAsync();

        /// <summary>
        /// Get ItemDepartmentMapping list based on ItemId.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ItemDepartmentMapping Model.</returns>
        public async Task<IEnumerable<ItemDepartmentMapping?>> GetItemDepartmentList(int ItemId) =>
            await this.Find(x=>x.ItemId == ItemId).ToListAsync();

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
    }
}
