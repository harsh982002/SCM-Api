using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
