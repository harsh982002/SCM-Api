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
        /// Get ReasonCode data by ReasonCodeId.
        /// </summary>
        /// <param name="ReasonCodeId">The ReasonCodeId.</param>
        /// <returns>The ReasonCode model.</returns>
        Task<ReasonCode?> GetReasonCodeById(byte ReasonCodeId);

        /// <summary>
        /// Get ReasonCode list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ReasonCodeModel.</returns>
        Task<IEnumerable<ReasonCodeModel?>> GetReasonCodeList();
    }
}
