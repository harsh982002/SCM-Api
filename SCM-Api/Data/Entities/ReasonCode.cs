using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

[Table("reason_codes")]
public partial class ReasonCode
{
    [Key]
    [Column("reason_code_id")]
    public byte ReasonCodeId { get; set; }

    [Column("name")]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("ReasonCode")]
    public virtual ICollection<ItemReasoncodesMapping> ItemReasoncodesMappings { get; set; } = new List<ItemReasoncodesMapping>();
}
