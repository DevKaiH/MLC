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

    public virtual DbSet<TblPclog> TblPclogs { get; set; }

    public virtual DbSet<TblRecipient> TblRecipients { get; set; }

    public virtual DbSet<TblSetting> TblSettings { get; set; }

    public virtual DbSet<TblTransaction> TblTransactions { get; set; }

    public virtual DbSet<TblTransactionDetail> TblTransactionDetails { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<TransBu> TransBus { get; set; }

    public virtual DbSet<VRecipient> VRecipients { get; set; }

    public virtual DbSet<BMO> BMOs { get; set; }

    public virtual DbSet<PCFile> PCFiles { get; set; }
    public virtual DbSet<TblMember> TblMembers { get; set; }

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
            entity.Property(e => e.Type)
                .HasMaxLength(1)
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
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblPayment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Payment__3214EC078F3CC79D");

            entity.ToTable("tblPayments");

            entity.Property(e => e.Account)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.AddDate).HasColumnType("datetime");
            entity.Property(e => e.AddUser)
                .HasMaxLength(50)
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
            entity.Property(e => e.RecipientId).HasColumnName("RecipientID");
            entity.Property(e => e.SubmittedToBmo)
                .HasColumnType("datetime")
                .HasColumnName("SubmittedToBMO");
        });

        modelBuilder.Entity<TblPclog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC071D8C7B68");

            entity.ToTable("tblPCLog");

            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
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

        modelBuilder.Entity<TblMember>(entity =>
        {
            entity.ToTable("tblMembers");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("ID");
            entity.Property(e => e.Addres1).HasMaxLength(50);
            entity.Property(e => e.Address2).HasMaxLength(50);
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .HasColumnName("country");
            entity.Property(e => e.EMail)
                .HasMaxLength(150)
                .HasColumnName("e_mail");
            entity.Property(e => e.EnvNo).HasColumnName("env_no");
            entity.Property(e => e.Firstname)
                .HasMaxLength(50)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(50)
                .HasColumnName("lastname");
            entity.Property(e => e.Phone1)
                .HasMaxLength(50)
                .HasColumnName("phone1");
            entity.Property(e => e.Postalcode).HasMaxLength(50);
            entity.Property(e => e.Province).HasMaxLength(50);
            entity.Property(e => e.Updated).HasColumnName("updated");
        });
        modelBuilder.Entity<TblSetting>(entity =>
        {
            entity.ToTable("tblSettings");

            entity.Property(e => e.Property)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblTransaction>(entity =>
        {
            entity.ToTable("tblTransactions");

            entity.Property(e => e.AddTime).HasColumnType("datetime");
            entity.Property(e => e.AddUser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Memo).IsUnicode(false);
            entity.Property(e => e.Transactiondate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TblTransactionDetail>(entity =>
        {
            entity.ToTable("tblTransactionDetail");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.ApproveDate).HasColumnType("datetime");
            entity.Property(e => e.Approver)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.Filename).IsUnicode(false);
            entity.Property(e => e.Gst)
                .HasColumnType("money")
                .HasColumnName("GST");
            entity.Property(e => e.Pst)
                .HasColumnType("money")
                .HasColumnName("PST");
            entity.Property(e => e.Tax).HasColumnType("money");
            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC078B6A6D9D");

            entity.ToTable("tblUsers");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.AddUser)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
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
