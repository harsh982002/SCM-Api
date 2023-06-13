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

        /// <summary>
        /// Get ItemAvailability list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ItemAvailabilityModel.</returns>
        public async Task<IEnumerable<ItemAvailabilityModel>> GetItemAvailabilityList() =>
            await this.Find().Select(x => new ItemAvailabilityModel
            {
                ItemAvailabilityId = x.ItemAvailabilityId,
                Name = x.Name,
            }).ToListAsync();

        /// <summary>
        /// Get ItemAvailability data by ItemAvailabilityId.
        /// </summary>
        /// <param name="ItemAvailabilityId">The ItemAvailabilityId.</param>
        /// <returns>The ItemAvailability model.</returns>
        public async Task<ItemAvailability?> GetItemAvailabilityById(byte ItemAvailabilityId) =>
            await this.Find(x=>x.ItemAvailabilityId == ItemAvailabilityId).FirstOrDefaultAsync();
    }
}
