using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("item_department_mapping")]
public partial class ItemDepartmentMapping
{
    [Key]
    [Column("item_department_id")]
    public int ItemDepartmentId { get; set; }

    [Column("item_id")]
    public int? ItemId { get; set; }

    [Column("department_id")]
    public int? DepartmentId { get; set; }

    [Column("deleted_time", TypeName = "datetime")]
    public DateTime? DeletedTime { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("ItemDepartmentMappings")]
    public virtual Department? Department { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("ItemDepartmentMappings")]
    public virtual Item? Item { get; set; }
}
