using System;
using System.Collections.Generic;

namespace GoHosts.hosts
{
    public class HostsUtil
    {
        public static void UpdateHosts(Action finishDownload, Action finishOrgnize,
            Action finishReplace, Action finish)
        {
            Hosts hosts = new Hosts();
            List<string> files = hosts.GetHostsFiles(null);
            finishDownload?.Invoke();

            string file = hosts.CombineHosts(files, null);
            finishOrgnize?.Invoke();

            hosts.ReplaceSystemHosts(file);
            finishReplace?.Invoke();

            hosts.CleanTmpFiles();
            finish?.Invoke();
        }
    }
}
