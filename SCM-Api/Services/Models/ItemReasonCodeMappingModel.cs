using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class ItemReasonCodeMappingModel
    {
        /// <summary>
        /// Get or Set ItemId
        /// </summary>
        [Required(ErrorMessage = "ItemId is required.")]
        public int? ItemId { get; set; }

        /// <summary>
        /// Get or Set ReasonCodeId
        /// </summary>
        [Required(ErrorMessage = "ReasonCodeId is required.")]
        public byte? ReasonCodeId { get; set; }
    }
}
