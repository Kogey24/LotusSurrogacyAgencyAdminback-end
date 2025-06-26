using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Models;

[Table("refreshtoken")]
public partial class Refreshtoken
{
    [Key]
    [Column("userid")]
    [StringLength(50)]
    public string Userid { get; set; } = null!;

    [Column("tokenId")]
    [StringLength(50)]
    public string TokenId { get; set; } = null!;

    [Column("refreshToken")]
    [StringLength(50)]
    public string RefreshToken1 { get; set; } = null!;
}
