using System.IO;
using System.Threading;

namespace GoHosts.util
{
    public class DirectoryUtil
    {
        public static void Delete(string dir, int maxTimes = 0, bool recursice = true)
        {
            int index = 0;
            maxTimes = maxTimes <= 0 ? 1 : maxTimes;
            while(index < maxTimes && Directory.Exists(dir))
            {
                Directory.Delete(dir, recursice);
                index++;
                Thread.Sleep(100);
            }
        }
    }
}
