using GoHosts.ctl;
using GoHosts.hosts;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoHosts
{
    public partial class Form1 : Form
    {
        
        BackgroundWorker background = new BackgroundWorker();

        SynchronizationContext context = null;
        Loading loading = new Loading();

        public Form1()
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
            UpdateInfo();
        }


        private void ShowLoading()
        {
            loading.ShowLoading(this);
        }

        private void HideLoading()
        {
            loading.Hide();
        }

        private void UpdateLoading(string str)
        {
            loading.LoadingMsg = str;
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

            ShowLoading();

            Task task = new Task(()=>
            {
                //HostsUtil.UpdateHosts(null, null, null, () =>
                //{
                //    HideLoading();
                //    UpdateInfo();
                //    MessageBox.Show("更新完成");
                //});

                context.Post((obj) =>
                {
                    UpdateLoading("下载hosts中");
                }, "");
                //string hosts = new Hosts().GetHostsFile();
                Thread.Sleep(10000);


                context.Post((obj) =>
                {
                    UpdateLoading("整合hosts中");
                }, "");
                Thread.Sleep(5000);
                //new Hosts().ReplaceSystemHosts(hosts);

                context.Post((obj) => {
                    HideLoading();
                    UpdateInfo();
                    MessageBox.Show("更新完成");
                }, "");
            });

            task.Start();
        }
        

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (loading != null && loading.Visible)
                loading.Invalidate();
        }
    }
}
