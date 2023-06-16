namespace Services.Contract
{
    using Data.Entities;

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
