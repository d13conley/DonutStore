using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DonutStore.Data.Models
{
    public partial class DonutStoreContext : DbContext
    {
        public virtual DbSet<Donuts> Donuts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DonutStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Donuts>(entity =>
            {
                entity.HasKey(e => e.DonutId);

                entity.Property(e => e.Flavor)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.ImageUrl).IsRequired();
            });
        }
    }
}
