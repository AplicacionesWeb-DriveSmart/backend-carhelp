using backend_carhelp.Iam.Domain.Model.Aggregates;
using backend_carhelp.Iam.Domain.Model.Entities;
using backend_carhelp.shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using backend_carhelp.Users.Domain.Model.Entities;
using backend_carhelp.Workshop_management.Domain.Model.Aggregates;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace backend_carhelp.shared.Infrastructure.Persistence.EFC.Configuration
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            base.OnConfiguring(builder);
            // Enable Audit Fields Interceptors
            builder.AddCreatedUpdatedInterceptor();
        }
    
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            // User Context
            builder.Entity<User>().HasKey(u => u.Id);
            builder.Entity<User>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<User>().OwnsOne(p => p.Name, n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).IsRequired().HasMaxLength(50).HasColumnName("FirstName");
                n.Property(p => p.LastName).IsRequired().HasMaxLength(50).HasColumnName("LastName");
            });
            builder.Entity<User>().OwnsOne(p => p.Email, e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Address).HasColumnName("EmailAddress");
            });

            builder.Entity<User>().OwnsOne(p => p.Address, a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Street).HasColumnName("AddressStreet");
                a.Property(s => s.Number).HasColumnName("AddressNumber");
                a.Property(s => s.City).HasColumnName("AddressCity");
                a.Property(s => s.PostalCode).HasColumnName("AddressPostalCode");
                a.Property(s => s.Country).HasColumnName("AddressCountry");
            });
        
            builder.Entity<User>().Property(p => p.PhoneNumber).IsRequired().HasMaxLength(15);
            builder.Entity<User>().Property(p => p.Password).IsRequired().HasMaxLength(100);
            builder.Entity<User>().Property(p => p.Username).IsRequired().HasMaxLength(50);
            builder.Entity<User>().Property(p => p.ImageUrl).HasMaxLength(300);

            // Customer Relationships
            builder.Entity<Customer>().HasKey(c => c.Id);
            builder.Entity<Customer>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Customer>().HasOne(c => c.User)
                .WithOne(u => u.Customer)
                .HasForeignKey<Customer>(c => c.UserId)
                .HasPrincipalKey<User>(u => u.Id);
            
            // Workshop Management Context
            builder.Entity<Vehicle>().HasKey(v => v.Id);
            builder.Entity<Vehicle>().Property(v => v.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Vehicle>().Property(v => v.Plate).HasColumnName("Plate");
            builder.Entity<Vehicle>().Property(v => v.Brand).HasColumnName("Brand");
            builder.Entity<Vehicle>().Property(v => v.Year).HasColumnName("Year");
            builder.Entity<Vehicle>().Property(v => v.Colour).HasColumnName("Colour");
            builder.Entity<Vehicle>().Property(v => v.ImageUrl).HasColumnName("ImageUrl");
            builder.Entity<Vehicle>().Property(v => v.Mileage).HasColumnName("Mileage");
            
            
            // Apply SnakeCase Naming Convention
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
