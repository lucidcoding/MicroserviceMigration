using System;
using System.Linq;
using Marathon.Data.Common;
using Marathon.Domain.Entities;
using Marathon.Domain.RepositoryContracts;

namespace Marathon.Data.Repositories
{
    public class CustomerRepository : Repository<Customer, Guid>, ICustomerRepository
    {
        public CustomerRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }

        public Customer GetByUsername(string username)
        {
            return Context
                .Customers
                .Where(customer => customer.User.Username.Equals(username))
                .Single();
        }
    }
}
