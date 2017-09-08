using System;
using System.Windows.Forms;

namespace GoHosts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void update_Click(object sender, EventArgs e)
        {
            string hosts = new Hosts().GetHostsFile();
            new Hosts().ReplaceSystemHosts(hosts);
        }
    }
}
