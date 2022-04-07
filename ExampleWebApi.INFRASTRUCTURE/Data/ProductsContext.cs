using ExampleWebApi.INFRASTRUCTURE.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebApi.INFRASTRUCTURE.Data
{
    public class ProductsContext : DbContext
    {
        public ProductsContext()
        {
        }
        public ProductsContext(DbContextOptions<ProductsContext> options)
           : base(options)
        {
        }

        public virtual DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Id)
                    .HasName("PK__PRODUCTS");

                entity.Property(d => d.Id)
                    .HasDefaultValueSql("NEWID()");

                entity.ToTable("PRODUCTS");

                entity.Property(d => d.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(d => d.Number);

                entity.Property(d => d.Quantity);

                entity.Property(d => d.Description)
                    .HasMaxLength(200);

                entity.Property(d => d.Price)
                    .IsRequired();
            });
        }
    }

}
