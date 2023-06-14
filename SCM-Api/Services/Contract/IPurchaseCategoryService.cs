using Data.Entities;

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
