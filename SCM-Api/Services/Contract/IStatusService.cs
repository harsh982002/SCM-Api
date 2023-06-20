namespace Services.Contract
{
    using Services.Models;

    public interface IStatusService
    {
        /// <summary>
        /// Get Status list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The StatusModel.</returns>
        Task<IEnumerable<StatusModel?>> GetStatusList();

    }
}
