﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class GetItemCsvModel
    {
        /// <summary>
        /// Get or Set Item
        /// </summary>
        public string Item { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set Description
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set ItemCode
        /// </summary>
        public string ItemCode { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set ErbDbCompany
        /// </summary>
        public string ErbDbCompany { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set ItemUOM
        /// </summary>
        public string ItemUOM { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set PurchaseCategory
        /// </summary>
        public string PurchaseCategory { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set ReasonCode
        /// </summary>
        public string ReasonCode { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set Availability
        /// </summary>
        public string Availability { get; set; } = string.Empty;

        /// <summary>
        /// Get or Set Department
        /// </summary>
        public string Department { get; set; } = string.Empty;
    }
}
