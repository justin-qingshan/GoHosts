using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace GoHosts.ctl
{
    public class Loading : Control
    {
        private int _alpha = 162;
        private string _loading_msg = "...";
        private int _pic_size = 32;

        private Container components = new Container();
        private PictureBox pic;
        private Label label;

        private bool bg_painted = false;


        public Loading()
        {
            SetStyle(ControlStyles.Opaque, true);
            CreateControl();
            DrawPicAndLabel();
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
                bg_painted = false;
                Refresh();
                Invalidate();
            }
            catch { }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (!bg_painted)
            {
                Color color = Color.FromArgb(_alpha, BackColor);
                Pen border = new Pen(color, 0);
                SolidBrush bruch = new SolidBrush(color);

                //e.Graphics.Clear(BackColor);
                e.Graphics.DrawRectangle(border, 0, 0, Size.Width, Size.Height);
                e.Graphics.FillRectangle(bruch, 0, 0, Size.Width, Size.Height);
                bg_painted = true;
            }
           
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




        private void DrawPicAndLabel()
        {
            pic = new PictureBox();
            pic.BackColor = Color.White;
            pic.Image = Properties.Resources.loading;
            pic.Name = "loading_pic";
            pic.Size = new Size(_pic_size, _pic_size);
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Anchor = AnchorStyles.None;
            Controls.Add(pic);

            label = new Label();
            label.Name = "loading_pic";
            label.Text = _loading_msg;
            label.Anchor = AnchorStyles.None;
            //label.Font = new Font(FontFamily.GenericSansSerif, 10);
            label.AutoSize = true;
            Controls.Add(label);

            int height = CalcTotalHeight();
            label.Location = new Point(Location.X + (Width - label.Width) / 2,
                Location.Y + (Height - height / 2) + (height - label.Height));
            pic.Location = new Point(Location.X + (Width - pic.Width) / 2,
                Location.Y + (Height - height / 2));

            Invalidate();
        }


        protected override void OnInvalidated(InvalidateEventArgs e)
        {
            pic.Invalidate();
            label.Invalidate();
            int height = CalcTotalHeight();
            label.Location = new Point(Location.X + (Width - label.Width) / 2,
                Location.Y + (Height - height) / 2 + (height - label.Height));
            pic.Location = new Point(Location.X + (Width - pic.Width) / 2,
                Location.Y + (Height - height) / 2);
            base.OnInvalidated(e);
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


        private int CalcTotalWidth()
        {
            int picWidth = pic == null ? 0 : pic.Width;
            int labelWidth = label == null ? 0 : label.Width;

            return picWidth > labelWidth ? picWidth : labelWidth;
        }

        private int CalcTotalHeight()
        {
            int picHeight = pic == null ? 0 : pic.Height;
            int labelHeight = pic == null ? 0 : label.Height;

            return (picHeight == 0 || labelHeight == 0) ?
                picHeight + labelHeight : picHeight + 8 + labelHeight;
        }


        public int Alpha
        {
            get { return _alpha; }
            set { _alpha = value; Invalidate(); }
        }

        public string LoadingMsg
        {
            get { return _loading_msg; }
            set { _loading_msg = value; label.Text = _loading_msg; Invalidate(); }
        }
    }
}
