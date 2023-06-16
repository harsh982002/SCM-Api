namespace Services.Contract
{
    using Data.Entities;

    public interface IItemReasonCodesService
    {
        /// <summary>
        /// Save ItemReasoncode data.
        /// </summary>
        /// <param name="itemReasoncode">itemReasoncode.</param>
        /// <returns>The ItemReasoncodeId.</returns>
        Task<int> Save(ItemReasoncode itemReasoncode);

        /// <summary>
        /// Delete ItemReasoncode data.
        /// </summary>
        /// <param name="itemReasoncode">itemReasoncode.</param>
        /// <returns>The bool response.</returns>
        Task<bool> Delete(ItemReasoncode itemReasoncode);

        /// <summary>
        /// Get ItemReasoncode list based on ItemId.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ItemReasoncode Model.</returns>
        Task<IEnumerable<ItemReasoncode?>> GetItemReasonCodeList(int ItemId);

        /// <summary>
        /// Save multiple data to ItemReasoncode Model
        /// </summary>
        /// <param name="itemReasoncode">itemReasoncode</param>
        Task SaveMultipleReasonCodes(List<ItemReasoncode> itemReasoncode);
    }
}
