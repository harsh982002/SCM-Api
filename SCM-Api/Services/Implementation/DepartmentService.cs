using Data.Context;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Contract;
using Services.Models;

namespace Services.Implementation
{
    public class DepartmentService : RepositoryBase<Department>, IDepartmentService
    {
        public DepartmentService(Context context) : base(context)
        {
        }

        /// <summary>
        /// Get Department list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The DepartmentModel.</returns>
        public async Task<IEnumerable<DepartmentModel?>> GetDepartmentList() =>
            await this.Find().Select(x => new DepartmentModel
            {
                DepartmentId = x.DepartmentId,
                Name = x.Name,
            }).ToListAsync();
    }
}
