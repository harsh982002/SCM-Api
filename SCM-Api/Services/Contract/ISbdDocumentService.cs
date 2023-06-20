namespace Services.Contract
{
    using Data.Entities;

    public interface ISbdDocumentService
    {
        Task<SbdDocument?> GetById(int SbdDocumentId);
    }
}
