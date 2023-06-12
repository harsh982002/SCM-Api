using Common.Helpers;
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
    public class ItemService : RepositoryBase<Item>, IItemService
    {
        public ItemService(Context context) : base(context)
        {

        }

        public async Task<bool> AlreadyExist(ItemModel model)
        {
            var ExistedItem = await this.Find(x=>x.Name == model.Name && x.ItemSegment == model.ItemSegment).AnyAsync();
            if (ExistedItem)
            {
                return true;
            }
            return false;
        }

        public async Task<int> Delete(Item item)
        {
            item.DeletedTime = Helper.GetCurrentUTCDateTime();
            this.UpdateEntity(item);
            await this.SaveAsync();
            return (item.ItemId);
        }

        public async Task<Item?> GetById(int ItemId)=>
            await this.Find(x=>x.ItemId == ItemId).FirstOrDefaultAsync();

        public async Task<int> Save(Item item)
        {
           item.CreatedTime = Helper.GetCurrentUTCDateTime();
           this.CreateEntity(item);
           await this.SaveAsync();
           return (item.ItemId);
        }

        public async Task<int> Update(Item item)
        {
            item.UpdatedTime = Helper.GetCurrentUTCDateTime();
            this.UpdateEntity(item);
            await this.SaveAsync();
            return (item.ItemId);
        }

        public async Task UpdateItemStatus(Item item,byte Status)
        {
            item.StatusId = Status;
            this.UpdateEntity(item);
            await this.SaveAsync();
        }
    }
}
