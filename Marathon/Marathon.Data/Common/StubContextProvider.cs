using Marathon.Data.Core;

namespace Marathon.Data.Common
{
    public class StubContextProvider : IContextProvider
    {
        public Context GetContext()
        {
            return null;
        }

        public void Dispose()
        {
        }

        public void SaveChanges()
        {
        }
    }
}
