using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Models;

[Table("tblsurrogate_mother")]
public partial class TblsurrogateMother
{
    [Key]
    [Column("mother_id", TypeName = "int(11)")]
    public int MotherId { get; set; }

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("fullname")]
    [StringLength(100)]
    public string Fullname { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("phone", TypeName = "int(50)")]
    public int Phone { get; set; }

    [Column("password")]
    [StringLength(50)]
    public string Password { get; set; } = null!;

    [Column("status")]
    public bool Status { get; set; }

    [Column(TypeName = "int(10)")]
    public int Age { get; set; }

    [Column("marital status")]
    [StringLength(50)]
    public string MaritalStatus { get; set; } = null!;

    [StringLength(100)]
    public string Occupation { get; set; } = null!;

    [StringLength(100)]
    public string Address { get; set; } = null!;

    [InverseProperty("Mother")]
    public virtual ICollection<Tblfeedback> Tblfeedbacks { get; set; } = new List<Tblfeedback>();

    [InverseProperty("Mother")]
    public virtual ICollection<TblmedicalInfo> TblmedicalInfos { get; set; } = new List<TblmedicalInfo>();

    [InverseProperty("Mother")]
    public virtual ICollection<Tblprofile> Tblprofiles { get; set; } = new List<Tblprofile>();
}
