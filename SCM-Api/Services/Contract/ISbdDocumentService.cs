namespace Services.Contract
{
    using Data.Entities;

    public interface ISbdDocumentService
    {
        /// <summary>
        /// Get SbdDocument data by Id.
        /// </summary>
        /// <param name="SbdDocumentId"></param>
        /// <returns>The SbdDocument Model.</returns>
        Task<SbdDocument?> GetById(int SbdDocumentId);
    }
}
