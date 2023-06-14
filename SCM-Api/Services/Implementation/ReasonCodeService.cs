using Data.Context;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Contract;
using Services.Models;

namespace Services.Implementation
{
    public class ReasonCodeService : RepositoryBase<ReasonCode>, IReasonCodeService
    {
        public ReasonCodeService(Context context) : base(context)
        {

        }

        /// <summary>
        /// Get ReasonCode list.
        /// </summary>
        /// <param name=""></param>
        /// <returns>The ReasonCodeModel.</returns>
        public async Task<IEnumerable<ReasonCodeModel?>> GetReasonCodeList() =>
            await this.Find().Select(x=> new ReasonCodeModel
            {
                Name = x.Name,
                ReasonCodeId = x.ReasonCodeId,
            }).ToListAsync();
    }
}
