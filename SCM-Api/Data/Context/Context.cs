using System;
using System.Collections.Generic;
using Data.Entities;
using Data.StoreProcedureModel;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public partial class Context : DbContext
{
    public Context()
    {
    }

    public Context(DbContextOptions<Context> options)
        : base(options)
    {
    }

    public virtual DbSet<SP_ItemListModel> SP_ItemListModels { get; set; }

    public virtual DbSet<SP_EvaluationMethodListModel> SP_EvaluationListModels { get; set; }

    public virtual DbSet<Bid> Bids { get; set; }

    public virtual DbSet<BidSbdDocument> BidSbdDocuments { get; set; }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<EvaluationMethod> EvaluationMethods { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemAvailability> ItemAvailabilities { get; set; }

    public virtual DbSet<ItemDepartment> ItemDepartments { get; set; }

    public virtual DbSet<ItemReasoncode> ItemReasoncodes { get; set; }

    public virtual DbSet<ItemUom> ItemUoms { get; set; }

    public virtual DbSet<PurchaseCategory> PurchaseCategories { get; set; }

    public virtual DbSet<ReasonCode> ReasonCodes { get; set; }

    public virtual DbSet<SbdDocument> SbdDocuments { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SP_ItemListModel>().HasNoKey();

        modelBuilder.Entity<SP_EvaluationMethodListModel>().HasNoKey();

        modelBuilder.Entity<Bid>(entity =>
        {
            entity.HasKey(e => e.BidId).HasName("PK_bid_bid_id");
        });

        modelBuilder.Entity<BidSbdDocument>(entity =>
        {
            entity.HasKey(e => e.BidSbdDocumentId).HasName("PK_bid_sbd_documents_bid_sbd_document_id");

            entity.HasOne(d => d.Bid).WithMany(p => p.BidSbdDocuments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_bid_bid_id");

            entity.HasOne(d => d.SbdDocument).WithMany(p => p.BidSbdDocuments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_sbd_documents_sbd_document_id");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__company__3E2672350BA01A21");

            entity.Property(e => e.CompanyId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__departme__C22324220DC24095");
        });

        modelBuilder.Entity<EvaluationMethod>(entity =>
        {
            entity.HasKey(e => e.EvaluationMethodId).HasName("PK_evaluation_methods_evaluation_method_id");

            entity.HasOne(d => d.Status).WithMany(p => p.EvaluationMethods)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_statuses_status_id");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__items__52020FDDC08091B4");

            entity.Property(e => e.CreatedTime).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ItemAvailability>(entity =>
        {
            entity.HasKey(e => e.ItemAvailabilityId).HasName("PK__item_ava__581198465301F565");

            entity.Property(e => e.ItemAvailabilityId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ItemDepartment>(entity =>
        {
            entity.HasKey(e => e.ItemDepartmentId).HasName("PK__item_dep__77B1409B76038DF4");

            entity.HasOne(d => d.Department).WithMany(p => p.ItemDepartments).HasConstraintName("FK__item_depa__depar__3D2915A8");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemDepartments).HasConstraintName("FK__item_depa__item___3C34F16F");
        });

        modelBuilder.Entity<ItemReasoncode>(entity =>
        {
            entity.HasKey(e => e.ItemReasoncodeId).HasName("PK__item_rea__53BA16F5E0C222BC");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemReasoncodes).HasConstraintName("FK__item_reas__item___3864608B");

            entity.HasOne(d => d.ReasonCode).WithMany(p => p.ItemReasoncodes).HasConstraintName("FK__item_reas__reaso__395884C4");
        });

        modelBuilder.Entity<ItemUom>(entity =>
        {
            entity.HasKey(e => e.ItemUomId).HasName("PK__item_uom__6BF093599059CD53");

            entity.Property(e => e.ItemUomId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<PurchaseCategory>(entity =>
        {
            entity.HasKey(e => e.PurchaseCategoryId).HasName("PK__purchase__44603B893697C566");

            entity.Property(e => e.PurchaseCategoryId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ReasonCode>(entity =>
        {
            entity.HasKey(e => e.ReasonCodeId).HasName("PK__reason_c__0D51E8E1F6251918");

            entity.Property(e => e.ReasonCodeId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<SbdDocument>(entity =>
        {
            entity.HasKey(e => e.SbdDocumentId).HasName("PK_sbd_documents_sbd_document_id");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__statuses__3683B531BE19E124");

            entity.Property(e => e.StatusId).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
