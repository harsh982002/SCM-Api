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
    public class ReasonCodeService : RepositoryBase<ReasonCode>, IReasonCodeService
    {
        public ReasonCodeService(Context context) : base(context)
        {

        }

        /// <summary>
        /// Get ReasonCode data by ReasonCodeId.
        /// </summary>
        /// <param name="ReasonCodeId">The ReasonCodeId.</param>
        /// <returns>The ReasonCode model.</returns>
        public async Task<ReasonCode?> GetReasonCodeById(byte ReasonCodeId) =>
            await this.Find(x => x.ReasonCodeId == ReasonCodeId).FirstOrDefaultAsync();

        /// <summary>
        /// Get ReasonCode list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ReasonCodeModel.</returns>
        public async Task<IEnumerable<ReasonCodeModel?>> GetReasonCodeList()=>
            await this.Find().Select(x=> new ReasonCodeModel
            {
                ReasonCodeId = x.ReasonCodeId,
                Name = x.Name,
            }).ToListAsync();
    }
}
