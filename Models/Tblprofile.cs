using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Models;

[Table("tblprofile")]
[Index("MotherId", Name = "fk_mother")]
[Index("ParentsId", Name = "fk_parent")]
public partial class Tblprofile
{
    [Key]
    [Column("profile_id", TypeName = "int(11)")]
    public int ProfileId { get; set; }

    [Column("health_status")]
    [StringLength(250)]
    public string HealthStatus { get; set; } = null!;

    [Column("fertility_story")]
    [StringLength(250)]
    public string FertilityStory { get; set; } = null!;

    [Column("surrogacy_type")]
    [StringLength(250)]
    public string SurrogacyType { get; set; } = null!;

    [Column("communication_method")]
    [StringLength(250)]
    public string CommunicationMethod { get; set; } = null!;

    [Column("surrogacy_motivation")]
    [StringLength(250)]
    public string SurrogacyMotivation { get; set; } = null!;

    [Column("compensation_expectation")]
    [StringLength(250)]
    public string CompensationExpectation { get; set; } = null!;

    [Column("parents_id", TypeName = "int(11)")]
    public int? ParentsId { get; set; }

    [Column("mother_id", TypeName = "int(11)")]
    public int? MotherId { get; set; }

    [ForeignKey("MotherId")]
    [InverseProperty("Tblprofiles")]
    public virtual TblsurrogateMother? Mother { get; set; }

    [ForeignKey("ParentsId")]
    [InverseProperty("Tblprofiles")]
    public virtual TblintendedParent? Parents { get; set; }
}
