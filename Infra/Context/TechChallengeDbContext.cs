using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    internal class TechChallengeDbContext : DbContext
    {
        public TechChallengeDbContext(DbContextOptions<TechChallengeDbContext> options) : base(options)
        {
            
        }

        public DbSet<Customer> Customer { get; set; } 
        public DbSet<Order> Order { get; set; } 
        public DbSet<Product> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(e => 
            {
                e.HasKey(tc => tc.Id);

                e.Property(tc => tc.Cpf)
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("varchar(20)")
                .HasColumnName("CPF");

                e.Property(tc => tc.Email)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .HasColumnName("Email");

                e.Property(tc => tc.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .HasColumnName("Name");

            });

            modelBuilder.Entity<Order>(e =>
            {
                e.HasKey(tc=> tc.Id);


            });

            modelBuilder.Entity<Product>( e=>
            { 

            });
        }
    }
}
