using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("company")]
public partial class Company
{
    [Key]
    [Column("company_id")]
    public byte CompanyId { get; set; }

    [Column("name")]
    [StringLength(5)]
    [Unicode(false)]
    public string Name { get; set; } = null!;
}
