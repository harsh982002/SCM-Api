namespace Data.StoreProcedureModel
{
    public class SP_ItemFilterModel
    {
        /// <summary>
        /// Get or Set SearchText
        /// </summary>
        public string? SearchText { get; set; }

        /// <summary>
        /// Get or Set SortColumn
        /// </summary>
        public string? SortColumn { get; set; }

        /// <summary>
        /// Get or Set SortOrder
        /// </summary>
        public string? SortOrder { get; set; }

        /// <summary>
        /// Get or Set PageNumber
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Get or Set PageSize
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Get or Set CompanyId
        /// </summary>
        public string? Company { get; set; }

        /// <summary>
        /// Get or Set PurchaseCategoryId
        /// </summary>
        public string? PurchaseCategory { get; set; }

        /// <summary>
        /// Get or Set ItemUOMId
        /// </summary>
        public string? ItemUOM { get; set; }

        /// <summary>
        /// Get or Set AvailabilityId
        /// </summary>
        public string? Availability { get; set; }

        /// <summary>
        /// Get or Set StatusId
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Get or Set ReasonCodeId
        /// </summary>
        public string? ReasonCode { get; set; }

    }
}
