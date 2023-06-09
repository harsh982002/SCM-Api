﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("items")]
public partial class Item
{
    [Key]
    [Column("item_id")]
    public int ItemId { get; set; }

    [Column("name")]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("description")]
    [StringLength(250)]
    [Unicode(false)]
    public string? Description { get; set; }

    [Column("item_segment")]
    [StringLength(50)]
    [Unicode(false)]
    public string ItemSegment { get; set; } = null!;

    [Column("item_type")]
    [StringLength(100)]
    [Unicode(false)]
    public string ItemType { get; set; } = null!;

    [Column("regulated_unit_cost")]
    [StringLength(50)]
    [Unicode(false)]
    public string? RegulatedUnitCost { get; set; }

    [Column("company_id")]
    public byte? CompanyId { get; set; }

    [Column("item_uom_id")]
    public byte? ItemUomId { get; set; }

    [Column("item_availability_id")]
    public byte? ItemAvailabilityId { get; set; }

    [Column("status_id")]
    public byte? StatusId { get; set; }

    [Column("created_time", TypeName = "datetime")]
    public DateTime CreatedTime { get; set; }

    [Column("updated_time", TypeName = "datetime")]
    public DateTime? UpdatedTime { get; set; }

    [Column("purchase_category_id")]
    public byte PurchaseCategoryId { get; set; }

    [InverseProperty("Item")]
    public virtual ICollection<ItemDepartment> ItemDepartments { get; set; } = new List<ItemDepartment>();

    [InverseProperty("Item")]
    public virtual ICollection<ItemReasoncode> ItemReasoncodes { get; set; } = new List<ItemReasoncode>();
}
