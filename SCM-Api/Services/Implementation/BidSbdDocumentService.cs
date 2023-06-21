namespace Services.Implementation
{
    using Common.Helpers;
    using Data.Context;
    using Data.Entities;
    using Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using Services.Contract;
    using System.Threading.Tasks;

    public class BidSbdDocumentService : RepositoryBase<BidSbdDocument>, IBidSbdDocumentService
    {
        private readonly ISbdDocumentService _sbdDocumentService;
        public BidSbdDocumentService(Context context, ISbdDocumentService sbdDocumentService) : base(context)
        {
            _sbdDocumentService = sbdDocumentService;
        }

        /// <summary>
        /// Save/Update BidSbdDocument data.
        /// </summary>
        /// <param name="bidSbdDocument"></param>
        /// <returns>The BidSbdDocumentId</returns>
        public async Task<int> SaveUpdate(BidSbdDocument bidSbdDocument)
        {
            BidSbdDocument? oldBidSbdDocument = await this.Find(x => x.BidId == bidSbdDocument.BidId && x.SbdDocumentId == bidSbdDocument.SbdDocumentId).FirstOrDefaultAsync();
            if (oldBidSbdDocument == null)
            {
                bidSbdDocument.CreatedDate = Helper.GetCurrentUTCDateTime();
                this.CreateEntity(bidSbdDocument);
                await this.SaveAsync();
                return bidSbdDocument.BidSbdDocumentId;
            }
            else
            {
                oldBidSbdDocument.SbdDocumentValue = bidSbdDocument.SbdDocumentValue;
                oldBidSbdDocument.UpdatedDate = Helper.GetCurrentUTCDateTime();

                this.UpdateEntity(oldBidSbdDocument);
                await this.SaveAsync();
                return oldBidSbdDocument.BidSbdDocumentId;
            }

        }

        /// <summary>
        /// Get BidSbdDocument data by Id
        /// </summary>
        /// <param name="bidSbdDocumentId"></param>
        /// <returns>The BidSbdDocument Model</returns>
        public async Task<BidSbdDocument?> GetById(int bidSbdDocumentId) =>
            await this.Find(x => x.BidSbdDocumentId == bidSbdDocumentId).FirstOrDefaultAsync();

    }
}
