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
        public DbSet<Invoice> Invoices { get; set; }

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
            modelBuilder.Entity<Invoice>().ToTable("Invoice");

            modelBuilder.Entity<User>()
                .HasOptional<User>(user => user.CreatedBy)
                .WithMany()
                .Map(user => user.MapKey("CreatedById"));
            
            modelBuilder.Entity<User>()
                .HasOptional<User>(user => user.LastModifiedBy)
                .WithMany()
                .Map(user => user.MapKey("LastModifiedById")); 

            modelBuilder.Entity<User>()
                .HasRequired<Role>(user => user.Role);

            modelBuilder.Entity<Role>()
                .HasOptional<User>(role => role.CreatedBy)
                .WithMany()
                .Map(role => role.MapKey("CreatedById"));

            modelBuilder.Entity<Role>()
                .HasOptional<User>(role => role.LastModifiedBy)
                .WithMany()
                .Map(role => role.MapKey("LastModifiedById")); 

            modelBuilder.Entity<Role>()
                .HasMany<PermissionRole>(role => role.PermissionRoles)
                .WithRequired(permissionRole => permissionRole.Role)
                .Map(permissionRole => permissionRole.MapKey("RoleId"));

            modelBuilder.Entity<Permission>()
                .HasOptional<User>(permission => permission.CreatedBy)
                .WithMany()
                .Map(permission => permission.MapKey("CreatedById"));

            modelBuilder.Entity<Permission>()
                .HasOptional<User>(permission => permission.LastModifiedBy)
                .WithMany()
                .Map(permission => permission.MapKey("LastModifiedById")); 
            
            modelBuilder.Entity<PermissionRole>()
                .HasOptional<User>(permissionRole => permissionRole.CreatedBy)
                .WithMany()
                .Map(permissionRole => permissionRole.MapKey("CreatedById"));

            modelBuilder.Entity<PermissionRole>()
                .HasOptional<User>(permissionRole => permissionRole.LastModifiedBy)
                .WithMany()
                .Map(permissionRole => permissionRole.MapKey("LastModifiedById"));

            modelBuilder.Entity<PermissionRole>()
                .HasRequired<Permission>(permissionRole => permissionRole.Permission)
                .WithMany()
                .Map(permissionRole => permissionRole.MapKey("PermissionId"));

            modelBuilder.Entity<Booking>()
                .HasOptional<User>(booking => booking.CreatedBy)
                .WithMany()
                .Map(booking => booking.MapKey("CreatedById"));

            modelBuilder.Entity<Booking>()
                .HasOptional<User>(booking => booking.LastModifiedBy)
                .WithMany()
                .Map(booking => booking.MapKey("LastModifiedById"));
            
            modelBuilder.Entity<Customer>()
                .HasMany<Booking>(customer => customer.Bookings)
                .WithOptional(booking => booking.Customer)
                .Map(m => m.MapKey("CustomerId"));

            modelBuilder.Entity<Customer>()
                .HasOptional<User>(customer => customer.CreatedBy)
                .WithMany()
                .Map(customer => customer.MapKey("CreatedById"));

            modelBuilder.Entity<Customer>()
                .HasOptional<User>(customer => customer.LastModifiedBy)
                .WithMany()
                .Map(customer => customer.MapKey("LastModifiedById"));
            
            modelBuilder.Entity<Customer>()
                .HasRequired<User>(customer => customer.User)
                .WithOptional(user => user.Customer)
                .Map(customer => customer.MapKey("UserId"));
              
            modelBuilder.Entity<Depot>()
                .HasOptional<User>(depot => depot.CreatedBy)
                .WithMany()
                .Map(depot => depot.MapKey("CreatedById"));
            
            modelBuilder.Entity<Depot>()
                .HasOptional<User>(depot => depot.LastModifiedBy)
                .WithMany()
                .Map(depot => depot.MapKey("LastModifiedById")); 
            
            modelBuilder.Entity<Vehicle>()
                .HasOptional<User>(vehicle => vehicle.CreatedBy)
                .WithMany()
                .Map(vehicle => vehicle.MapKey("CreatedById"));
            
            modelBuilder.Entity<Vehicle>()
                .HasOptional<User>(vehicle => vehicle.LastModifiedBy)
                .WithMany()
                .Map(vehicle => vehicle.MapKey("LastModifiedById"));

            modelBuilder.Entity<Vehicle>()
                .HasOptional<Depot>(vehicle => vehicle.HomeDepot)
                .WithMany()
                .Map(vehicle => vehicle.MapKey("HomeDepotId"));

            modelBuilder.Entity<Vehicle>()
                .HasMany<Booking>(bus => bus.Bookings)
                .WithRequired(booking => booking.Vehicle)
                .Map(booking => booking.MapKey("VehicleId"));

            modelBuilder.Entity<Vehicle>()
                .HasMany<MaintenanceCheck>(vehicle => vehicle.MaintenanceChecks)
                .WithRequired(maintenanceCheck => maintenanceCheck.Vehicle)
                .Map(maintenanceCheck => maintenanceCheck.MapKey("VehicleId"));

            modelBuilder.Entity<Invoice>()
                .HasOptional<User>(invoice => invoice.CreatedBy)
                .WithMany()
                .Map(invoice => invoice.MapKey("CreatedById"));

            modelBuilder.Entity<Invoice>()
                .HasOptional<User>(invoice => invoice.LastModifiedBy)
                .WithMany()
                .Map(invoice => invoice.MapKey("LastModifiedById"));

            modelBuilder.Entity<Invoice>()
                .HasOptional<Customer>(invoice => invoice.Customer)
                .WithMany()
                .Map(invoice => invoice.MapKey("CustomerId")); 

            base.OnModelCreating(modelBuilder);
        }
    }
}
