using System;
using System.Linq;
using Marathon.Data.Common;
using Marathon.Domain.Entities;
using Marathon.Domain.RepositoryContracts;

namespace Marathon.Data.Repositories
{
    public class InvoiceRepository : Repository<Invoice, Guid>, IInvoiceRepository
    {
        public InvoiceRepository(IContextProvider contextProvider) :
            base(contextProvider)
        {
        }
    }
}
