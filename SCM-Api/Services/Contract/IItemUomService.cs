using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IItemUomService
    {
        /// <summary>
        /// Get ItemUom list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ItemUomModel.</returns>
        Task<IEnumerable<ItemUom?>> GetItemUomList();
    }
}
