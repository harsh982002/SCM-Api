using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IPurchaseCategoryService
    {
        /// <summary>
        /// Get PurchaseCategory list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The PurchaseCategoryModel.</returns>
        Task<IEnumerable<PurchaseCategory>> GetPurchaseCategoryList();
    }
}
