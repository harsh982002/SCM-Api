namespace Services.Models
{

    public class SbdBidDocumentValueJsonModel
    {
        /// <summary>
        /// Get or Set Name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set Value
        /// </summary>
        public dynamic? Value { get; set; }

        /// <summary>
        /// Get or Set ControlType
        /// </summary>
        public string ControlType { get; set; } = string.Empty;
    }
}
