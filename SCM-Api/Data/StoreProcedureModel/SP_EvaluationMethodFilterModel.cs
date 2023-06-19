namespace Data.StoreProcedureModel
{
    public class SP_EvaluationMethodFilterModel
    {
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
        /// Get or Set Status
        /// </summary>
        public string? Status { get; set; }
    }
}
