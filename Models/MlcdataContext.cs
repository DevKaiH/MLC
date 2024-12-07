using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MLC.Models;

public partial class MlcdataContext : DbContext
{
    public MlcdataContext()
    {
    }

    public MlcdataContext(DbContextOptions<MlcdataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAccount> TblAccounts { get; set; }

    public virtual DbSet<TblEftlog> TblEftlogs { get; set; }

    public virtual DbSet<TblPayment> TblPayments { get; set; }

    public virtual DbSet<TblRecipient> TblRecipients { get; set; }

    public virtual DbSet<VRecipient> VRecipients { get; set; }

    public virtual DbSet<BMO> BMOs { get; set; }

    public virtual DbSet<PCFile> PCFiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=MLCData;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAccount>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Accounts__3214EC073E47BF3F");

            entity.ToTable("tblAccounts");

            entity.Property(e => e.Acct)
                .HasMaxLength(12)
                .IsFixedLength();
            entity.Property(e => e.Description)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblEftlog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_EFTLog");

            entity.ToTable("tblEFTLog");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.DateUploaded).HasColumnType("datetime");
            entity.Property(e => e.Fcn).HasColumnName("FCN");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<TblPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3214EC078F3CC79D");

            entity.ToTable("tblPayments");

            entity.Property(e => e.Account)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.ApproveDate).HasColumnType("datetime");
            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Filename)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Memo).IsUnicode(false);
            entity.Property(e => e.SubmittedToBmo)
                .HasColumnType("datetime")
                .HasColumnName("SubmittedToBMO");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<TblRecipient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User__3214EC0787B4C02B");

            entity.ToTable("tblRecipients");

            entity.Property(e => e.Account)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Bank)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Cell)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Cpa)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CPA");
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Transit)
                .HasMaxLength(5)
                .IsUnicode(false);
        });

        modelBuilder.Entity<VRecipient>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vRecipients");

            entity.Property(e => e.Account)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Bank)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.Cell)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Cpa)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("CPA");
            entity.Property(e => e.Email)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Recipients)
                .HasMaxLength(101)
                .IsUnicode(false);
            entity.Property(e => e.Transit)
                .HasMaxLength(5)
                .IsUnicode(false);
        });
        modelBuilder.Entity<PCFile>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<BMO>(entity =>
        {
            entity.HasKey(e => e.PMT_NR).HasName("PMT_NR");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
