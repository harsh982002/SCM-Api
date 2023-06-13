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

        /// <summary>
        /// Get ItemUom list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ItemUomModel.</returns>
        public async Task<IEnumerable<ItemUomModel?>> GetItemUomList() =>
            await this.Find().Select(x => new ItemUomModel
            {
                ItemUomId = x.ItemUomId,
                Name = x.Name,
            }).ToListAsync();

        /// <summary>
        /// Get ItemUom data by ItemUomId.
        /// </summary>
        /// <param name="ItemUomId">The ItemUomId.</param>
        /// <returns>The ItemUom model.</returns>
        public async Task<ItemUom?> GetItemUomById(byte ItemUomId)=>
            await this.Find(x=>x.ItemUomId == ItemUomId).FirstOrDefaultAsync();
    }
}
