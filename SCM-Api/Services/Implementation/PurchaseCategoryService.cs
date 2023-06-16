namespace Services.Implementation
{
    using Data.Context;
    using Data.Entities;
    using Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using Services.Contract;

    public class PurchaseCategoryService : RepositoryBase<PurchaseCategory>, IPurchaseCategoryService
    {
        public PurchaseCategoryService(Context context) : base(context)
        {

        }

        /// <summary>
        /// Get PurchaseCategory list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The PurchaseCategoryModel.</returns>
        public async Task<IEnumerable<PurchaseCategory>> GetPurchaseCategoryList() =>
            await this.Find().ToListAsync();
    }
}
