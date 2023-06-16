namespace Services.Contract
{
    using Services.Models;

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
