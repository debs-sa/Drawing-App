using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingExample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
        private void MainForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen p = new Pen(Color.Red, 26);
            g.DrawLine(p, 100, 100, 45, 250);

            Pen outline;
            Graphics graphics_context;
            SolidBrush fill_color;

            graphics_context = this.CreateGraphics();
            outline = new Pen(Color.Green, 5);
            fill_color = new SolidBrush(Color.Blue);

            Point[] points = new Point[5];
            points[0] = new Point(150, 120);
            points[1] = new Point(120, 180);
            points[2] = new Point(190, 180);
            points[3] = new Point(200, 241);
            points[4] = new Point(214, 180);

            graphics_context.DrawClosedCurve(outline, points); //closed curve
            graphics_context.DrawEllipse(outline, 300, 10, 50, 50);

            Rectangle rect = new Rectangle(450, 50, 100, 100);
            graphics_context.DrawArc(outline, rect, 90, 150);

            Point[] points_curve = new Point[5];
            points_curve[0] = new Point(250, 220);
            points_curve[1] = new Point(220, 280);
            points_curve[2] = new Point(290, 280);
            points_curve[3] = new Point(300, 341);
            points_curve[4] = new Point(340, 280);
            graphics_context.DrawCurve(outline, points_curve); //just curve, not closed

            PictureBox picture_Box = new PictureBox();
            picture_Box.Location = new Point(550, 100);
            picture_Box.Size = new Size(200, 250);
            picture_Box.BorderStyle = BorderStyle.FixedSingle;
            picture_Box.SizeMode = PictureBoxSizeMode.StretchImage;
            picture_Box.Image = Image.FromFile(@"C:\Users\debor\OneDrive\Pictures\monalisa.jpg");
            this.Controls.Add(picture_Box);

            Font font = new Font("Verdana", 20);
            Point location = new Point(400, 200);
            StringFormat draw_format = new StringFormat();
            draw_format.FormatFlags = StringFormatFlags.DirectionVertical;
            graphics_context.DrawString("Hello & Welcome", font, fill_color, location, draw_format);
        }  
    }
}
