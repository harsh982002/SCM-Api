namespace Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ItemModel
    {
        /// <summary>
        /// Get or Set Name
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Get or Set Description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Get or Set ItemSegment
        /// </summary>
        [Required(ErrorMessage = "ItemSegment is required.")]
        public string ItemSegment { get; set; } = null!;

        /// <summary>
        /// Get or Set ItemType
        /// </summary>
        [Required(ErrorMessage = "ItemType is required.")]
        public string ItemType { get; set; } = null!;

        /// <summary>
        /// Get or Set RegulatedUnitCost
        /// </summary>
        [Required(ErrorMessage = "RegulatedUnitCost is required.")]
        public string? RegulatedUnitCost { get; set; }

        /// <summary>
        /// Get or Set CompanyId
        /// </summary>
        [Required(ErrorMessage = "CompanyId is required.")]
        public byte? CompanyId { get; set; }

        /// <summary>
        /// Get or Set ItemUomId
        /// </summary>
        [Required(ErrorMessage = "ItemUomId is required.")]
        public byte? ItemUomId { get; set; }

        /// <summary>
        /// Get or Set ItemAvailabilityId
        /// </summary>
        [Required(ErrorMessage = "ItemAvailabilityId is required.")]
        public byte? ItemAvailabilityId { get; set; }

        /// <summary>
        /// Get or Set StatusId
        /// </summary>
        [Required(ErrorMessage = "StatusId is required.")]
        public byte? StatusId { get; set; }

        /// <summary>
        /// Get or Set PurchaseCategoryId
        /// </summary>
        [Required(ErrorMessage = "PurchaseCategoryId is required.")]
        public byte? PurchaseCategoryId { get; set; }

        /// <summary>
        /// Get or Set Departments
        /// </summary>
        public List<int> Departments { get; set; } = new List<int>();

        /// <summary>
        /// Get or Set ReasonCodes
        /// </summary>
        public List<byte> ReasonCodes { get; set; } = new List<byte>();

    }
}
