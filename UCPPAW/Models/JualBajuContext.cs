using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UCPPAW.Models
{
    public partial class JualBajuContext : DbContext
    {
        public JualBajuContext()
        {
        }

        public JualBajuContext(DbContextOptions<JualBajuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Barang> Barangs { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Pembayaran> Pembayarans { get; set; }
        public virtual DbSet<Penjual> Penjuals { get; set; }
        public virtual DbSet<Transaksi> Transaksis { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Barang>(entity =>
            {
                entity.HasKey(e => e.IdBarang);

                entity.ToTable("Barang");

                entity.Property(e => e.IdBarang)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Barang");

                entity.Property(e => e.IdPenjual).HasColumnName("ID_Penjual");

                entity.Property(e => e.NamaBarang)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Barang");

                entity.Property(e => e.StokBarang).HasColumnName("Stok_Barang");

                entity.HasOne(d => d.IdPenjualNavigation)
                    .WithMany(p => p.Barangs)
                    .HasForeignKey(d => d.IdPenjual)
                    .HasConstraintName("FK_Barang_Penjual");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer);

                entity.ToTable("Customer");

                entity.Property(e => e.IdCustomer)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Customer");

                entity.Property(e => e.NamaCustomer)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Nama_Customer");

                entity.Property(e => e.NoHp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("No_Hp");
            });

            modelBuilder.Entity<Pembayaran>(entity =>
            {
                entity.HasKey(e => e.IdPembayaran);

                entity.ToTable("Pembayaran");

                entity.Property(e => e.IdPembayaran)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Pembayaran");

                entity.Property(e => e.IdTransaksi).HasColumnName("ID_Transaksi");

                entity.Property(e => e.TanggalBayar)
                    .HasColumnType("datetime")
                    .HasColumnName("Tanggal_Bayar");

                entity.Property(e => e.TotalBayar).HasColumnName("Total_Bayar");

                entity.HasOne(d => d.TotalBayarNavigation)
                    .WithMany(p => p.Pembayarans)
                    .HasForeignKey(d => d.TotalBayar)
                    .HasConstraintName("FK_Pembayaran_Transaksi");
            });

            modelBuilder.Entity<Penjual>(entity =>
            {
                entity.HasKey(e => e.IdPenjual);

                entity.ToTable("Penjual");

                entity.Property(e => e.IdPenjual)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Penjual");

                entity.Property(e => e.Alamat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NamaPenjual)
                    .HasMaxLength(50)
                    .HasColumnName("Nama_Penjual");

                entity.Property(e => e.NoHp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("No_Hp");
            });

            modelBuilder.Entity<Transaksi>(entity =>
            {
                entity.HasKey(e => e.IdTransaksi);

                entity.ToTable("Transaksi");

                entity.Property(e => e.IdTransaksi)
                    .ValueGeneratedNever()
                    .HasColumnName("ID_Transaksi");

                entity.Property(e => e.IdBarang).HasColumnName("ID_Barang");

                entity.Property(e => e.IdCustomer).HasColumnName("ID_Customer");

                entity.Property(e => e.Tanggal).HasColumnType("datetime");

                entity.HasOne(d => d.IdBarangNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdBarang)
                    .HasConstraintName("FK_Transaksi_Barang");

                entity.HasOne(d => d.IdCustomerNavigation)
                    .WithMany(p => p.Transaksis)
                    .HasForeignKey(d => d.IdCustomer)
                    .HasConstraintName("FK_Transaksi_Customer");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
