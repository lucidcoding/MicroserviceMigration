using System;

namespace Marathon.Internal.UI.Security
{
    public interface IUserProvider
    {
        string GetUsername();
    }
}
