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
            
            //modelBuilder.Entity<Bus>()
            //    .HasRequired<User>(bus => bus.CreatedBy);
            
            //modelBuilder.Entity<Bus>()
            //    .HasMany<Booking>(bus => bus.Bookings)
            //    .WithRequired(booking => booking.Bus)
            //    .HasForeignKey(booking => booking.BusId);

            //modelBuilder.Entity<Booking>()
            //    .HasRequired<User>(booking => booking.CreatedBy);

            //modelBuilder.Entity<Booking>()
            //    .HasRequired<Customer>(booking => booking.Customer);

            //modelBuilder.Entity<User>()
            //    .HasRequired<User>(user => user.CreatedBy)
            //    .WithMany()
            //    .HasForeignKey(user => user.CreatedById);

            //modelBuilder.Entity<Role>()
            //    .HasRequired<User>(role => role.CreatedBy);

            //modelBuilder.Entity<Bus>()
            //    .HasRequired<User>(bus => bus.CreatedBy);

            //modelBuilder.Entity<Enquiry>()
            //    .HasOptional<Booking>(enquiry => enquiry.ResultingBooking);

            //modelBuilder.Entity<Enquiry>()
            //    .HasRequired<User>(enquiry => enquiry.CreatedBy);

            base.OnModelCreating(modelBuilder);
        }
    }
}
