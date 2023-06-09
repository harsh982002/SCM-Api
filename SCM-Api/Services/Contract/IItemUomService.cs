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
        Task<ItemUom?> GetItemUomById(byte ItemUomId);

        Task<IEnumerable<ItemUomModel?>> GetItemUomList();
    }
}
