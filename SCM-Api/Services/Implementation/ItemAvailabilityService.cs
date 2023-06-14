using Data.Context;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Contract;

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
        public async Task<IEnumerable<ItemAvailability>> GetItemAvailabilityList() =>
            await this.Find().ToListAsync();
    }
}
