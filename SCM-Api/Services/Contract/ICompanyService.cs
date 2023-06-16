namespace Services.Contract
{
    using Data.Entities;

    public interface ICompanyService
    {
        /// <summary>
        /// Get Company list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The CompanyModel.</returns>
        Task<IEnumerable<Company?>> GetCompanyList();
    }
}
