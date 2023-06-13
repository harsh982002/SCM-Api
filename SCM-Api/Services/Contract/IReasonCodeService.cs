using Data.Entities;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contract
{
    public interface IReasonCodeService
    {
        /// <summary>
        /// Get ReasonCode list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ReasonCodeModel.</returns>
        Task<IEnumerable<ReasonCode?>> GetReasonCodeList();
    }
}
