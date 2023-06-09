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

        public async Task<PurchaseCategory?> GetItemAvailabilityById(byte PurchaseCategoryId) =>
            await this.Find(x => x.PurchaseCategoryId == PurchaseCategoryId).FirstOrDefaultAsync();

        public async Task<IEnumerable<PurchaseCategoryModel>> GetItemAvailabilityList() =>
            await this.Find().Select(x=> new PurchaseCategoryModel
            {
                PurchaseCategoryId = x.PurchaseCategoryId,
                Name = x.Name,
            }).ToListAsync();
    }
}
