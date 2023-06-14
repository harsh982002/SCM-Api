using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("purchase_categories")]
public partial class PurchaseCategory
{
    [Key]
    [Column("purchase_category_id")]
    public byte PurchaseCategoryId { get; set; }

    [Column("name")]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;
}
