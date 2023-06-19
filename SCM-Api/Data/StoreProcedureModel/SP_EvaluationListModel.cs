namespace Data.StoreProcedureModel
{
    public class SP_EvaluationListModel
    {
        public string Method { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal ThresholdFrom { get; set; }

        public decimal ThresholdTo { get; set; }

        public string Status { get; set; } = string.Empty;
    }
}
