using Data.Entities;

namespace Services.Contract
{
    public interface IItemReasonCodesService
    {
        /// <summary>
        /// Save ItemReasoncodesMapping data.
        /// </summary>
        /// <param name="itemReasoncodesMapping">itemReasoncodesMapping.</param>
        /// <returns>The ItemReasoncodeId.</returns>
        Task<int> Save(ItemReasoncodesMapping itemReasoncodesMapping);

        /// <summary>
        /// Delete ItemReasoncodesMapping data.
        /// </summary>
        /// <param name="itemReasoncodesMapping">itemReasoncodesMapping.</param>
        /// <returns>The bool response.</returns>
        Task<bool> Delete(ItemReasoncodesMapping itemReasoncodesMapping);

        /// <summary>
        /// Get ItemReasoncodesMapping list based on ItemId.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ItemReasoncodesMapping Model.</returns>
        Task<IEnumerable<ItemReasoncodesMapping?>> GetItemReasonCodeList(int ItemId);

        /// <summary>
        /// Save multiple data to ItemReasoncodesMapping Model
        /// </summary>
        /// <param name="itemReasoncodesMappings">itemReasoncodesMappings</param>
        Task SaveMultipleReasonCodes(List<ItemReasoncodesMapping> itemReasoncodesMappings);
    }
}
