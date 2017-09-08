using System;
using System.Collections.Generic;
using System.IO;

namespace GoHosts
{
    public class Hosts
    {
        public static readonly string[] DEFAULT_URLS =
        {
            "https://raw.githubusercontent.com/justin-qingshan/hosts/master/hosts-files/hosts"
        };

        public static readonly string PATH_ROOT = AppDomain.CurrentDomain.BaseDirectory;

        public static readonly string FOLDER_TMP = PATH_ROOT + "tmp/";
        public static readonly string FILE_SOURCES = PATH_ROOT + "sources.txt";

        public static readonly string HOSTS_SYS = Environment.SystemDirectory + "/drivers/etc/hosts";
        public static readonly string HOSTS_SYS_BAK = HOSTS_SYS + "-bak";


        static Hosts()
        {
            if (!File.Exists(FILE_SOURCES))
            {
                using(StreamWriter writer = new StreamWriter(File.Create(FILE_SOURCES)))
                {
                    foreach (string url in DEFAULT_URLS)
                        writer.WriteLine(url);
                    writer.Flush();
                }
            }
        }

        public string GetHostsFile()
        {
            if (Directory.Exists(FOLDER_TMP))
                Directory.Delete(FOLDER_TMP, true);

            Directory.CreateDirectory(FOLDER_TMP);

            List<string> urls = new List<string>();

            using (StreamReader reader = new StreamReader(new FileStream(FILE_SOURCES, FileMode.Open)))
            {
                string str = reader.ReadLine();
                while(str != null)
                {
                    if (!str.StartsWith("#"))
                        urls.Add(str);
               
                    str = reader.ReadLine();
                }
            }

            List<string> files = new List<string>();
            foreach(string url in urls)
            {
                string file = FOLDER_TMP + DateTime.Now.ToString("mm-ss") + ".txt";
                if (HttpUtil.DownloadFile(url, file))
                    files.Add(file);
            }


            string outputFile = FOLDER_TMP + "hosts.txt";
            FileUtil.CombineStr(outputFile, files);

            return outputFile;
        }


        public bool ReplaceSystemHosts(string hostsFile)
        {
            if (string.IsNullOrEmpty(hostsFile))
                return false;

            if (File.Exists(HOSTS_SYS_BAK))
                File.Delete(HOSTS_SYS_BAK);

            if (File.Exists(HOSTS_SYS))
                File.Move(HOSTS_SYS, HOSTS_SYS_BAK);

            File.Move(hostsFile, HOSTS_SYS);
            return true;
        }
    }
}
