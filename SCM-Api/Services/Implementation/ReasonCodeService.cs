﻿using Data.Context;
using Data.Entities;
using Data.Repository;
using Microsoft.EntityFrameworkCore;
using Services.Contract;

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
        public async Task<IEnumerable<ReasonCode?>> GetReasonCodeList() =>
            await this.Find().ToListAsync();
    }
}
