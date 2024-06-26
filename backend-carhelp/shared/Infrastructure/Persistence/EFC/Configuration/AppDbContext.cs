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
                .HasPrincipalKey<Iam.Domain.Model.Aggregates.User>(u => u.Id);
            

            // Workshop Relationships
            builder.Entity<Workshop>().HasKey(w => w.Id);
            builder.Entity<Workshop>().Property(w => w.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Workshop>().HasOne(w => w.User)
                .WithOne(u => u.Workshop)
                .HasForeignKey<Workshop>(w => w.UserId)
                .HasPrincipalKey<Iam.Domain.Model.Aggregates.User>(u => u.Id);
            
            // Notification Relationships
            builder.Entity<Notification>().HasKey(n => n.Id);
            builder.Entity<Notification>().Property(n => n.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Notification>().HasOne(n => n.User)
                .WithOne(u => u.Notification)
                .HasForeignKey<Notification>(n => n.UserId)
                .HasPrincipalKey<Iam.Domain.Model.Aggregates.User>(u => u.Id);

            // Workshop Management Context
            // Vehicle Aggregate
            builder.Entity<Vehicle>().HasKey(v => v.Id);
            builder.Entity<Vehicle>().Property(v => v.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Vehicle>().Property(v => v.Plate).HasColumnName("Plate");
            builder.Entity<Vehicle>().Property(v => v.Brand).HasColumnName("Brand");
            builder.Entity<Vehicle>().OwnsOne(v => v.CarModelInfo, n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(v => v.Name).HasColumnName("ModelName");
                n.Property(v => v.Year).HasColumnName("ModelYear");
            });
            builder.Entity<Vehicle>().Property(v => v.Colour).HasColumnName("Colour");
            builder.Entity<Vehicle>().Property(v => v.ImageUrl).HasColumnName("ImageUrl");
            builder.Entity<Vehicle>().Property(v => v.Mileage).HasColumnName("Mileage");
            
            // Invoice Aggregate
            builder.Entity<Invoice>().HasKey(i => i.Id);
            builder.Entity<Invoice>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Invoice>().Property(i => i.Number).HasColumnName("Number");
            builder.Entity<Invoice>().Property(i => i.IssueDate).HasColumnName("IssueDate");
            builder.Entity<Invoice>().Property(i => i.Total).HasColumnName("Total");
            builder.Entity<Invoice>().Property(i => i.Status).HasColumnName("Status");
            builder.Entity<Invoice>().Property(i => i.Detail).HasColumnName("Detail");
            
            //Product Aggregate
            builder.Entity<Product>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Id).ValueGeneratedOnAdd();
                entity.Property(i => i.Name).HasColumnName("Name");
                entity.Property(i => i.Quantity).HasColumnName("Quantity");
                entity.Property(i => i.Price).HasColumnName("Price");
                entity.Property(i => i.ImageUrl).HasColumnName("ImageUrl");
                entity.Property(i => i.WorkshopId).HasColumnName("WorkshopId");
            });
            
            //Advertasing Aggregate
            builder.Entity<Advertasing>(entity =>
            {
                entity.HasKey(i => i.Id);
                entity.Property(i => i.Id).ValueGeneratedOnAdd();
                entity.Property(i => i.Name).HasColumnName("Name");
                entity.Property(i => i.ImageUrl).HasColumnName("Quantity");
                entity.Property(i => i.Slogan).HasColumnName("Price");
                entity.Property(i => i.Message).HasColumnName("ImageUrl");
                entity.Property(i => i.WorkshopId).HasColumnName("WorkshopId");
            });
            


            // Apply SnakeCase Naming Convention
            builder.UseSnakeCaseWithPluralizedTableNamingConvention();

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Product> Products { get; set; }
    }
    
}
