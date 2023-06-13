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
        /// Get ItemAvailability list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ItemAvailabilityModel.</returns>
        Task<IEnumerable<ItemAvailability>> GetItemAvailabilityList();
    }
}
