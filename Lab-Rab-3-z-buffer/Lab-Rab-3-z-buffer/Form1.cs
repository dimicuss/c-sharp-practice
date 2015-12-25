using System;
using System.Drawing;
using System.Windows.Forms;


namespace Lab_Rab_3_z_buffer
{
    public partial class Form : System.Windows.Forms.Form
    {
        Graphics graph;
        Color[,] frameBuffer;
        Color AColor = Color.Red;
        Color BColor = Color.Green;
        
        int i = -1, j = 0;

        public Form()
        {
            InitializeComponent();
        }

        private void drawButton_Click(object sender, EventArgs e)
        {
            graph = image.CreateGraphics();
            frameBuffer = new Color[40, 40];

            var zBuffer = new float[40, 40];


            var flatA = new Flat(AColor, new Dot(aM11, aM12, aM13), new Dot(aM21, aM22, aM23), new Dot(aM31, aM32, aM33));
            var flatB = new Flat(BColor, new Dot(bM11, bM12, bM13), new Dot(bM21, bM22, bM23), new Dot(bM31, bM32, bM33));


            for (int j = 0; j < 40; j++)
                for (int i = 0; i < 40; i++)
                {
                    zBuffer[i, j] = 0;
                    frameBuffer[i, j] = Color.FromArgb(64, 64, 64);
                }


            for (int j = 0; j < 400; j += 10)
                for (int i = 0; i < 400; i += 10)
                {
                    var aZ = flatA.equality(i / 10, j / 10);
                    var bZ = flatB.equality(i / 10, j / 10);

                    if (aZ > zBuffer[i / 10, j / 10])
                    {
                        zBuffer[i / 10, j / 10] = aZ;
                        frameBuffer[i / 10, j / 10] = flatA.color;
                    }

                    if (bZ > zBuffer[i / 10, j / 10])
                    {
                        zBuffer[i / 10, j / 10] = bZ;
                        frameBuffer[i / 10, j / 10] = flatB.color;
                    }
                }

            timer.Enabled = true;
            timer.Start();
        }

        private void pickColor1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            AColor = colorDialog1.Color;
        }

        private void pickColor2_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            BColor = colorDialog1.Color;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            
            if (i < 39) i++;
            else { i = 0; j++; }

            graph.DrawRectangle(new Pen(Color.Wheat), i * 10, j * 10, 10, 10);
            graph.FillRectangle(new SolidBrush(frameBuffer[i, j]), i * 10 + 1, j * 10 + 1, 9, 9);

            if (j == 39) { timer.Stop(); timer.Enabled = false; }
        }
    }


    public class Dot
    {
        public int X;
        public int Y;
        public int Z;

        public Dot(TextBox x, TextBox y, TextBox z)
        {
            X = Convert.ToInt16(x.Text);
            Y = Convert.ToInt16(y.Text);
            Z = Convert.ToInt16(z.Text);
        }
    }

    public class Flat
    {
        public Color color;
        public delegate float eq(int x, int y);
        public eq equality;

        private float det(int a, int b, int c, int d)
        {
            return a * d - b * c;
        }

        public Flat(Color clr, Dot m1, Dot m2, Dot m3)
        {
            color = clr;

            equality = delegate (int x, int y)
            {
                var expr = -((x - m1.X) * det(m2.Y - m1.Y, m3.Y - m1.Y,
                                         m2.Z - m1.Z, m3.Z - m1.Z)
                        -
                        (y - m1.Y) * det(m2.X - m1.X, m3.X - m1.X,
                                         m2.Z - m1.Z, m3.Z - m1.Z))
                        /
                        det(m2.X - m1.X, m3.X - m1.X,
                        m2.Y - m1.Y, m3.Y - m1.Y)
                        +
                        m1.Z;

                if (double.IsInfinity(expr))
                    return 0;
                    
                if (double.IsNaN(expr))
                    return float.PositiveInfinity;

                return expr;
            }; 
        }
    }
}
