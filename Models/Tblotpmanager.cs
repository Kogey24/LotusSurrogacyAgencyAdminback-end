using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Models;

[Table("tblotpmanager")]
public partial class Tblotpmanager
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("otptext")]
    [StringLength(20)]
    public string Otptext { get; set; } = null!;

    [Column("otptype")]
    [StringLength(20)]
    public string Otptype { get; set; } = null!;

    [Column("expiration", TypeName = "datetime")]
    public DateTime Expiration { get; set; }

    [Column("create_date", TypeName = "datetime")]
    public DateTime CreateDate { get; set; }
}
