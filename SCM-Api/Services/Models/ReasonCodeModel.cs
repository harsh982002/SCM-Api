﻿namespace Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ReasonCodeModel
    {
        /// <summary>
        /// Get or Set ReasonCodeId
        /// </summary>
        [Required(ErrorMessage = "ReasonCodeId is required.")]
        public byte ReasonCodeId { get; set; }

        /// <summary>
        /// Get or Set Name
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = null!;
    }
}
