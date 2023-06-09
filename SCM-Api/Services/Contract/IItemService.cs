using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IItemService
    {
        Task<int> Save(Item item);

        Task<bool> AlreadyExist(ItemModel model);

        Task<Item?> GetById(int ItemId);

        Task<int> Update(Item item);
    }
}
