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

        public async Task<bool> Delete(ItemReasoncodesMapping itemReasoncodesMapping)
        {
            this.DeleteEntity(itemReasoncodesMapping);
            await this.SaveAsync();
            return true;
        }

        public async Task<ItemReasoncodesMapping?> GetById(ItemReasonCodeMappingModel itemReasonCodeMappingModel) =>
            await this.Find(x => x.ItemId == itemReasonCodeMappingModel.ItemId && x.ReasonCodeId == itemReasonCodeMappingModel.ReasonCodeId).FirstOrDefaultAsync();

        public async Task<bool> Save(ItemReasoncodesMapping itemReasoncodesMapping)
        {
            this.CreateEntity(itemReasoncodesMapping);
            await this.SaveAsync();
            return true;
        }
    }
}
