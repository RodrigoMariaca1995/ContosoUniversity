using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//The Utility class provides the GetLastChars method used to display the last few characters of the concurrency token.
#if SQLiteVersion
using System;

namespace WebAppPractice_ContosoUniversity
{
    public static class Utility
    {
        public static string GetLastChars(Guid token)
        {
            return token.ToString().Substring(
                                    token.ToString().Length - 3);
        }
    }
}
#else
namespace WebAppPractice_ContosoUniversity
{
    public static class Utility
    {
        public static string GetLastChars(byte[] token)
        {
            return token[7].ToString();
        }
    }
}
#endif
