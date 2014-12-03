using System;
using Marathon.Data.Core;

namespace Marathon.Data.Common
{
    public interface IContextProvider : IDisposable
    {
        Context GetContext();
        void SaveChanges();
    }
}
