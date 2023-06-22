using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("statuses")]
public partial class Status
{
    [Key]
    [Column("status_id")]
    public byte StatusId { get; set; }

    [Column("name")]
    [StringLength(16)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Status")]
    public virtual ICollection<EvaluationMethod> EvaluationMethods { get; set; } = new List<EvaluationMethod>();
}
