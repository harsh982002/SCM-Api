using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("item_availabilities")]
public partial class ItemAvailability
{
    [Key]
    [Column("item_availability_id")]
    public byte ItemAvailabilityId { get; set; }

    [Column("name")]
    [StringLength(16)]
    [Unicode(false)]
    public string Name { get; set; } = null!;
}
