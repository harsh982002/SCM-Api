using Data.Entities;

namespace Services.Contract
{
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
