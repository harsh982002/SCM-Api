using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.StoreProcedureModel
{
    public class SP_ItemFilterModel
    {
        /// <summary>
        /// Get or Set SearchText
        /// </summary>
        public string? SearchText { get; set; }

        /// <summary>
        /// Get or Set SortColumn
        /// </summary>
        public string? SortColumn { get; set; }

        /// <summary>
        /// Get or Set SortOrder
        /// </summary>
        public string? SortOrder { get; set; }

        /// <summary>
        /// Get or Set PageNumber
        /// </summary>
        public int PageNumber { get; set; }

        /// <summary>
        /// Get or Set PageSize
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Get or Set CompanyId
        /// </summary>
        public int? CompanyId { get; set; }

        /// <summary>
        /// Get or Set PurchaseCategoryId
        /// </summary>
        public int? PurchaseCategoryId { get; set; }

        /// <summary>
        /// Get or Set ItemUOMId
        /// </summary>
        public int? ItemUOMId { get; set; }

        /// <summary>
        /// Get or Set AvailabilityId
        /// </summary>
        public int? AvailabilityId { get; set; }

        /// <summary>
        /// Get or Set StatusId
        /// </summary>
        public int? StatusId { get; set; }

        /// <summary>
        /// Get or Set ReasonCodeId
        /// </summary>
        public int? ReasonCodeId { get; set; }

    }
}
