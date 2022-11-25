using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace stcokManagement.Models;

public partial class AirlinesStockContext : DbContext
{
    public AirlinesStockContext()
    {
    }

    public AirlinesStockContext(DbContextOptions<AirlinesStockContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblCase> TblCases { get; set; }

    public virtual DbSet<TblProduct> TblProducts { get; set; }

    public virtual DbSet<TblSelf> TblSelves { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-3S3KF7F;Database=AirlinesStock;Integrated Security=True;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblCase>(entity =>
        {
            entity.ToTable("tblCase");

            entity.Property(e => e.CaseNo).HasColumnName("caseNo");
            entity.Property(e => e.SelfId).HasColumnName("selfId");

            entity.HasOne(d => d.Self).WithMany(p => p.TblCases)
                .HasForeignKey(d => d.SelfId)
                .HasConstraintName("FK_tblCase_tblSelf");
        });

        modelBuilder.Entity<TblProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Products");

            entity.ToTable("tblProduct");

            entity.Property(e => e.ArrivealDate)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CaseId).HasColumnName("caseId");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PickedQuantity).HasColumnName("pickedQuantity");
            entity.Property(e => e.PickupDate)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("pickupDate");
            entity.Property(e => e.SafetyStock).HasColumnName("safetyStock");

            entity.HasOne(d => d.Case).WithMany(p => p.TblProducts)
                .HasForeignKey(d => d.CaseId)
                .HasConstraintName("FK_tblProduct_tblCase");
        });

        modelBuilder.Entity<TblSelf>(entity =>
        {
            entity.ToTable("tblSelf");

            entity.Property(e => e.AirlineName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SelfNo).HasColumnName("selfNo");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
