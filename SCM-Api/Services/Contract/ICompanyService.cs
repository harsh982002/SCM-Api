using Data.Entities;

namespace Services.Contract
{
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
