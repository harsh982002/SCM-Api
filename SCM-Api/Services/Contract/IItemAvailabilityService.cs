namespace Services.Contract
{
    using Data.Entities;

    public interface IItemAvailabilityService
    {
        /// <summary>
        /// Get ItemAvailability list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ItemAvailabilityModel.</returns>
        Task<IEnumerable<ItemAvailability>> GetItemAvailabilityList();
    }
}
