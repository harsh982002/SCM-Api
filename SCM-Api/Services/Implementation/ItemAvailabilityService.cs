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
    public class ItemAvailabilityService : RepositoryBase<ItemAvailability>, IItemAvailabilityService
    {
        public ItemAvailabilityService(Context context) : base(context)
        {

        }

        public async Task<IEnumerable<ItemAvailabilityModel>> GetItemAvailabilityList() =>
            await this.Find().Select(x => new ItemAvailabilityModel
            {
                ItemAvailabilityId = x.ItemAvailabilityId,
                Name = x.Name,
            }).ToListAsync();

        public async Task<ItemAvailability?> GetItemAvailabilityById(byte ItemAvailabilityId) =>
            await this.Find(x=>x.ItemAvailabilityId == ItemAvailabilityId).FirstOrDefaultAsync();
    }
}
