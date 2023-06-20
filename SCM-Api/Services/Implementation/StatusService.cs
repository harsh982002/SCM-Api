namespace Services.Implementation
{
    using Data.Context;
    using Data.Entities;
    using Data.Repository;
    using Microsoft.EntityFrameworkCore;
    using Services.Contract;
    using Services.Models;

    public class StatusService : RepositoryBase<Status>, IStatusService
    {
        public StatusService(Context context) : base(context)
        {

        }

        /// <summary>
        /// Get Status list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The StatusModel.</returns>
        public async Task<IEnumerable<StatusModel?>> GetStatusList() =>
            await this.Find().Select(x => new StatusModel
            {
                StatusId = x.StatusId,
                Name = x.Name,
            }).ToListAsync();
    }
}
