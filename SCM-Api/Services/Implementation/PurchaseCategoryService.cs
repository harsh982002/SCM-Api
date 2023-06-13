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
    public class PurchaseCategoryService : RepositoryBase<PurchaseCategory>, IPurchaseCategoryService
    {
        public PurchaseCategoryService(Context context) : base(context)
        {

        }

        /// <summary>
        /// Get PurchaseCategory data by PurchaseCategoryId.
        /// </summary>
        /// <param name="PurchaseCategoryId">The PurchaseCategoryId.</param>
        /// <returns>The PurchaseCategory model.</returns>
        public async Task<PurchaseCategory?> GetPurchaseCategoryById(byte PurchaseCategoryId) =>
            await this.Find(x => x.PurchaseCategoryId == PurchaseCategoryId).FirstOrDefaultAsync();

        /// <summary>
        /// Get PurchaseCategory list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The PurchaseCategoryModel.</returns>
        public async Task<IEnumerable<PurchaseCategoryModel>> GetPurchaseCategoryList() =>
            await this.Find().Select(x=> new PurchaseCategoryModel
            {
                PurchaseCategoryId = x.PurchaseCategoryId,
                Name = x.Name,
            }).ToListAsync();
    }
}
