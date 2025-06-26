using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Models;

[Table("tbluser")]
public partial class Tbluser
{
    [Key]
    [Column("user_id", TypeName = "int(11)")]
    public int UserId { get; set; }

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("fullname")]
    [StringLength(100)]
    public string Fullname { get; set; } = null!;

    [Column("password")]
    [StringLength(50)]
    public string Password { get; set; } = null!;

    [Column("phone")]
    [StringLength(50)]
    public string Phone { get; set; } = null!;

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("gender")]
    [StringLength(20)]
    public string Gender { get; set; } = null!;

    [Column("role")]
    [StringLength(50)]
    public string Role { get; set; } = null!;

    [Column("isactive")]
    public bool Isactive { get; set; }

    [Column("address")]
    [StringLength(100)]
    public string Address { get; set; } = null!;

    [Column("status")]
    [StringLength(50)]
    public string Status { get; set; } = null!;
}
