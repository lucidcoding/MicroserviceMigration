using System;

namespace Marathon.UI.Security
{
    public interface IUserProvider
    {
        string GetUsername();
    }
}
