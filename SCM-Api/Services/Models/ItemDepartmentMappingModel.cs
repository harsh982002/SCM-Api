using System.ComponentModel.DataAnnotations;

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
