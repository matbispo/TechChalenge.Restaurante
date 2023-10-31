using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Context
{
    public class TechChallengeDbContext : DbContext
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

            modelBuilder.Entity<Product>(e =>
            {
                e.HasKey(tc => tc.Id);

                e.Property(tc => tc.Name)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .HasColumnName("Name");

                e.Property(tc => tc.Description)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnType("varchar(200)")
                .HasColumnName("Description");

                e.Property(tc => tc.Price)
                .IsRequired();

                e.Property(tc => tc.Category)
                .IsRequired();
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.HasKey(tc=> tc.Id);

                e.Property(tc => tc.RequestDate)
                .HasColumnName("Request_Date")
                .IsRequired();

                e.Property(tc => tc.TotalPrice)
                .HasColumnType("decimal")
                .IsRequired();

                e.Property(tc => tc.OrderStatus)
                .IsRequired();

                e.Property(tc => tc.IsDeleted).IsRequired();

                e.HasOne(tc => tc.Customer)
                 .WithMany(x => x.Orders)
                 .HasForeignKey(x=> x.CustomerId);
            });

            modelBuilder.Entity<OrderProduct>(e => 
            {
                e.HasKey(p=> new { p.OrderId, p.ProductId});
            });
        }
    }
}
