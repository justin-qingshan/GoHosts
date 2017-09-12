﻿using GoHosts.ctl;
using GoHosts.hosts;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace GoHosts
{
    public partial class Form1 : Form
    {
        
        BackgroundWorker bwork = new BackgroundWorker();

        SynchronizationContext context = null;
        public Form1()
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
            UpdateInfo();
        }


        private void LoadingShow()
        {
            loading.Show(panel1);
        }

        private void LoadingHide()
        {
            loading.Hide();
        }

        private void LoadingUpdate(string str)
        {
            loading.Text = str;
        }

        private void UpdateInfo()
        {
            FileInfo info = new Hosts().GetSystemHostsInfo();

            Label_LastUpdate.Text = info.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            double size = Math.Round((double)info.Length / 1024, 2);
            Label_Size.Text = size + "KB";
            Label_Location.Text = Hosts.HOSTS_SYS.Replace('\\', '/');
            
        }


        private void update_Click(object sender, EventArgs e)
        {
            LoadingShow();

            bwork.DoWork += HostsUtil.UpdateHosts;
            bwork.RunWorkerAsync();
            bwork.WorkerReportsProgress = true;
            bwork.ProgressChanged += HostsUpdateProgress;
        }

        


        private void HostsUpdateProgress(object sender, ProgressChangedEventArgs e)
        {
            Tuple<UpdateHostsState, int, int> tuple = e.UserState as Tuple<UpdateHostsState, int, int>;

            if (tuple.Item1 == UpdateHostsState.FINISH)
            {
                LoadingHide();
                UpdateInfo();
                MessageBox.Show("更新完成");
                return;
            }

            string name = "";
            switch (tuple.Item1)
            {
                case UpdateHostsState.DOWNLOAD:
                    name = "下载hosts源文件中";
                    break;
                case UpdateHostsState.COMBINE:
                    name = "整合hosts文件中";
                    break;
                case UpdateHostsState.REPLACE:
                    name = "替换系统hosts中";
                    break;
                case UpdateHostsState.CLEAN:
                    name = "清理中";
                    break;
            }

            name += (tuple.Item2 == 0 ? "" : ": " + tuple.Item2 + "/" + tuple.Item3);
            LoadingUpdate(name);
        }
        

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (loading != null && loading.Visible)
                loading.Invalidate();
        }
    }
}
