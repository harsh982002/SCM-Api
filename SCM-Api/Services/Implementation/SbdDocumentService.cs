namespace Services.Implementation
{
    using Data.Context;
    using Data.Entities;
    using Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using Services.Contract;

    public class SbdDocumentService : RepositoryBase<SbdDocument>, ISbdDocumentService
    {
        public SbdDocumentService(Context context): base(context)
        {

        }

        public async Task<SbdDocument?> GetById(int SbdDocumentId) =>
            await this.Find(x => x.SbdDocumentId == SbdDocumentId).FirstOrDefaultAsync();
    }
}
