using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

[PrimaryKey("ItemId", "DepartmentId")]
[Table("item_department_mapping")]
public partial class ItemDepartmentMapping
{
    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Key]
    [Column("department_id")]
    public int DepartmentId { get; set; }

    [Column("deleted_date", TypeName = "datetime")]
    public DateTime? DeletedDate { get; set; }

    [ForeignKey("DepartmentId")]
    [InverseProperty("ItemDepartmentMappings")]
    public virtual Department Department { get; set; } = null!;

    [ForeignKey("ItemId")]
    [InverseProperty("ItemDepartmentMappings")]
    public virtual Item Item { get; set; } = null!;
}
