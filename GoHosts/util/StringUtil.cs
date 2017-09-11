using System;

namespace GoHosts.util
{
    public static class StringUtil
    {
        public static bool EqualsIgnore(this string self, string value)
        {
            return self.Equals(value, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
