using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lab_Rab_2_Flat_fill
{
    public partial class form : Form
    {
        public form()
        {
            InitializeComponent();
        }

        private float grad;
       
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            float grad = Math.Abs((float)Math.Cos(Convert.ToSingle(trackBar.Value) * Math.PI / 180));

            pictureBox.BackColor = Color.FromArgb((int)Math.Round(173 * grad), (int)Math.Round(255 * grad), (int)Math.Round(47 * grad));
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            float grad = Math.Abs((float)Math.Cos(random.Next(0, 360) * Math.PI / 180));

            pictureBox.BackColor = Color.FromArgb((int)Math.Round(173 * grad), (int)Math.Round(255 * grad), (int)Math.Round(47 * grad));
        }
    }
}
