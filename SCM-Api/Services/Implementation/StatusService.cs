using Data.Context;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Contract;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    public class StatusService : RepositoryBase<Status> , IStatusService
    {
        public StatusService(Context context) : base(context)
        {

        }

        public async Task<IEnumerable<StatusModel?>> GetStatusList() =>
            await this.Find().Select(x => new StatusModel
            {
                StatusId = x.StatusId,
                Name = x.Name,
            }).ToListAsync();
    }
}
