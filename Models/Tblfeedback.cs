using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Models;

[Table("tblfeedback")]
[Index("MotherId", Name = "mother_id")]
[Index("ParentsId", Name = "parents_id")]
public partial class Tblfeedback
{
    [Key]
    [Column("feedback_id", TypeName = "int(11)")]
    public int FeedbackId { get; set; }

    [Column("parents_id", TypeName = "int(11)")]
    public int ParentsId { get; set; }

    [Column("mother_id", TypeName = "int(11)")]
    public int MotherId { get; set; }

    [Column("message")]
    [StringLength(500)]
    public string Message { get; set; } = null!;

    [Column("reply")]
    [StringLength(500)]
    public string Reply { get; set; } = null!;

    [Column("date", TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Column("status")]
    public bool Status { get; set; }

    [ForeignKey("MotherId")]
    [InverseProperty("Tblfeedbacks")]
    public virtual TblsurrogateMother Mother { get; set; } = null!;

    [ForeignKey("ParentsId")]
    [InverseProperty("Tblfeedbacks")]
    public virtual TblintendedParent Parents { get; set; } = null!;
}
