using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Models
{
    public partial class OdezdaContext : DbContext
    {
        public OdezdaContext()
        {
        }

        public OdezdaContext(DbContextOptions<OdezdaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Booking> Bookings { get; set; } = null!;
        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<DescriptionProduct> DescriptionProducts { get; set; } = null!;
        public virtual DbSet<Filterr> Filterrs { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Userss> Usersses { get; set; } = null!;

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Booking>(entity =>
            {
                entity.ToTable("Booking");

                entity.Property(e => e.BookingId).HasColumnName("booking_id");

                entity.Property(e => e.AddressB)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("address_b");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.Delivery)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("delivery");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.StatusB)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("status_b");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.Bookings)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Booking__cart_id__36B12243");
            });

            modelBuilder.Entity<Cart>(entity =>
            {
                entity.ToTable("Cart");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Carts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__customer_i__300424B4");
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CartId })
                    .HasName("PK__CartItem__25ED2F57EC1899BB");

                entity.ToTable("CartItem");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Cart)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.CartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__cart_i__33D4B598");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItem__produc__32E0915F");
            });

            modelBuilder.Entity<DescriptionProduct>(entity =>
            {
                entity.HasKey(e => new { e.ProductId, e.CustomerId })
                    .HasName("PK__Descript__0BD4214DF73CF4BB");

                entity.ToTable("DescriptionProduct");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CustomerId).HasColumnName("customer_id");

                entity.Property(e => e.Rating).HasColumnName("rating");

                entity.Property(e => e.TextD)
                    .HasMaxLength(436)
                    .IsUnicode(false)
                    .HasColumnName("text_d");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.DescriptionProducts)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Descripti__custo__2D27B809");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.DescriptionProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Descripti__produ__2C3393D0");
            });

            modelBuilder.Entity<Filterr>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Filterr__D54EE9B42764DD68");

                entity.ToTable("Filterr");

                entity.Property(e => e.CategoryId)
                    .ValueGeneratedNever()
                    .HasColumnName("category_id");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("category_name");

                entity.Property(e => e.Color)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("color");

                entity.Property(e => e.Material)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("material");

                entity.Property(e => e.NameP)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_p");

                entity.Property(e => e.Popular).HasColumnName("popular");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.Sale).HasColumnName("sale");

                entity.Property(e => e.Size)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("size");

                entity.Property(e => e.SubcategoryName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("subcategory_name");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.DescriptionP)
                    .HasMaxLength(127)
                    .IsUnicode(false)
                    .HasColumnName("description_p");

                entity.Property(e => e.NameP)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name_p");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductAvailability).HasColumnName("product_availability");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Product__categor__29572725");
            });

            modelBuilder.Entity<Userss>(entity =>
            {
                entity.ToTable("Userss");

                entity.HasIndex(e => e.UserEmail, "UQ__Userss__B0FBA212394915FB")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("first_name");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(127)
                    .IsUnicode(false)
                    .HasColumnName("user_email");

                entity.Property(e => e.UserPassord)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("user_passord");

                entity.Property(e => e.UserRole)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("user_role");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
