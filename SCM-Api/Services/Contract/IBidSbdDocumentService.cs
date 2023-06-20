namespace Services.Contract
{
    using Data.Entities;

    public interface IBidSbdDocumentService
    {
        /// <summary>
        /// Add/Update BidSbdDocument
        /// </summary>
        /// <param name="bidSbdDocument"></param>
        /// <returns>The BidSbdDocumentId.</returns>
        Task<int> AddUpdate(BidSbdDocument bidSbdDocument);

        /// <summary>
        /// Get BidSbdDocument data by Id
        /// </summary>
        /// <param name="bidSbdDocumentId"></param>
        /// <returns>The BidSbdDocument Model</returns>
        Task<BidSbdDocument?> GetById(int bidSbdDocumentId);
    }
}
