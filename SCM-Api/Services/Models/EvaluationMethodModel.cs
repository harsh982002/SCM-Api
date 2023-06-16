namespace Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class EvaluationMethodModel
    {
        /// <summary>
        /// Get or Set Method
        /// </summary>
        [Required(ErrorMessage = "Method is required.")]
        public string Method { get; set; } = null!;

        /// <summary>
        /// Get or Set Description
        /// </summary>
        [Required(ErrorMessage = "Description is required.")]
        [MaxLength(250, ErrorMessage = "Description should not be more than 250 characters.")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Get or Set ThresholdFrom
        /// </summary>
        [Required(ErrorMessage = "ThresholdFrom is required.")]
        public decimal ThresholdFrom { get; set; }

        /// <summary>
        /// Get or Set ThresholdTo
        /// </summary>
        [Required(ErrorMessage = "ThresholdTo is required.")]
        public decimal ThresholdTo { get; set; }

        /// <summary>
        /// Get or Set StatusId
        /// </summary>
        [Required(ErrorMessage = "StatusId is required.")]
        public byte StatusId { get; set; }

    }
}
