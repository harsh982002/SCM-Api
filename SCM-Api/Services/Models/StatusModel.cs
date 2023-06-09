﻿using System.ComponentModel.DataAnnotations;

namespace Services.Models
{
    public class StatusModel
    {
        /// <summary>
        /// Get or Set StatusId
        /// </summary>
        [Required(ErrorMessage = "StatusId is required.")]
        public byte StatusId { get; set; }

        /// <summary>
        /// Get or Set Name
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = null!;
    }
}
