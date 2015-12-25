using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace Lab_Rab_3_Intersection
{
    public partial class Form1 : Form
    {
        private Graphics graph;
        private Pen pen;
        private Line line;
        private Rect rect;
        private int X, Y;
        private bool UpDown, RectOrLine;

        int[] left = new int[] { 9, 5, 1 };
        int[] right = new int[] { 10, 6, 2 };
        int top = 8;
        int bottom = 4;


        public Form1()
        {
            InitializeComponent();
        }

        public int Sect ()
        {
            if (line.codeP1 == 0)
            {
                line.ChangePoints();
            }

            if ((line.codeP1 == 0) && (line.codeP2 == 0))
            {
                graph.Clear(Color.White);

                rect.DrawRect(graph);
                line.DrawLine(graph);

                return 0;
            }
            else if ((line.codeP1 == line.codeP2) || line.IsParallel())
            {
                graph.Clear(Color.White);

                rect.DrawRect(graph);
                return 0;

            }
            else if (bottom == line.codeP1)
            {
                var eq = new Equation(rect.bottom, line);

                line.P1 = eq.GetResult();
                line.codeP1 = line.GetCode(line.P1);
                line.ChangePoints();

                return Sect();
            }
            else if (right.Contains(line.codeP1))
            {
                var eq = new Equation(rect.right, line);

                line.P1 = eq.GetResult();
                line.codeP1 = line.GetCode(line.P1);
                line.ChangePoints();

                return Sect();
            }
            else if (top == line.codeP1)
            {
                var eq = new Equation(rect.top, line);

                line.P1 = eq.GetResult();
                line.codeP1 = line.GetCode(line.P1);
                line.ChangePoints();

                return Sect();
            }
            else if (left.Contains(line.codeP1))
            {
                var eq = new Equation(rect.left, line);

                line.P1 = eq.GetResult();
                line.codeP1 = line.GetCode(line.P1);
                line.ChangePoints();

                return Sect();
            }

            return 0;
        }

 
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            graph = this.CreateGraphics();
            pen = new Pen(Color.Red);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (UpDown)
            {
                if (RectOrLine)
                {
                    graph.Clear(Color.White);

                    rect.DrawRect(graph);
                    graph.DrawLine(pen, X, Y, e.X, e.Y);
                }
                else
                {
                    graph.Clear(Color.White);

                    graph.DrawLine(pen, X, Y, X, e.Y);
                    graph.DrawLine(pen, X, Y, e.X, Y);
                    graph.DrawLine(pen, e.X, Y, e.X, e.Y);
                    graph.DrawLine(pen, X, e.Y, e.X, e.Y);
                }
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            UpDown = false;

            if (RectOrLine)
            {
                line = new Line(new Point(X, Y), new Point(e.X, e.Y), rect);
                RectOrLine = false;

                graph.Clear(Color.White);
                Sect();
            }

            else
            {  
                rect = new Rect(new Point(X, Y), new Point(e.X, e.Y));
                rect.DrawRect(graph);
                RectOrLine = true;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            X = e.X;
            Y = e.Y;
            UpDown = true;
        }
    }


    public class Equation // Класс уравнения пересечения двух прямых, которое возвращает точку пересечения.
    { 
        private Point P1, P2, P3, P4;
        private int A1, B1, C1, A2, B2, C2;
    
        public Equation(Line l1, Line l2)
        {
            P1 = l1.P1;
            P2 = l1.P2;

            P3 = l2.P1;
            P4 = l2.P2;
         }  

        public Point GetResult()
        {
            A1 = P2.Y - P1.Y;
            B1 = -(P2.X - P1.X);
            C1 = -(P1.X * A1 + P1.Y * B1);

            A2 = P4.Y - P3.Y;
            B2 = -(P4.X - P3.X);
            C2 = -(P3.X * A2 + P3.Y * B2);

            return new Point(-(B2 * C1 - B1 * C2) / (A1 * B2 - A2 * B1),
                             -(A1 * C2 - A2 * C1) / (A1 * B2 - A2 * B1));
        }
    }


    public class Rect // Класс для прямоугольника.
    {
        public int X1, Y1, X2, Y2;
        public Line left, right, top, bottom;

        public Rect(Point pt1, Point pt2)
        {

            if (pt1.X < pt2.X)
            {
                if (pt1.Y < pt2.Y)
                {
                    X1 = pt1.X;  
                    Y1 = pt1.Y;
                    X2 = pt2.X;  
                    Y2 = pt2.Y;
                }
                else
                {
                    X1 = pt1.X;
                    Y1 = pt2.Y;
                    X2 = pt2.X;
                    Y2 = pt1.Y;
                }
            }
            else
            {
                if (pt1.Y > pt2.Y)
                {
                    X1 = pt2.X;
                    Y1 = pt2.Y;
                    X2 = pt1.X;
                    Y2 = pt1.Y;
                }
                else
                {
                    X1 = pt2.X;
                    Y1 = pt1.Y;
                    X2 = pt1.X;
                    Y2 = pt2.Y;
                }
            }


            //Ребра окна.

            top = new Line(new Point(X1, Y1), new Point(X2, Y1));
            bottom = new Line(new Point(X1, Y2), new Point(X2, Y2));
            right = new Line(new Point(X2, Y1), new Point(X2, Y2));
            left = new Line(new Point(X1, Y1), new Point(X1, Y2));
        }

        public void DrawRect(Graphics gr)
        {
            gr.DrawRectangle(new Pen(Color.Red), X1, Y1, X2 - X1,  Y2 - Y1);
        }   
    }

    public class Line //Класс для линии с методом определения положения прямой относительно окна
    {
        public Point P1, P2;
        public int codeP1, codeP2;
        private Rect rect;
     
        public Line(Point p1, Point p2, Rect rect_) {
            P1 = p1;
            P2 = p2;
            rect = rect_;

            codeP1 = GetCode(P1);
            codeP2 = GetCode(P2);
        }


        public Line(Point p1, Point p2)
        {
            P1 = p1;
            P2 = p2;
        }

        public int GetCode(Point pt)
        {
            var code = 0;

            if (pt.X < rect.X1) code += 1;
            if (pt.Y < rect.Y1) code += 8;
            if (pt.X > rect.X2) code += 2;
            if (pt.Y > rect.Y2) code += 4;

            return code;
        }

        public void ChangePoints()
        {
            var buffer = P1;
            var codeBuffer = codeP1;
            P1 = P2;
            P2 = buffer;

            codeP1 = codeP2;
            codeP2 = codeBuffer;
        }

        public void DrawLine(Graphics gr)
        {
            gr.DrawLine(new Pen(Color.Black), P1, P2);
        }

        public bool IsParallel ()
        {
            
            return ((P1.X < rect.X1 || P1.X > rect.X2)
                    &&
                   (P1.Y < rect.Y1 || P1.Y > rect.Y2))
                   &&
                   ((P1.X < rect.X1 || P1.X > rect.X2)
                    &&
                   (P1.Y < rect.Y1 || P1.Y > rect.Y2))
                   &&
                   (P1.X == P2.X || P1.Y == P2.Y);
         }
    }
}
