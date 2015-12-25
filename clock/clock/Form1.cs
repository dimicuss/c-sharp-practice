using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace clock
{
    public partial class Form1 : Form
    {
        private Graphics drawing;
        private Pen penSec = new Pen(Color.Red);
        private Pen penMin = new Pen(Color.Yellow);
        private Pen penHur = new Pen(Color.Fuchsia);
        private float seci, secj, mini, minj, huri, hurj;

       
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            drawing = CreateGraphics();
            DateTime now = DateTime.Now;
            seci = secj = now.Second * 6 - 90;
            mini = minj = now.Minute * 6 - 90 + now.Second * 6 / 60;
            huri = hurj = now.Hour * 30 - 90 + now.Minute * 6 / 60;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            drawing.Clear(Color.White);
            drawing.DrawEllipse(new Pen(Color.Black), Width / 2 - 100, Height / 2 - 100, 200, 200);
            drawing.DrawLine(penSec,
                Width / 2,
                Height / 2,
                (float)(100 * Math.Cos(Math.PI * (seci += 6) / 180) + Width / 2),
                (float)(100 * Math.Sin(Math.PI * (secj += 6) / 180) + Height / 2));

            drawing.DrawLine(penMin,
                Width / 2,
                Height / 2,
                (float)(75 * Math.Cos(Math.PI * (mini += 6 / (float)60) / 180) + Width / 2),
                (float)(75 * Math.Sin(Math.PI * (minj += 6 / (float)60) / 180) + Height / 2));

            
            drawing.DrawLine(penHur,
                Width / 2,
                Height / 2,
                (float)(50 * Math.Cos(Math.PI * (huri += 6 / (float)3600) / 180) + Width / 2),
                (float)(50 * Math.Sin(Math.PI * (hurj += 6 / (float)3600) / 180) + Height / 2));
        }
    }
}
