using System;
using Marathon.Domain.Common;
using Marathon.Domain.Entities;

namespace Marathon.Domain.RepositoryContracts
{
    public interface ICustomerRepository : IRepository<Customer, Guid>
    {
    }
}

