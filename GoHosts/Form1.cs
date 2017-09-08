using GoHosts.ctl;
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

        MyLoadingCtl loading = new MyLoadingCtl(128, true);
        BackgroundWorker background = new BackgroundWorker();

        SynchronizationContext context = null;

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

        private void HideLoading(object str)
        {
            loading.Hide();
            MessageBox.Show(str + "完成!");
        }

        private void UpdateInfo()
        {
            FileInfo info = new Hosts().GetSystemHostsInfo();

            Label_LastUpdate.Text = "上次更新时间：" + info.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
            double size = Math.Round((double)info.Length / 1024, 2);
            Label_Size.Text = "hosts文件大小：" + size + "KB";
        }


        private void update_Click(object sender, EventArgs e)
        {

            ShowLoading();

            Task task = new Task(()=>
            {
                string hosts = new Hosts().GetHostsFile();
                new Hosts().ReplaceSystemHosts(hosts);
                context.Post(HideLoading, "更新");
            });

            task.Start();
        }

        delegate void UpdateUI();

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
