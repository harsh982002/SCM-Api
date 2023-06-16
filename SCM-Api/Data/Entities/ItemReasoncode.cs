using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("item_reasoncodes")]
public partial class ItemReasoncode
{
    [Key]
    [Column("item_reasoncode_id")]
    public int ItemReasoncodeId { get; set; }

    [Column("item_id")]
    public int? ItemId { get; set; }

    [Column("reason_code_id")]
    public byte? ReasonCodeId { get; set; }

    [Column("deleted_time", TypeName = "datetime")]
    public DateTime? DeletedTime { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("ItemReasoncodes")]
    public virtual Item? Item { get; set; }

    [ForeignKey("ReasonCodeId")]
    [InverseProperty("ItemReasoncodes")]
    public virtual ReasonCode? ReasonCode { get; set; }
}
