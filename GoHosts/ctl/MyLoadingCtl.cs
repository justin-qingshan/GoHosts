using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GoHosts.ctl
{

    public class MyLoadingCtl : Control
    {
        private bool _transparentBG = true;
        private int _alpha = 125;
        private string label = "正在加载中...";

        private SolidBrush fontBrush = new SolidBrush(Color.FromArgb(206, 94, 94, 94));

        private Container components = new Container();

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
                PictureBox pictureBox = new PictureBox();
                pictureBox.BackColor = Color.White;
                pictureBox.Image = Properties.Resources.loading;
                pictureBox.Name = "picturebox_loading";
                pictureBox.Size = new Size(4, 4);
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                Point location = new Point(Location.X + (Width - pictureBox.Width) / 2,
                    Location.Y + (Height - pictureBox.Height) / 2);
                pictureBox.Location = location;
                pictureBox.Anchor = AnchorStyles.None;
                Controls.Add(pictureBox);
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
            e.Graphics.DrawString(label, new Font("黑体", 10), fontBrush, vlblControlWidth / 2 - 30, vlblControlHeight / 2 + 40);
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

    }
}
