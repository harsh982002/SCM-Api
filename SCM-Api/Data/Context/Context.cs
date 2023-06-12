using System;
using System.Collections.Generic;
using Data.Entities;
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

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<ItemAvailability> ItemAvailabilities { get; set; }

    public virtual DbSet<ItemDepartmentMapping> ItemDepartmentMappings { get; set; }

    public virtual DbSet<ItemReasoncodesMapping> ItemReasoncodesMappings { get; set; }

    public virtual DbSet<ItemUom> ItemUoms { get; set; }

    public virtual DbSet<PurchaseCategory> PurchaseCategories { get; set; }

    public virtual DbSet<ReasonCode> ReasonCodes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {

        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__company__3E2672350BA01A21");

            entity.Property(e => e.CompanyId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__departme__C22324220DC24095");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__items__52020FDDC08091B4");

            entity.Property(e => e.CreatedTime).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.Company).WithMany(p => p.Items).HasConstraintName("FK__items__company_i__571DF1D5");

            entity.HasOne(d => d.ItemAvailability).WithMany(p => p.Items).HasConstraintName("FK__items__item_avai__59FA5E80");

            entity.HasOne(d => d.ItemUom).WithMany(p => p.Items).HasConstraintName("FK__items__item_uom___5812160E");

            entity.HasOne(d => d.PurchaseCategory).WithMany(p => p.Items).HasConstraintName("FK__items__purchase___29221CFB");

            entity.HasOne(d => d.Status).WithMany(p => p.Items).HasConstraintName("FK__items__status_id__5BE2A6F2");
        });

        modelBuilder.Entity<ItemAvailability>(entity =>
        {
            entity.HasKey(e => e.ItemAvailabilityId).HasName("PK__item_ava__581198465301F565");

            entity.Property(e => e.ItemAvailabilityId).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<ItemDepartmentMapping>(entity =>
        {
            entity.HasKey(e => new { e.ItemId, e.DepartmentId }).HasName("PK__item_dep__6E203D9F4CAAE262");

            entity.HasOne(d => d.Department).WithMany(p => p.ItemDepartmentMappings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__item_depa__depar__76969D2E");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemDepartmentMappings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__item_depa__item___75A278F5");
        });

        modelBuilder.Entity<ItemReasoncodesMapping>(entity =>
        {
            entity.HasKey(e => new { e.ItemId, e.ReasonCodeId }).HasName("PK__item_rea__52D7115302DAD72C");

            entity.HasOne(d => d.Item).WithMany(p => p.ItemReasoncodesMappings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__item_reas__item___797309D9");

            entity.HasOne(d => d.ReasonCode).WithMany(p => p.ItemReasoncodesMappings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__item_reas__reaso__7A672E12");
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

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__statuses__3683B531BE19E124");

            entity.Property(e => e.StatusId).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
