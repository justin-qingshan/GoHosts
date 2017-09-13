using GoHosts.hosts;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace GoHosts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateInfo();
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

            using (BackgroundWorker bwork = new BackgroundWorker())
            {
                bwork.DoWork += delegate(object s, DoWorkEventArgs ea) 
                {
                    HostsUtil.UpdateHosts(bwork);
                };
                bwork.RunWorkerAsync();
                bwork.WorkerReportsProgress = true;
                bwork.ProgressChanged += delegate (object s, ProgressChangedEventArgs ea)
                {
                    Tuple<UpdateHostsState, int, int> tuple = ea.UserState as Tuple<UpdateHostsState, int, int>;

                    if (tuple.Item1 == UpdateHostsState.FINISH)
                    {
                        LoadingHide();
                        UpdateInfo();
                        MessageBox.Show(this, "Update Finished!", "Update Hosts");
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
                };
            }
        }

        
        
        

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (loading != null && loading.Visible)
                loading.Invalidate();
        }

        private void Label_Location_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Label_Location.Text))
                return;

            Process.Start("explorer.exe", Path.GetDirectoryName(Label_Location.Text));
        }

        private void btn_clearcache_Click(object sender, EventArgs e)
        {
            HostsUtil.ClearDNSCache();
            MessageBox.Show(this, "Clear DNS Success!", "Clear DNS");
        }

        private void btn_restore_Click(object sender, EventArgs e)
        {
            LoadingShow();
            using(BackgroundWorker bwork = new BackgroundWorker())
            {
                bwork.RunWorkerCompleted += delegate(object obj, RunWorkerCompletedEventArgs ea)
                {
                    LoadingHide();
                    UpdateInfo();
                    MessageBox.Show(this, "Restore Finished!", "Restore Hosts");
                };
                bwork.DoWork += delegate(object obj, DoWorkEventArgs ea)
                {
                    HostsUtil.RestoreDefaultHosts();
                };
                bwork.RunWorkerAsync();
            }
        }

        private void LoadingShow()
        {
            loading.Show(panel1);
        }

        private void LoadingShow(string msg)
        {
            loading.Show(panel1);
            loading.Text = msg;
        }

        private void LoadingHide()
        {
            loading.Hide();
        }

        private void LoadingUpdate(string str)
        {
            loading.Text = str;
        }
    }
}
