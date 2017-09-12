using System.Drawing;
using System.Windows.Forms;

namespace GoHosts.ctl
{
    public partial class LoadingCtl : UserControl
    {

        private int _alpha = 125;
        private string _loading_msg = "...";


        public LoadingCtl()
        {
            InitializeComponent();

            SetStyle(
                ControlStyles.UserPaint |
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.OptimizedDoubleBuffer |
                ControlStyles.SupportsTransparentBackColor |
                ControlStyles.Selectable |
                ControlStyles.ResizeRedraw,
                true);
            Visible = false;
            //Enabled = false;

            BackColor = Color.FromArgb(_alpha, 240, 240, 240);
            //BackColor = Color.Transparent;
            Dock = DockStyle.Fill;
            label.Text = _loading_msg;
            pic.Image = Properties.Resources.loading;
        }

        public void Show(Control control)
        {
            //control.Controls.Add(this);
            //Parent = control;
            BringToFront();
            Visible = true;
            Enabled = true;
            Show();
        }


        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            pic.Invalidate();
            label.Text = _loading_msg;
            label.Invalidate();
            FitLocation();
            base.OnInvalidated(e);
        }

        private void FitLocation()
        {
            int height = CalcTotalHeight();
            label.Location = new Point(Location.X + (Width - label.Width) / 2,
                Location.Y + (Height - height) / 2 + (height - label.Height));
            pic.Location = new Point(Location.X + (Width - pic.Width) / 2,
                Location.Y + (Height - height) / 2);
        }

        private int CalcTotalHeight()
        {
            int picHeight = pic == null ? 0 : pic.Height;
            int labelHeight = pic == null ? 0 : label.Height;

            return (picHeight == 0 || labelHeight == 0) ?
                picHeight + labelHeight : picHeight + 8 + labelHeight;
        }


        public new string Text
        {
            get { return _loading_msg; }
            set { _loading_msg = value; Invalidate(); }
        }

    }
}
