using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ItemUomModel
    {
        /// <summary>
        /// Get or Set ItemUomId
        /// </summary>
        [Required(ErrorMessage = "ItemUomId is required.")]
        public byte ItemUomId { get; set; }

        /// <summary>
        /// Get or Set Name
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = null!;
    }
}
