using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Models;

[Table("tblrolepermission")]
public partial class Tblrolepermission
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("usrrole")]
    [StringLength(50)]
    public string Usrrole { get; set; } = null!;

    [Column("menucode")]
    [StringLength(50)]
    public string Menucode { get; set; } = null!;

    [Column("haveview")]
    public bool Haveview { get; set; }

    [Column("haveadd")]
    public bool Haveadd { get; set; }

    [Column("haveedit")]
    public bool Haveedit { get; set; }

    [Column("havedelete")]
    public bool Havedelete { get; set; }
}
