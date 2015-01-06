using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Marathon.Domain.InfrastructureContracts
{
    public interface IEmailer
    {
        void Send(
            string to,
            string from,
            string subject,
            string body);
    }
}
