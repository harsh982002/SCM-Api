using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

[Table("statuses")]
public partial class Status
{
    [Key]
    [Column("status_id")]
    public byte StatusId { get; set; }

    [Column("name")]
    [StringLength(16)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
