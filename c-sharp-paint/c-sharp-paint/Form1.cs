using System.Drawing;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;



namespace c_sharp_paint
{
    public partial class form : Form
    {
        private Paint paint;
        private bool polygon;
        List<Point> list = new List<Point>();

        public form()
        {
            InitializeComponent();
            paint = new Paint(display.Handle);
        }


        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            paint.isMouseDown = false;
        }



        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            paint.isMouseDown = true;

            if (list.Count != 0
                 &&
                 (list.First().X - 10 <= e.X && list.First().X + 10 >= e.X)
                 &&
                 (list.First().Y - 10 <= e.Y && list.First().Y + 10 >= e.Y))
            {
                for (var i = 0; i < list.LongCount() - 1; i++)
                {
                    paint.graphics.DrawLine(new Pen(Color.Violet), list[i], list[i + 1]);
                }

                paint.graphics.DrawLine(new Pen(Color.Violet), list.Last(), list.First());
                list.Clear();
                polygon = false;
            }

            else
            {
                if (polygon)
                    list.Add(new Point(e.X, e.Y));
            }
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (polygon && list.Count > 1)
            { 

                for (var i = 0; i < list.LongCount(); i++)
                {
                    if (i < list.LongCount() - 1)
                        paint.graphics.DrawLine(new Pen(Color.Violet), list[i], list[i + 1]);
                }

                paint.graphics.DrawLine(new Pen(Color.Violet), list.Last(), list[(int)list.LongCount() - 1]);
            }
            else
            {
                var thick = Convert.ToInt32(thickness.Text);
 
                paint.drawFigure(figures.Text, new Point(e.X, e.Y), thick);
            }
        }


        private void pickColor_Click(object sender, System.EventArgs e)
        {
            colorDia.ShowDialog();
            paint.pickedColor = colorDia.Color;
        }


        private void pickEraiser_Click(object sender, EventArgs e)
        {
            paint.pickedColor = Color.White;
        }


        private void form_Resize(object sender, EventArgs e)
        {
            display.Size = new Size(this.Width - 300, this.Height - 100);
            paint = paint = new Paint(display.Handle);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            polygon = true;
            
        }
    }

    public class Paint
    {
        public Graphics graphics;
        public Color pickedColor = Color.Aqua;
        public bool isMouseDown;
        

        public Paint(IntPtr handle)
        {
            graphics = Graphics.FromHwnd(handle);
        }

        public void drawFigure(string figure, Point point, int thick)
        {
            if (isMouseDown)
                switch (figure)
                {
                    case "circle":
                        graphics.FillEllipse(new SolidBrush(pickedColor), point.X - thick / 2, point.Y - thick / 2, thick, thick);
                        break;
                    case "rectangle":
                        graphics.FillRectangle(new SolidBrush(pickedColor), point.X - thick / 2, point.Y - thick / 2, thick, thick);
                        break;
                }
        }
    }
}
