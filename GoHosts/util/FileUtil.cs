using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace GoHosts.util
{
    public class FileUtil
    {

        public static void Delete(string file, int maxTimes = 0)
        {
            int index = 0;
            maxTimes = maxTimes <= 0 ? 1 : maxTimes;

            while(index < maxTimes && File.Exists(file))
            {
                File.Delete(file);
                index++;
                Thread.Sleep(100);
            }
        }



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


        
        public static bool CombineStr(string outputFile, List<string> inputFiles, Action<int, int> handler)
        {
            if (string.IsNullOrEmpty(outputFile))
                throw new ArgumentNullException("outputFile cannot be null.");

            if (File.Exists(outputFile))
                File.Delete(outputFile);

            using (StreamWriter stream = new StreamWriter(File.Create(outputFile)))
            {
                int index = 0;
                foreach (string input in inputFiles)
                {
                    index++;
                    handler(index, inputFiles.Count);

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


        public static bool CombineHosts(string output, List<string> inputs, Action<int, int> progress)
        {
            if (string.IsNullOrEmpty(output))
                throw new ArgumentNullException("outputFile cannot be null.");

            if (!Directory.Exists(Path.GetDirectoryName(output)))
                Directory.CreateDirectory(Path.GetDirectoryName(output));
            else if (File.Exists(output))
                File.Delete(output);

            using (StreamWriter stream = new StreamWriter(File.Create(output)))
            {
                int index = 0;
                HashSet<string> keys = new HashSet<string>();
                foreach (string input in inputs)
                {
                    progress?.Invoke(++index, inputs.Count);

                    //If input file does not exist, then continue to next loop.
                    if (string.IsNullOrEmpty(input) || !File.Exists(input))
                        continue;

                    using (StreamReader reader = new StreamReader(input))
                    {
                        string str = reader.ReadLine();

                        //read one line once, and check if the key is aready existing.
                        while(str != null)
                        {
                            str = str.Trim();
                            //ignore line starting with '#' when check keys.
                            if (!string.IsNullOrWhiteSpace(str) && !str.StartsWith("#"))
                            {
                                string key = str.Trim().Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries)[1];
                                key = key.ToLower();
                                if (keys.Contains(key))
                                {
                                    str = reader.ReadLine().Trim();
                                    continue;
                                }
                                keys.Add(key);
                            }

                            stream.WriteLine(str);
                            str = reader.ReadLine();
                        }
                        stream.Flush();
                    }
                    
                }
            }

            return true;
        }



        public static void MoveByCmd(string sourcePath, string dstPath, bool useAdmin = false)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.Arguments = string.Format("move '{0}' '{1}'", sourcePath, dstPath);
            start.Verb = "runas";

            Process.Start(start);
        }
        

    }
}
