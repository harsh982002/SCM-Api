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
        /// Get Department list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The DepartmentModel.</returns>
        Task<IEnumerable<DepartmentModel?>> GetDepartmentList();
    }
}
