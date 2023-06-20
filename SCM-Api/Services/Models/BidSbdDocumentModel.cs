namespace Services.Models
{
    public class BidSbdDocumentModel
    {
        /// <summary>
        /// Get or Set SbdDocumentId
        /// </summary>
        public int SbdDocumentId { get; set; }

        /// <summary>
        /// Get or Set SbdDocumentValue
        /// </summary>
        public IEnumerable<SbdBidDocumentValueJsonModel>? SbdDocumentValue { get; set; }
    }
}
