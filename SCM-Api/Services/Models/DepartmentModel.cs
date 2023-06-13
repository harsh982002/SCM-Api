using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class DepartmentModel
    {
        /// <summary>
        /// Get or Set DepartmentId
        /// </summary>
        [Required(ErrorMessage = "DepartmentId is required.")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Get or Set Name
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = null!;
    }
}
