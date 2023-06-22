using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

[Table("bid")]
public partial class Bid
{
    [Key]
    [Column("bid_id")]
    public int BidId { get; set; }

    [Column("name")]
    [StringLength(50)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [InverseProperty("Bid")]
    public virtual ICollection<BidSbdDocument> BidSbdDocuments { get; set; } = new List<BidSbdDocument>();
}
