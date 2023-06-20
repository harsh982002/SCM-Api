using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

[Table("sbd_documents")]
public partial class SbdDocument
{
    [Key]
    [Column("sbd_document_id")]
    public int SbdDocumentId { get; set; }

    [Column("name")]
    [StringLength(250)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("json_format_string")]
    [Unicode(false)]
    public string JsonFormatString { get; set; } = null!;

    [InverseProperty("SbdDocument")]
    public virtual ICollection<BidSbdDocument> BidSbdDocuments { get; set; } = new List<BidSbdDocument>();
}
