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
        Task<bool> Save(ItemDepartmentMapping itemDepartmentMapping);

        Task<bool> Delete(ItemDepartmentMapping itemDepartmentMapping);

        Task<ItemDepartmentMapping?> GetById(ItemDepartmentMappingModel itemDepartmentMapping);
    }
}
