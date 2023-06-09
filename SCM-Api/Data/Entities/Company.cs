using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

[Table("company")]
public partial class Company
{
    [Key]
    [Column("company_id")]
    public byte CompanyId { get; set; }

    [Column("name")]
    [StringLength(5)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Company")]
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
