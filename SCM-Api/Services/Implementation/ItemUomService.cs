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
    public class ItemUomService : RepositoryBase<ItemUom>, IItemUomService
    {
        public ItemUomService(Context context) : base(context)
        {

        }

        public async Task<IEnumerable<ItemUomModel?>> GetItemUomList() =>
            await this.Find().Select(x => new ItemUomModel
            {
                ItemUomId = x.ItemUomId,
                Name = x.Name,
            }).ToListAsync();

        public async Task<ItemUom?> GetItemUomById(byte ItemUomId)=>
            await this.Find(x=>x.ItemUomId == ItemUomId).FirstOrDefaultAsync();
    }
}
