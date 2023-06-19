namespace Data.StoreProcedureModel
{
    public class SP_EvaluationListModel
    {
        /// <summary>
        /// Get or Set Method
        /// </summary>
        public string Method { get; set; } = null!;

        /// <summary>
        /// Get or Set Description
        /// </summary>
        public string Description { get; set; } = null!;

        /// <summary>
        /// Get or Set ThresholdFrom
        /// </summary>
        public decimal ThresholdFrom { get; set; }

        /// <summary>
        /// Get or Set ThresholdTo
        /// </summary>
        public decimal ThresholdTo { get; set; }

        /// <summary>
        /// Get or Set Status
        /// </summary>
        public string Status { get; set; } = string.Empty;
    }
}
