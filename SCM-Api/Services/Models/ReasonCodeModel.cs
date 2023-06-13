using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class ReasonCodeModel
    {
        /// <summary>
        /// Get or Set ReasonCodeId
        /// </summary>
        [Required(ErrorMessage = "ReasonCodeId is required.")]
        public byte ReasonCodeId { get; set; }

        /// <summary>
        /// Get or Set Name
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = null!;
    }
}
