using System;
using System.Linq;
using Marathon.Data.Common;
using Marathon.Domain.Entities;
using Marathon.Domain.RepositoryContracts;
using System.Collections.Generic;

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

        public IList<Customer> GetAllOrderedByFamilyName()
        {
            return Context
                .Customers
                .OrderBy(customer => customer.FamilyName)
                .ToList();
        }
    }
}
