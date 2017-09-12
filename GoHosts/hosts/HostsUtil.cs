using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;

namespace GoHosts.hosts
{
    public class HostsUtil
    {

        public static void UpdateHosts(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker bwork = sender as BackgroundWorker;

            Hosts hosts = new Hosts();
            List<string> files = hosts.GetHostsFiles((index, total) =>
            {
                bwork.ReportProgress(1, Tuple.Create(UpdateHostsState.DOWNLOAD, index, total));
            });

            string file = hosts.CombineHosts(files, (index, total) => 
            {
                bwork.ReportProgress(1, Tuple.Create(UpdateHostsState.COMBINE, index, total));
            });


            bwork.ReportProgress(1, Tuple.Create(UpdateHostsState.REPLACE, 0, 0));
            Thread.Sleep(1000);
            hosts.ReplaceSystemHosts(file);

            bwork.ReportProgress(1, Tuple.Create(UpdateHostsState.CLEAN, 0, 0));
            Thread.Sleep(1000);
            hosts.CleanTmpFiles();

            Thread.Sleep(1000);
            bwork.ReportProgress(1, Tuple.Create(UpdateHostsState.FINISH, 0, 0));
        }

    }


    public enum UpdateHostsState
    {
        DOWNLOAD = 1,
        COMBINE = 2,
        REPLACE = 3,
        CLEAN = 4,
        FINISH = 5
    }

    
}
