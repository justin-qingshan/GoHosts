using System;
using System.IO;
using System.Net;

namespace GoHosts
{
    public class HttpUtil
    {
        public static bool DownloadFile(string url, string path, bool overwrite = true)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(path))
                throw new ArgumentNullException();

            if (File.Exists(path) && !overwrite)
                return false;

            if (File.Exists(path) && overwrite)
                File.Delete(path);

            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;

            using (Stream responseStream = response.GetResponseStream())
            {
                using (FileStream fileStream = new FileStream(path, FileMode.Create))
                {
                    byte[] buffer = new byte[4096];


                    int size = responseStream.Read(buffer, 0, buffer.Length);
                    while (size > 0)
                    {
                        fileStream.Write(buffer, 0, size);
                        size = responseStream.Read(buffer, 0, buffer.Length);
                    }
                }
            }

            return true;
        }
    }
}
