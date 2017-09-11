using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GoHosts.ctl
{

    public class MyLoadingCtl : Control
    {
        private bool _transparentBG = true;
        private int _alpha = 125;
        private string _msg = "正在加载中...";

        private SolidBrush fontBrush = new SolidBrush(Color.FromArgb(206, 94, 94, 94));

        private Container components = new Container();
        private PictureBox pic;
        private Label label;


        private int _height_total = 0;
        private int _width_total = 0;

        public MyLoadingCtl() : this(125, true)
        {
        }

        public MyLoadingCtl(int alpha, bool showLoadingImage)
        {
            SetStyle(ControlStyles.Opaque, true);
            CreateControl();
            _alpha = alpha;
            if (showLoadingImage)
            {
                pic = new PictureBox();
                pic.BackColor = Color.White;
                pic.Image = Properties.Resources.loading;
                pic.Name = "picturebox_loading";
                pic.Size = new Size(32, 32);
                pic.SizeMode = PictureBoxSizeMode.Zoom;
                Point location = new Point(Location.X + (Width - pic.Width) / 2,
                    Location.Y + (Height - pic.Height) / 2);
                pic.Location = location;
                pic.Anchor = AnchorStyles.None;
                Controls.Add(pic);
                Invalidate();
            }
        }


        public void ShowLoading(Form form)
        {
            try
            {
                CreateControl();
                form.Controls.Add(this);
                Dock = DockStyle.Fill;
                BringToFront();
                Enabled = true;
                Visible = true;
                Refresh();
                Invalidate();
            }
            catch
            {

            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!(components == null))
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            float vlblControlWidth;
            float vlblControlHeight;

            Pen labelBorderPen;
            SolidBrush labelBackColorBrush;

            if (_transparentBG)
            {
                Color drawColor = Color.FromArgb(_alpha, BackColor);
                labelBorderPen = new Pen(drawColor, 0);
                labelBackColorBrush = new SolidBrush(drawColor);
            }
            else
            {
                labelBorderPen = new Pen(BackColor, 0);
                labelBackColorBrush = new SolidBrush(BackColor);
            }
            base.OnPaint(e);

            vlblControlWidth = Size.Width;
            vlblControlHeight = Size.Height;
            e.Graphics.DrawRectangle(labelBorderPen, 0, 0, vlblControlWidth, vlblControlHeight);
            e.Graphics.FillRectangle(labelBackColorBrush, 0, 0, vlblControlWidth, vlblControlHeight);
            e.Graphics.DrawString(_msg, new Font("黑体", 10), fontBrush, vlblControlWidth / 2 - 30, vlblControlHeight / 2 + 40);
        }


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x0000020;
                return cp;
            }
        }

        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            pic.Invalidate();
            base.OnInvalidated(e);
        }


        public bool TransparentBG
        {
            get { return _transparentBG; }
            set { _transparentBG = value; Invalidate(); }
        }

        public int Alpha
        {
            get { return _alpha; }
            set
            {
                _alpha = value;
                Invalidate();
            }
        }


        public string Text
        {
            get { return _msg; }
            set { _msg = value; Invalidate(); }
        }

    }
}
