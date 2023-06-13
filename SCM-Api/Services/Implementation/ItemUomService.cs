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
        public async Task<IEnumerable<ItemUom?>> GetItemUomList() =>
            await this.Find().ToListAsync();

    }
}
