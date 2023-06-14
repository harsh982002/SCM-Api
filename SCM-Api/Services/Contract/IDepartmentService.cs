using Services.Models;

namespace Services.Contract
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Get Department list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The DepartmentModel.</returns>
        Task<IEnumerable<DepartmentModel?>> GetDepartmentList();
    }
}
