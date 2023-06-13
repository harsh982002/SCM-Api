using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ItemDepartmentMappingModel
    {
        /// <summary>
        /// Get or Set ItemId
        /// </summary>
        [Required(ErrorMessage = "ItemId is required.")]
        public int? ItemId { get; set; }

        /// <summary>
        /// Get or Set DepartmentId
        /// </summary>
        [Required(ErrorMessage = "DepartmentId is required.")]
        public int? DepartmentId { get; set; }

    }
}
