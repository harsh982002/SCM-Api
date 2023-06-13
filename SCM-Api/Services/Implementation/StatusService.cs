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

        /// <summary>
        /// Get Status list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The StatusModel.</returns>
        public async Task<IEnumerable<Status?>> GetStatusList()=>
            await this.Find().ToListAsync();
    }
}
