using Data.Context;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Contract;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class DepartmentService : RepositoryBase<Department>, IDepartmentService
    {
        public DepartmentService(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<DepartmentModel?>> GetDepartmentList() =>
            await this.Find().Select(x => new DepartmentModel
            {
                DepartmentId = x.DepartmentId,
                Name = x.Name,
            }).ToListAsync();

        public async Task<Department?> GetDepartmentDetailById(byte DepartmentId) =>
            await this.Find(x=>x.DepartmentId == DepartmentId).FirstOrDefaultAsync();
    }
}
