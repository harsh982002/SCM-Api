using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

[Table("item_uom")]
public partial class ItemUom
{
    [Key]
    [Column("item_uom_id")]
    public byte ItemUomId { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("ItemUom")]
    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}
