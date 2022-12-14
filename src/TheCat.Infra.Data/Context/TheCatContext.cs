
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using TheCat.Domain.Entities;

namespace TheCat.Infra.Data
{
    public partial class TheCatContext : DbContext
    {
        public TheCatContext()
        {
        }

        public TheCatContext(DbContextOptions<TheCatContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Breeds> Breeds { get; set; }
        public virtual DbSet<BreedsImages> BreedsImages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breeds>(entity =>
            {
                entity.Property(e => e.id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.description)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.origin)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.temperament)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BreedsImages>(entity =>
            {
                entity.Property(e => e.id)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.idbreeds)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.url)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.idbreedsNavigation)
                    .WithMany(p => p.BreedsImages)
                    .HasForeignKey(d => d.idbreeds)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BreedsImages_Breeds");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}