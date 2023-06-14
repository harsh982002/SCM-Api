using Data.Entities;

namespace Services.Contract
{
    public interface IStatusService
    {
        /// <summary>
        /// Get Status list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The StatusModel.</returns>
        Task<IEnumerable<Status?>> GetStatusList();

    }
}
