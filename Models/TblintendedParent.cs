using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Models;

[Table("tblintended_parents")]
public partial class TblintendedParent
{
    [Key]
    [Column("parents_id", TypeName = "int(11)")]
    public int ParentsId { get; set; }

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("fullname")]
    [StringLength(100)]
    public string Fullname { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("phone")]
    [StringLength(50)]
    public string Phone { get; set; } = null!;

    [Column("password")]
    [StringLength(50)]
    public string Password { get; set; } = null!;

    [Column("gender")]
    [StringLength(20)]
    public string Gender { get; set; } = null!;

    [Column("status")]
    public bool Status { get; set; }

    [StringLength(100)]
    public string Address { get; set; } = null!;

    [InverseProperty("Parents")]
    public virtual ICollection<Tblfeedback> Tblfeedbacks { get; set; } = new List<Tblfeedback>();

    [InverseProperty("Parents")]
    public virtual ICollection<TblmedicalInfo> TblmedicalInfos { get; set; } = new List<TblmedicalInfo>();

    [InverseProperty("Parents")]
    public virtual ICollection<Tblpayment> Tblpayments { get; set; } = new List<Tblpayment>();

    [InverseProperty("Parents")]
    public virtual ICollection<Tblprofile> Tblprofiles { get; set; } = new List<Tblprofile>();
}
