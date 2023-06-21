namespace Services.Implementation
{
    using Data.Context;
    using Data.Entities;
    using Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using Services.Contract;

    public class SbdDocumentService : RepositoryBase<SbdDocument>, ISbdDocumentService
    {
        public SbdDocumentService(Context context) : base(context)
        {

        }

        /// <summary>
        /// Get SbdDocument data By Id.
        /// </summary>
        /// <param name="SbdDocumentId"></param>
        /// <returns>The SbdDocument Model.</returns>
        public async Task<SbdDocument?> GetById(int SbdDocumentId) =>
            await this.Find(x => x.SbdDocumentId == SbdDocumentId).FirstOrDefaultAsync();
    }
}
