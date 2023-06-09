﻿namespace Services.Models
{
    using System.ComponentModel.DataAnnotations;

    public class DepartmentModel
    {
        /// <summary>
        /// Get or Set DepartmentId
        /// </summary>
        [Required(ErrorMessage = "DepartmentId is required.")]
        public int DepartmentId { get; set; }

        /// <summary>
        /// Get or Set Name
        /// </summary>
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = null!;
    }
}
