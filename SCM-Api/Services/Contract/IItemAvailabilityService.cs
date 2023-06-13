using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IItemAvailabilityService
    {
        /// <summary>
        /// Get ItemAvailability data by ItemAvailabilityId.
        /// </summary>
        /// <param name="ItemAvailabilityId">The ItemAvailabilityId.</param>
        /// <returns>The ItemAvailability model.</returns>
        Task<ItemAvailability?> GetItemAvailabilityById(byte ItemAvailabilityId);

        /// <summary>
        /// Get ItemAvailability list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ItemAvailabilityModel.</returns>
        Task<IEnumerable<ItemAvailabilityModel>> GetItemAvailabilityList();
    }
}
