using Marathon.Data.Repositories;
using Marathon.Domain.RepositoryContracts;
using Ninject;

namespace Marathon.Data.Core
{
    public class DataRegistry 
    {
        public void RegisterServices(IKernel kernel)
        {
             kernel.Bind<IUserRepository>().To<UserRepository>();
             kernel.Bind<IRoleRepository>().To<RoleRepository>();
             kernel.Bind<IBookingRepository>().To<BookingRepository>();
             kernel.Bind<IVehicleRepository>().To<VehicleRepository>();
             kernel.Bind<IDepotRepository>().To<DepotRepository>();
             kernel.Bind<ICustomerRepository>().To<CustomerRepository>();
        }
    }
}
