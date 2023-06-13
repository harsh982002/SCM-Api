using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
