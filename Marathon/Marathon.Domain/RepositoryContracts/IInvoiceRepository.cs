﻿using System;
using System.Collections.Generic;
using Marathon.Domain.Common;
using Marathon.Domain.Entities;

namespace Marathon.Domain.RepositoryContracts
{
    public interface IInvoiceRepository : IRepository<Invoice, Guid>
    {
    }
}
