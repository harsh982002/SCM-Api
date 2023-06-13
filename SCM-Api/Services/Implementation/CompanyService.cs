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

        /// <summary>
        /// Get Company list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The CompanyModel.</returns>
        public async Task<IEnumerable<Company?>> GetCompanyList() =>
            await this.Find().ToListAsync();
        
    }
}
 