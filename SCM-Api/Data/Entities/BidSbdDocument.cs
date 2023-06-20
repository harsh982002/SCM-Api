using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities;

[Table("bid_sbd_documents")]
public partial class BidSbdDocument
{
    [Key]
    [Column("bid_sbd_document_id")]
    public int BidSbdDocumentId { get; set; }

    [Column("sbd_document_id")]
    public int SbdDocumentId { get; set; }

    [Column("sbd_document_value")]
    [Unicode(false)]
    public string SbdDocumentValue { get; set; } = null!;

    [Column("created_date", TypeName = "datetime")]
    public DateTime CreatedDate { get; set; }

    [Column("updated_date", TypeName = "datetime")]
    public DateTime? UpdatedDate { get; set; }

    [ForeignKey("SbdDocumentId")]
    [InverseProperty("BidSbdDocuments")]
    public virtual SbdDocument SbdDocument { get; set; } = null!;
}
