using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IDepartmentService
    {
        /// <summary>
        /// Get Department data by DepartmentId.
        /// </summary>
        /// <param name="DepartmentId">The DepartmentId.</param>
        /// <returns>The Department model.</returns>
        Task<Department?> GetDepartmentDetailById(byte DepartmentId);

        /// <summary>
        /// Get Department list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The DepartmentModel.</returns>
        Task<IEnumerable<DepartmentModel?>> GetDepartmentList();
    }
}
