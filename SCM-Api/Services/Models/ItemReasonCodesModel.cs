namespace Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ItemReasonCodesModel
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
