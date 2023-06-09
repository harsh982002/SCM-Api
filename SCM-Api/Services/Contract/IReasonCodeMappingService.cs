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
        Task<bool> Save(ItemReasoncodesMapping itemReasoncodesMapping);
        Task<bool> Delete(ItemReasoncodesMapping itemReasoncodesMapping);
        Task<ItemReasoncodesMapping?> GetById(ItemReasonCodeMappingModel itemReasonCodeMappingModel);
    }
}
