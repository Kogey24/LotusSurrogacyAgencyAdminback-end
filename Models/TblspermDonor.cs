using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Models;

[Table("tblsperm_donor")]
public partial class TblspermDonor
{
    [Key]
    [Column("donor_id", TypeName = "int(11)")]
    public int DonorId { get; set; }

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("fullname")]
    [StringLength(100)]
    public string Fullname { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column(TypeName = "int(11)")]
    public int Age { get; set; }

    [StringLength(50)]
    public string Complexion { get; set; } = null!;

    [Column("phone")]
    [StringLength(50)]
    public string Phone { get; set; } = null!;

    [Column("password")]
    [StringLength(50)]
    public string Password { get; set; } = null!;

    [Column("status")]
    public bool Status { get; set; }

    [StringLength(100)]
    public string Address { get; set; } = null!;

    [Column("HIV status")]
    [StringLength(100)]
    public string HivStatus { get; set; } = null!;

    [Column(TypeName = "int(10)")]
    public int Height { get; set; }

    [Column(TypeName = "int(10)")]
    public int Weight { get; set; }

    [InverseProperty("Donor")]
    public virtual ICollection<TblmedicalInfo> TblmedicalInfos { get; set; } = new List<TblmedicalInfo>();

    [InverseProperty("Donor")]
    public virtual ICollection<Tblpayment> Tblpayments { get; set; } = new List<Tblpayment>();
}
