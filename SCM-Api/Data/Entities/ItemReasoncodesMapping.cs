using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

[PrimaryKey("ItemId", "ReasonCodeId")]
[Table("item_reasoncodes_mapping")]
public partial class ItemReasoncodesMapping
{
    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Key]
    [Column("reason_code_id")]
    public byte ReasonCodeId { get; set; }

    [Column("deleted_date", TypeName = "datetime")]
    public DateTime? DeletedDate { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("ItemReasoncodesMappings")]
    public virtual Item Item { get; set; } = null!;

    [ForeignKey("ReasonCodeId")]
    [InverseProperty("ItemReasoncodesMappings")]
    public virtual ReasonCode ReasonCode { get; set; } = null!;
}
