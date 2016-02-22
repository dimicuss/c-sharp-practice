using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace Magnetic
{ 
    public partial class Magnetic : Form
    {
        Graphics graph;
        Field field ;
        List<Point> defectPoints;


        public Magnetic()
        {
            InitializeComponent();
            graph = Graphics.FromHwnd(drawField.Handle);
            field = new Field(graph, drawField);
            defectPoints = new List<Point>();
        }


        private void Space_TextChanged(object sender, EventArgs e)
        {
            int pointSpace;
            int.TryParse(Space.Text, out pointSpace);
            
            if (pointSpace != 0 && 400 % pointSpace != 0)
            {
                MessageBox.Show("Расстояние между активными точками должно быть кратным 400.");
                return;
            }

            if (pointSpace != 0)
            {
                field.drawMarking(graph, pointSpace);
            }
            else graph.Clear(Color.White);
        }


        private void drawField_MouseDown(object sender, MouseEventArgs e)
        {
            defectPoints.Add(new Point(e.X, e.Y));

            if (defectPoints.Count == 2)
            {
                var pointSpace = int.Parse(Space.Text);

                if (defectPoints[0].X == defectPoints[1].X)
                {
                    MessageBox.Show("Неправильно выбраны координаты: X одной точки не должен равняться X другой.");
                }
                else if (defectPoints[0].Y % pointSpace == 0 || defectPoints[1].Y % pointSpace == 0)
                {
                    MessageBox.Show("Неправильно выбраны координаты: Одна из точек находится на одной прямой с активной точкой.");
                }
                else if (defectPoints[0].X > defectPoints[1].X)
                {
                    MessageBox.Show("Неправильно выбраны координаты: Точки дефектов пересекаются по вертикали.");
                }
                else
                {
                    field.drawWithDefects(defectPoints[0], defectPoints[1], pointSpace);
                    defectPoints.Clear();
                }
            }
        }

        private void clearField_Click(object sender, EventArgs e)
        {
            int pointSpace;
            int.TryParse(Space.Text, out pointSpace);

            if (pointSpace != 0)
            {
                field.drawMarking(graph, pointSpace);
            }
            else graph.Clear(Color.White);
        }
    }



    public partial class AkimaSpline
    {
        private alglib.spline1dinterpolant c;
        private Graphics Graph;
        private PictureBox DrawField;
        private List<Point> Lst;


        public AkimaSpline (List<Point> lst, Graphics graph, PictureBox drawField)
        {
            Lst = lst;
            Graph = graph;
            DrawField = drawField;
        }


        public int returnY(int xi)
        {
            return (int) alglib.spline1dcalc(c, xi);
        }


        private Point translateRotate(double oX, double oY, Point elm, int angle)
        {
            var X = elm.X + oX;
            var Y = elm.Y + oY;

            return new Point((int) (X * Math.Cos(angle * Math.PI/180) - Y * Math.Sin(angle * Math.PI/180)),
                             (int) (X * Math.Sin(angle * Math.PI/180) + Y * Math.Cos(angle * Math.PI/180)));
        }


        private Point translateRotate(int angle, double oX, double oY, Point elm)
        {
            return new Point((int) (elm.X * Math.Cos(angle * Math.PI/180) - elm.Y * Math.Sin(angle * Math.PI/180) + oX),
                             (int) (elm.X * Math.Sin(angle * Math.PI/180) + elm.Y * Math.Cos(angle * Math.PI/180) + oY));
        }


        public void drawParabolicSpline()
        {
            var oX = Lst[1].X;
            var oY = Lst[1].Y;
            var trnlLst = Lst.Select(elm => translateRotate(-oX, -oY, elm, 90)).ToList();
            List<Point> list = new List<Point>();
            var pen = new Pen(Color.Black);

            alglib.spline1dbuildakima(trnlLst.Select(elm => (double) elm.X).ToArray(), 
                                      trnlLst.Select(elm => (double) elm.Y).ToArray(), 
                                      out c);

            for (int i = trnlLst[0].X; i <= trnlLst[trnlLst.Count - 1].X; i++)
                list.Add(new Point(i, returnY(i)));

            var splined = list.Select(elm => translateRotate(-90, oX, oY, elm)).ToList();

            for (int i = 0; i < splined.Count - 1; i++)
                Graph.DrawLine(pen, splined[i].X - 1, splined[i].Y - 1, splined[i + 1].X - 1, splined[i + 1].Y - 1);            
        }


        public void drawSpline()
        {
            var list = new List<Point>();
            var pen = new Pen(Color.Black);

            alglib.spline1dbuildcubic(Lst.Select(elm => (double)elm.X).ToArray(),
                                      Lst.Select(elm => (double)elm.Y).ToArray(),
                                      out c);

            for (int i = Lst[0].X; i < Lst[Lst.Count - 1].X; i++)
            {
                list.Add(new Point( i, returnY(i)));
            }
            for (int i = 0; i < list.Count - 1; i++)
                Graph.DrawLine(pen, list[i].X - 1, list[i].Y - 1, list[i + 1].X - 1, list[i + 1].Y - 1);
        }
    }




    public class Field
    {
        Graphics Graph;
        PictureBox DrawField;

        List<Point> lstLeft = new List<Point>();
        List<Point> lstRight = new List<Point>();


        public Field(Graphics graph, PictureBox drawField) {
            Graph = graph;
            DrawField = drawField;
        }


        public void drawWithDefects(Point pointLeft, Point pointRight, int pointSpace)
        {
            Graph.Clear(Color.White);
            drawMarking(Graph, pointSpace);

            var defLeft = new List<Point>();
            var defRight = new List<Point>();
            var lines = new List<List<Point>>();
            int indUp; 
            int indDown;

            for (int i = 0; i <= DrawField.Height; i += pointSpace)
            {
                lstLeft.Add(new Point(0, i));
                lstRight.Add(new Point(DrawField.Width, i));
            }


            indUp = (int) Math.Ceiling( (double)pointLeft.Y / pointSpace ) * pointSpace;
            indDown = (int) Math.Floor( (double)pointLeft.Y / pointSpace ) * pointSpace;

            defLeft.Add(new Point(0, indUp));
            defLeft.Add(pointLeft);
            defLeft.Add(new Point(0, indDown));


            indUp = (int)Math.Ceiling( (double)pointRight.Y / pointSpace ) * pointSpace;
            indDown = (int)Math.Floor( (double)pointRight.Y / pointSpace ) * pointSpace;

            defRight.Add(new Point(DrawField.Width, indUp));
            defRight.Add(pointRight);
            defRight.Add(new Point(DrawField.Width, indDown));


            var exptLeft = lstLeft.Except(defLeft).ToList();
            var exptRight = lstRight.Except(defRight).ToList();


            for (int i = 0; i < exptLeft.Count; i++)

                if (!exptLeft[i].Equals(exptRight[i]))
                {
                    var newPath = new List<Point> { exptLeft[i],
                                                    new Point(pointLeft.X, exptLeft[i].Y),
                                                    new Point(pointRight.X, exptRight[i].Y),
                                                    exptRight[i] };

                    lines.Add(newPath);
                }
                else lines.Add(new List<Point> { exptLeft[i], exptRight[i] });
            

            for (int i = 0; i < lines.Count; i++)
                new AkimaSpline(lines[i], Graph, DrawField).drawSpline();
            
            new AkimaSpline(defLeft, Graph, DrawField).drawParabolicSpline();
            new AkimaSpline(defRight, Graph, DrawField).drawParabolicSpline();
        }

        public void drawMarking(Graphics graph, int pointSpace)
        {
            graph.Clear(Color.White);

            var pen = new Pen(Color.Gray);


            for (int i = -1; i <= DrawField.Height; i += pointSpace)
            {
                graph.FillEllipse(pen.Brush, 0 - 4, i - 4, 8, 8);
                graph.FillEllipse(pen.Brush, DrawField.Width - 7, i - 4, 8, 8);
                graph.DrawLine(pen, 0, i, DrawField.Width, i);
                graph.DrawLine(pen, i, 0, i, DrawField.Height);
            }

        }
    }
}
