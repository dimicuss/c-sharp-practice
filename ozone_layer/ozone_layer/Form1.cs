using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ozone_layer
{
    public partial class Form : System.Windows.Forms.Form
    {

        public Form()
        {
            InitializeComponent();
        }

        private void count_Click(object sender, EventArgs e)
        {
            var calc = new Calculatings(lambdaTextBox,
                                        gammaTextBox,
                                        xTextBox,
                                        aLambdaTextBox,
                                        betaTextBox,
                                        sigmaTextBox,
                                        sLamdaTextBox,
                                        dLambdaTextBox);

            wolam.Text = string.Format("{0:0.0000E00}", calc.wOLambda());
            wlam.Text = string.Format("{0:0.0000E00}", calc.wLambda());
            weffect.Text = string.Format("{0:0.0000E00}", calc.wEffect());
            tperm.Text = string.Format("{0:0.0000E00}", calc.tPermission());
        }
    }

    public class Calculatings
    {
        private double Lambda, SecY, 
                       Beta, Sigma, 
                       X, ALambda, 
                       SLambda, 
                       DLambda;

        public Calculatings(params TextBox[] vals)
        {
            var valsCnvrt = new double[8];

            for (var i = 0; i < valsCnvrt.Length; i++)
            {
                valsCnvrt[i] = Convert.ToDouble(vals[i].Text);
            }

            Lambda = valsCnvrt[0];
            SecY = 1 / Math.Cos(valsCnvrt[1] * Math.PI / 180);
            X = valsCnvrt[2];
            ALambda = valsCnvrt[3];
            Beta = valsCnvrt[4];
            Sigma = valsCnvrt[5];
            SLambda = valsCnvrt[6];
            DLambda = valsCnvrt[7];
        }



        public double wOLambda()
        {
            return 80909 / Math.Pow(Lambda, 5) * Math.Pow(10, 10) * Math.Exp(-2402 / Lambda);
        }

        public double wLambda()
        {
            return wOLambda() * Math.Exp(-ALambda * SecY * X - Beta * SecY - Sigma * SecY);
        }

        public double wEffect()
        {
            return wLambda() * SLambda * DLambda;
        }
            
        public double tPermission()
        {
            return 3 / wEffect();
        }

        public void returnResult()
        {
            MessageBox.Show(wEffect().ToString());
        }
    }
}
