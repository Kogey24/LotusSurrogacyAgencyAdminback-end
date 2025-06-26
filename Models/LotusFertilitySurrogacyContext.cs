using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Lotus_surrogacy_agency_Admin_panel.Models;

public partial class LotusFertilitySurrogacyContext : DbContext
{
    public LotusFertilitySurrogacyContext()
    {
    }

    public LotusFertilitySurrogacyContext(DbContextOptions<LotusFertilitySurrogacyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Refreshtoken> Refreshtokens { get; set; }

    public virtual DbSet<Tbladmin> Tbladmins { get; set; }

    public virtual DbSet<Tblattorney> Tblattorneys { get; set; }

    public virtual DbSet<Tbldoctor> Tbldoctors { get; set; }

    public virtual DbSet<Tblfeedback> Tblfeedbacks { get; set; }

    public virtual DbSet<TblfinanceManager> TblfinanceManagers { get; set; }

    public virtual DbSet<TblintendedParent> TblintendedParents { get; set; }

    public virtual DbSet<TblinventoryManager> TblinventoryManagers { get; set; }

    public virtual DbSet<TbllabTechnician> TbllabTechnicians { get; set; }

    public virtual DbSet<TblmedicalInfo> TblmedicalInfos { get; set; }

    public virtual DbSet<Tblmenu> Tblmenus { get; set; }

    public virtual DbSet<Tblotpmanager> Tblotpmanagers { get; set; }

    public virtual DbSet<Tblpayment> Tblpayments { get; set; }

    public virtual DbSet<Tblpharmacist> Tblpharmacists { get; set; }

    public virtual DbSet<Tblprofile> Tblprofiles { get; set; }

    public virtual DbSet<Tblpwdmanager> Tblpwdmanagers { get; set; }

    public virtual DbSet<Tblrole> Tblroles { get; set; }

    public virtual DbSet<Tblrolepermission> Tblrolepermissions { get; set; }

    public virtual DbSet<TblspermDonor> TblspermDonors { get; set; }

    public virtual DbSet<Tblstock> Tblstocks { get; set; }

    public virtual DbSet<Tblsupplier> Tblsuppliers { get; set; }

    public virtual DbSet<TblsurrogateMother> TblsurrogateMothers { get; set; }

    public virtual DbSet<Tbltempuser> Tbltempusers { get; set; }

    public virtual DbSet<Tbltherapist> Tbltherapists { get; set; }

    public virtual DbSet<Tbluser> Tblusers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql("name=constring", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.1.4-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Refreshtoken>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tbladmin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PRIMARY");

            entity.Property(e => e.Phone).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Tblattorney>(entity =>
        {
            entity.HasKey(e => e.AttorneyId).HasName("PRIMARY");

            entity.Property(e => e.Phone).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Tbldoctor>(entity =>
        {
            entity.HasKey(e => e.DoctorId).HasName("PRIMARY");

            entity.Property(e => e.Phone).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Tblfeedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PRIMARY");

            entity.HasOne(d => d.Mother).WithMany(p => p.Tblfeedbacks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblfeedback_ibfk_2");

            entity.HasOne(d => d.Parents).WithMany(p => p.Tblfeedbacks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblfeedback_ibfk_1");
        });

        modelBuilder.Entity<TblfinanceManager>(entity =>
        {
            entity.HasKey(e => e.FinanceId).HasName("PRIMARY");

            entity.Property(e => e.Phone).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<TblintendedParent>(entity =>
        {
            entity.HasKey(e => e.ParentsId).HasName("PRIMARY");

            entity.Property(e => e.Phone).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<TblinventoryManager>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("PRIMARY");

            entity.Property(e => e.Phone).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<TbllabTechnician>(entity =>
        {
            entity.HasKey(e => e.LabTechnicianId).HasName("PRIMARY");

            entity.Property(e => e.Phone).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<TblmedicalInfo>(entity =>
        {
            entity.HasKey(e => e.InfoId).HasName("PRIMARY");

            entity.HasOne(d => d.Donor).WithMany(p => p.TblmedicalInfos).HasConstraintName("fk_donors_id");

            entity.HasOne(d => d.LabTechnician).WithMany(p => p.TblmedicalInfos).HasConstraintName("fk_technician_id");

            entity.HasOne(d => d.Mother).WithMany(p => p.TblmedicalInfos).HasConstraintName("fk_mother_id");

            entity.HasOne(d => d.Parents).WithMany(p => p.TblmedicalInfos).HasConstraintName("fk_parents_id");
        });

        modelBuilder.Entity<Tblmenu>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tblotpmanager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tblpayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PRIMARY");

            entity.HasOne(d => d.Attorney).WithMany(p => p.Tblpayments).HasConstraintName("fk_attorney_id");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Tblpayments).HasConstraintName("fk_doctor_id");

            entity.HasOne(d => d.Donor).WithMany(p => p.Tblpayments).HasConstraintName("fk_donor_id");

            entity.HasOne(d => d.Finance).WithMany(p => p.Tblpayments).HasConstraintName("fk_finance_id");

            entity.HasOne(d => d.Parents).WithMany(p => p.Tblpayments).HasConstraintName("fk_parent_id");

            entity.HasOne(d => d.Pharmacist).WithMany(p => p.Tblpayments).HasConstraintName("fk_pharmacist_id");
        });

        modelBuilder.Entity<Tblpharmacist>(entity =>
        {
            entity.HasKey(e => e.PharmacistId).HasName("PRIMARY");

            entity.Property(e => e.Phone).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Tblprofile>(entity =>
        {
            entity.HasKey(e => e.ProfileId).HasName("PRIMARY");

            entity.HasOne(d => d.Mother).WithMany(p => p.Tblprofiles).HasConstraintName("fk_mother");

            entity.HasOne(d => d.Parents).WithMany(p => p.Tblprofiles).HasConstraintName("fk_parent");
        });

        modelBuilder.Entity<Tblpwdmanager>(entity =>
        {
            entity.HasKey(e => e.Username).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tblrole>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tblrolepermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<TblspermDonor>(entity =>
        {
            entity.HasKey(e => e.DonorId).HasName("PRIMARY");

            entity.Property(e => e.Phone).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Tblstock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PRIMARY");

            entity.HasOne(d => d.Inventory).WithMany(p => p.Tblstocks).HasConstraintName("fk_inventory_id");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Tblstocks).HasConstraintName("fk_supplier_id");
        });

        modelBuilder.Entity<Tblsupplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PRIMARY");

            entity.Property(e => e.Phone).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<TblsurrogateMother>(entity =>
        {
            entity.HasKey(e => e.MotherId).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tbltempuser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tbltherapist>(entity =>
        {
            entity.HasKey(e => e.TherapistId).HasName("PRIMARY");

            entity.Property(e => e.Phone).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Tbluser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
