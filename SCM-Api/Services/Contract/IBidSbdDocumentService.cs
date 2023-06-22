namespace Services.Contract
{
    using Data.Entities;

    public interface IBidSbdDocumentService
    {
        /// <summary>
        /// Get BidSbdDocument data by Id
        /// </summary>
        /// <param name="sbdDocumentId">sbdDocumentId</param>
        /// <param name="bidId">bidId</param>
        /// <returns>The BidSbdDocument Model</returns>
        Task<BidSbdDocument?> GetById(int sbdDocumentId, int bidId);

        /// <summary>
        /// Save/Update the BidSbdDocument data.
        /// </summary>
        /// <param name="bidSbdDocument"></param>
        /// <returns>The BidSbdDocumentId.</returns>
        Task<int> SaveUpdate(BidSbdDocument bidSbdDocument);
    }
}
