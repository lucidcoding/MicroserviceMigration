using System.Configuration;
using System.Data.Entity;
using Marathon.Domain.Entities;

namespace Marathon.Data.Core
{
    public class Context : DbContext
    {
        public Context() : base(ConfigurationManager.ConnectionStrings["Marathon"].ConnectionString)
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Depot> Depots { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionRole> PermissionRoles { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<MaintenanceCheck> MaintenanceChecks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Depot>().ToTable("Depot");
            modelBuilder.Entity<Vehicle>().ToTable("Vehicle");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<Permission>().ToTable("Permission");
            modelBuilder.Entity<PermissionRole>().ToTable("PermissionRole");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Customer>().ToTable("Customer");
            
            modelBuilder.Entity<User>()
                .HasOptional<User>(user => user.CreatedBy)
                .WithMany()
                .HasForeignKey(user => user.CreatedById);
            
            modelBuilder.Entity<User>()
                .HasOptional<User>(user => user.LastModifiedBy)
                .WithMany()
                .HasForeignKey(user => user.CreatedById); ;

            modelBuilder.Entity<User>()
                .HasRequired<Role>(user => user.Role);

            modelBuilder.Entity<Role>()
                .HasOptional<User>(role => role.CreatedBy);

            modelBuilder.Entity<Role>()
                .HasOptional<User>(role => role.LastModifiedBy);

            modelBuilder.Entity<Role>()
                .HasMany<PermissionRole>(role => role.PermissionRoles);

            modelBuilder.Entity<Permission>()
                .HasOptional<User>(permission => permission.CreatedBy);

            modelBuilder.Entity<Permission>()
                .HasOptional<User>(permission => permission.LastModifiedBy);
            
            modelBuilder.Entity<PermissionRole>()
                .HasOptional<User>(permissionRole => permissionRole.CreatedBy);

            modelBuilder.Entity<PermissionRole>()
                .HasOptional<User>(permissionRole => permissionRole.LastModifiedBy);
            
            modelBuilder.Entity<PermissionRole>()
                .HasRequired<Permission>(permissionRole => permissionRole.Permission);

            modelBuilder.Entity<Booking>()
                .HasOptional<User>(booking => booking.CreatedBy);

            modelBuilder.Entity<Booking>()
                .HasOptional<User>(booking => booking.LastModifiedBy);

            modelBuilder.Entity<Booking>()
                .HasOptional<Customer>(booking => booking.Customer);
            
            modelBuilder.Entity<Customer>()
                .HasOptional<User>(customer => customer.CreatedBy);
            
            modelBuilder.Entity<Customer>()
                .HasOptional<User>(customer => customer.User);

            modelBuilder.Entity<Customer>()
                .HasOptional<User>(customer => customer.LastModifiedBy);
            
            modelBuilder.Entity<Depot>()
                .HasOptional<User>(depot => depot.CreatedBy);
            
            modelBuilder.Entity<Depot>()
                .HasOptional<User>(depot => depot.LastModifiedBy);
            
            modelBuilder.Entity<Vehicle>()
                .HasOptional<User>(vehicle => vehicle.CreatedBy);
            
            modelBuilder.Entity<Vehicle>()
                .HasOptional<User>(vehicle => vehicle.LastModifiedBy);
            
            modelBuilder.Entity<Vehicle>()
                .HasOptional<Depot>(vehicle => vehicle.HomeDepot);

            modelBuilder.Entity<Vehicle>()
                .HasMany<Booking>(bus => bus.Bookings)
                .WithRequired(booking => booking.Vehicle)
                .HasForeignKey(booking => booking.VehicleId);

            modelBuilder.Entity<Vehicle>()
                .HasMany<MaintenanceCheck>(bus => bus.MaintenanceChecks)
                .WithRequired(maintenanceCheck => maintenanceCheck.Vehicle)
                .HasForeignKey(maintenanceCheck => maintenanceCheck.VehicleId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
