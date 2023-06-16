namespace Services.Contract
{
    using Data.Entities;

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
