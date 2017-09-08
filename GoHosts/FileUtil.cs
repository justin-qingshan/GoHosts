using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoHosts
{
    public class FileUtil
    {
        public static bool Combine(string outputFile, params string[] inputFiles)
        {
            if (string.IsNullOrEmpty(outputFile))
                throw new ArgumentNullException("outputFile cannot be null.");

            if (File.Exists(outputFile))
                File.Delete(outputFile);

            using (FileStream stream = new FileStream(outputFile, FileMode.Create))
            {
                byte[] buffer = new byte[4096];
                int size = 0;

                foreach(string input in inputFiles)
                {
                    if (string.IsNullOrEmpty(input) || File.Exists(input))
                        continue;

                    using(FileStream read = new FileStream(input, FileMode.Open))
                    {
                        size = read.Read(buffer, 0, buffer.Length);
                        while (size > 0)
                        {
                            stream.Write(buffer, 0, size);
                            size = read.Read(buffer, 0, buffer.Length);
                        }
                        read.Close();
                    }
                }
            }

            return true;
        }


        public static bool CombineStr(string outputFile, params string[] inputFiles)
        {
            if (string.IsNullOrEmpty(outputFile))
                throw new ArgumentNullException("outputFile cannot be null.");

            if (File.Exists(outputFile))
                File.Delete(outputFile);

            using (StreamWriter stream = new StreamWriter(File.Create(outputFile)))
            {
                foreach (string input in inputFiles)
                {
                    if (string.IsNullOrEmpty(input) || File.Exists(input))
                        continue;

                    using (StreamReader reader = new StreamReader(input))
                    {
                        string str = reader.ReadToEnd();
                        stream.Write(str);
                        stream.Write(Environment.NewLine);
                    }
                }
            }

            return true;
        }

        public static bool CombineStr(string outputFile, List<string> inputFiles)
        {
            if (string.IsNullOrEmpty(outputFile))
                throw new ArgumentNullException("outputFile cannot be null.");

            if (File.Exists(outputFile))
                File.Delete(outputFile);

            using (StreamWriter stream = new StreamWriter(File.Create(outputFile)))
            {
                foreach (string input in inputFiles)
                {
                    if (string.IsNullOrEmpty(input) || !File.Exists(input))
                        continue;

                    using (StreamReader reader = new StreamReader(input))
                    {
                        string str = reader.ReadToEnd();
                        stream.Write(str);
                        stream.Write(Environment.NewLine);
                        stream.Flush();
                    }
                }
            }

            return true;
        }


    }
}
