using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("evaluation_methods")]
public partial class EvaluationMethod
{
    [Key]
    [Column("evaluation_method_id")]
    public int EvaluationMethodId { get; set; }

    [Column("method")]
    [StringLength(50)]
    [Unicode(false)]
    public string Method { get; set; } = null!;

    [Column("description")]
    [StringLength(250)]
    [Unicode(false)]
    public string Description { get; set; } = null!;

    [Column("threshold_from", TypeName = "decimal(12, 2)")]
    public decimal ThresholdFrom { get; set; }

    [Column("threshold_to", TypeName = "decimal(12, 2)")]
    public decimal ThresholdTo { get; set; }

    [Column("status_id")]
    public byte StatusId { get; set; }

    [Column("created_date", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("updated_date", TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [ForeignKey("StatusId")]
    [InverseProperty("EvaluationMethods")]
    public virtual Status Status { get; set; } = null!;
}
