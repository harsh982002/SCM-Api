using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("item_departments")]
public partial class ItemDepartment
{
    [Key]
    [Column("item_department_id")]
    public int ItemDepartmentId { get; set; }

    [Column("item_id")]
    public int? ItemId { get; set; }

    [Column("department_id")]
    public int? DepartmentId { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("ItemDepartments")]
    public virtual Department? Department { get; set; }

    [ForeignKey("ItemId")]
    [InverseProperty("ItemDepartments")]
    public virtual Item? Item { get; set; }
}
