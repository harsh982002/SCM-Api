namespace Services.Contract
{
    using Data.Entities;

    public interface IItemUomService
    {
        /// <summary>
        /// Get ItemUom list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ItemUomModel.</returns>
        Task<IEnumerable<ItemUom?>> GetItemUomList();
    }
}
