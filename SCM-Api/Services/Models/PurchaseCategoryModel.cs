using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class PurchaseCategoryModel
    {
        /// <summary>
        /// Get or Set PurchaseCategoryId
        /// </summary>
        [Required(ErrorMessage = "PurchaseCategoryId is required.")]
        public byte PurchaseCategoryId { get; set; }

        /// <summary>
        /// Get or Set Name
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = null!;
    }
}
