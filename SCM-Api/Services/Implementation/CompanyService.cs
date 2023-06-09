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
    public class CompanyService : RepositoryBase<Company>, ICompanyService
    {

        public CompanyService(Context context) : base(context)
        {
        }

        public async Task<IEnumerable<CompanyModel?>> GetCompanyList() =>
            await this.Find().Select(x => new CompanyModel
            {
                CompanyId = x.CompanyId,
                Name = x.Name,
            }).ToListAsync();

        public async Task<Company?> GetCompanyDetailById(byte CompanyId)=>
            await this.Find(x => x.CompanyId == CompanyId).FirstOrDefaultAsync();
        
    }
}
 