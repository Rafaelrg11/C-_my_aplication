using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using MyAplication.models;

namespace MyAplication;

public partial class NewDbContext : DbContext
{
    public NewDbContext()
    {
    }

    public NewDbContext(DbContextOptions<NewDbContext> options)
        : base(options)
    {
    }
    public virtual DbSet<Bill> Bills { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Product> Products { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("persona_pkey");

            entity.ToTable("persona");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Dni).HasColumnName("DNI");
            entity.Property(e => e.Gmail)
                .HasMaxLength(50)
                .HasColumnName("gmail");
            entity.Property(e => e.Lastname)
                .HasMaxLength(20)
                .HasColumnName("lastname");
            entity.Property(e => e.Name)
                .HasMaxLength(15)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Bill>(entity =>
        {
            entity.HasKey(e => e.IdSale).HasName("ventas_pkey");

            entity.ToTable("bill");

            entity.Property(e => e.IdSale)
                .ValueGeneratedNever()
                .HasColumnName("id_sale");
            entity.Property(e => e.IdProductBill).HasColumnName("id_product_bill");
            entity.Property(e => e.QuantityProduct).HasColumnName("quantity_product");
            entity.Property(e => e.TotalSale).HasColumnName("total_sale");
            entity.Property(e => e.TpriceProduct).HasColumnName("tprice_product");

            entity.HasOne(d => d.IdProductBillNavigation).WithMany(p => p.Bills)
                .HasForeignKey(d => d.IdProductBill)
                .HasConstraintName("fk_id_product_bill");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("product_pkey");

            entity.ToTable("product");

            entity.Property(e => e.IdProduct)
                .HasDefaultValueSql("nextval('product_id_seq'::regclass)")
                .HasColumnName("id_product");
            entity.Property(e => e.NameProduct)
                .HasColumnType("character varying")
                .HasColumnName("name_product");
            entity.Property(e => e.PriseProduct).HasColumnName("prise_product");
            entity.Property(e => e.StockProduct).HasColumnName("stock_product");
        });

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
