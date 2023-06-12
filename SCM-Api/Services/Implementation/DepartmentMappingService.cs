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

        public async Task<bool> Delete(ItemDepartmentMapping itemDepartmentMapping)
        {
            this.DeleteEntity(itemDepartmentMapping);
            await this.SaveAsync();
            return true;
        }

        public async Task<ItemDepartmentMapping?> GetById(ItemDepartmentMappingModel itemDepartmentMapping) =>
            await this.Find(x => x.ItemId == itemDepartmentMapping.ItemId && x.DepartmentId == itemDepartmentMapping.DepartmentId).FirstOrDefaultAsync();

        public async Task<IEnumerable<ItemDepartmentMappingModel?>> GetItemDepartmentList() =>
            await this.Find().Select(x => new ItemDepartmentMappingModel
            {
                DepartmentId = x.DepartmentId,
                ItemId = x.ItemId,
            }).ToListAsync();


        public async Task<bool> Save(ItemDepartmentMapping itemDepartmentMapping)
        {
            this.CreateEntity(itemDepartmentMapping);
            await this.SaveAsync();
            return true;
        }
    }
}
