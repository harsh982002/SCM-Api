using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ItemAvailabilityModel
    {
        /// <summary>
        /// Get or Set ItemAvailabilityId
        /// </summary>
        [Required(ErrorMessage = "ItemAvailabilityId is required.")]
        public byte ItemAvailabilityId { get; set; }

        /// <summary>
        /// Get or Set Name
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = null!;
    }
}
