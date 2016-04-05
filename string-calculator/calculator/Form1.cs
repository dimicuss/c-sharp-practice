using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace calculator
{
    public class counter
    {
        private string orgnStr;


        public counter(string str) //Конструктор
        {
            orgnStr = str;
        }


        private string removeSpace(string str, int i = 0) //Удалить пробелы из строки
        {
            if (i == str.Length) return "";
            if (str[i] == ' ') return removeSpace(str, i + 1);
            else return str[i] + removeSpace(str, i + 1);
        }

         
        private string callBack(Match m, string pattern) //callBack умножения\диления\сложения\вычитания
        {
            int i = Regex.Match(m.Value, @"(?<=-?\d+,?\d*)[" + pattern + "]").Index;
      
            string leftOp = m.Value.Substring(0, i);
            string rightOp = m.Value.Substring(i + 1, m.Value.Length - i - 1);

            switch (m.Value[i])
            {
                case '*':
                    return (Convert.ToSingle(leftOp) * Convert.ToSingle(rightOp)).ToString();
                case '/':
                    return (Convert.ToSingle(leftOp) / Convert.ToSingle(rightOp)).ToString();
                case '+':
                    return (Convert.ToSingle(leftOp) + Convert.ToSingle(rightOp)).ToString();
                case '-':
                    return (Convert.ToSingle(leftOp) - Convert.ToSingle(rightOp)).ToString();
                default:
                    return "";

            }
        }


        private string eval(string str, string pattern)
        {
            if (!Regex.IsMatch(str, @"(?<=-?\d+,?\d*)[" + pattern + "]"))
                return str;

            Regex rgx = new Regex(@"-?\d+,?\d*[" + pattern + @"]-?\d+,?\d*");

            return eval(rgx.Replace(str, m => callBack(m, pattern)), pattern);
        }


        private string evalBrackets(string str)
        {
            Regex rgx = new Regex(@"\([^()]+\)");
            if (!rgx.IsMatch(str))
                return str;

            string match = rgx.Match(str).Value.Substring(1, rgx.Match(str).Length - 2);
                       
            return evalBrackets(rgx.Replace(str, eval(eval(match, "*/"), "+-"), 1));
        }


        public string returnResult() //Возвратить результат в виде MessageBox
        {
            return eval(eval(evalBrackets(removeSpace(orgnStr)), "*/"), "+-");
        }

    }




    public partial class display : Form
    {
        public display()
        {
            InitializeComponent();
        }


        private void count_Click(object sender, EventArgs e)
        {
            counter count = new counter(field.Text);
            MessageBox.Show(count.returnResult());
        }
    }
}
