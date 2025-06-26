using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Models;

[Table("tblmedical_info")]
[Index("DonorId", Name = "fk_donors_id")]
[Index("MotherId", Name = "fk_mother_id")]
[Index("ParentsId", Name = "fk_parents_id")]
[Index("LabTechnicianId", Name = "fk_technician_id")]
public partial class TblmedicalInfo
{
    [Key]
    [Column("info_id", TypeName = "int(11)")]
    public int InfoId { get; set; }

    [Column("Medical_records")]
    [StringLength(100)]
    public string MedicalRecords { get; set; } = null!;

    [Column("fertility_health")]
    [StringLength(250)]
    public string FertilityHealth { get; set; } = null!;

    [Column("medications")]
    [StringLength(250)]
    public string Medications { get; set; } = null!;

    [Column("mental_health_history")]
    [StringLength(250)]
    public string MentalHealthHistory { get; set; } = null!;

    [Column("lifestyle_habits")]
    [StringLength(250)]
    public string LifestyleHabits { get; set; } = null!;

    [Column("vaccination_status")]
    [StringLength(250)]
    public string VaccinationStatus { get; set; } = null!;

    [Column("mother_id", TypeName = "int(11)")]
    public int? MotherId { get; set; }

    [Column("parents_id", TypeName = "int(11)")]
    public int? ParentsId { get; set; }

    [Column("donor_id", TypeName = "int(11)")]
    public int? DonorId { get; set; }

    [Column("lab_technician_id", TypeName = "int(11)")]
    public int? LabTechnicianId { get; set; }

    [ForeignKey("DonorId")]
    [InverseProperty("TblmedicalInfos")]
    public virtual TblspermDonor? Donor { get; set; }

    [ForeignKey("LabTechnicianId")]
    [InverseProperty("TblmedicalInfos")]
    public virtual TbllabTechnician? LabTechnician { get; set; }

    [ForeignKey("MotherId")]
    [InverseProperty("TblmedicalInfos")]
    public virtual TblsurrogateMother? Mother { get; set; }

    [ForeignKey("ParentsId")]
    [InverseProperty("TblmedicalInfos")]
    public virtual TblintendedParent? Parents { get; set; }
}
