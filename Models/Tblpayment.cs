using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Lotus_surrogacy_agency_Admin_panel.Models;

[Table("tblpayment")]
[Index("AttorneyId", Name = "fk_attorney_id")]
[Index("DoctorId", Name = "fk_doctor_id")]
[Index("DonorId", Name = "fk_donor_id")]
[Index("FinanceId", Name = "fk_finance_id")]
[Index("ParentsId", Name = "fk_parent_id")]
[Index("PharmacistId", Name = "fk_pharmacist_id")]
public partial class Tblpayment
{
    [Key]
    [Column("payment_id", TypeName = "int(11)")]
    public int PaymentId { get; set; }

    [Column("amount")]
    public float Amount { get; set; }

    [Column("date_paid", TypeName = "datetime")]
    public DateTime DatePaid { get; set; }

    [Column("payment_method")]
    [StringLength(50)]
    public string PaymentMethod { get; set; } = null!;

    [Column("transaction_code")]
    [StringLength(50)]
    public string TransactionCode { get; set; } = null!;

    [Column("status")]
    public bool Status { get; set; }

    [Column("parents_id", TypeName = "int(11)")]
    public int? ParentsId { get; set; }

    [Column("finance_id", TypeName = "int(11)")]
    public int? FinanceId { get; set; }

    [Column("doctor_id", TypeName = "int(11)")]
    public int? DoctorId { get; set; }

    [Column("attorney_id", TypeName = "int(11)")]
    public int? AttorneyId { get; set; }

    [Column("pharmacist_id", TypeName = "int(11)")]
    public int? PharmacistId { get; set; }

    [Column("donor_id", TypeName = "int(11)")]
    public int? DonorId { get; set; }

    [Column("payment_type")]
    [StringLength(50)]
    public string? PaymentType { get; set; }

    [ForeignKey("AttorneyId")]
    [InverseProperty("Tblpayments")]
    public virtual Tblattorney? Attorney { get; set; }

    [ForeignKey("DoctorId")]
    [InverseProperty("Tblpayments")]
    public virtual Tbldoctor? Doctor { get; set; }

    [ForeignKey("DonorId")]
    [InverseProperty("Tblpayments")]
    public virtual TblspermDonor? Donor { get; set; }

    [ForeignKey("FinanceId")]
    [InverseProperty("Tblpayments")]
    public virtual TblfinanceManager? Finance { get; set; }

    [ForeignKey("ParentsId")]
    [InverseProperty("Tblpayments")]
    public virtual TblintendedParent? Parents { get; set; }

    [ForeignKey("PharmacistId")]
    [InverseProperty("Tblpayments")]
    public virtual Tblpharmacist? Pharmacist { get; set; }
}
