using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        Polygon plgn = new Polygon();
        Graphics graph;
        Pen pen = new Pen(Color.Black);
        Rect rect;
        int X, Y;
        bool IsMouseDown;

        public Form1()
        {
            InitializeComponent();
            graph = this.CreateGraphics();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
            if (plgn.IsClosed)
            {
                rect = new Rect(new Point(X, Y), new Point(e.X, e.Y));
                graph.Clear(Color.White);
                rect.DrawRect(graph);
                Sect(plgn).DrawAllLines(graph);
            }
            else
            {
                plgn.Add(new Point(e.X, e.Y));
                plgn.DrawLastLine(graph);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (plgn.IsClosed && IsMouseDown)
            {
                graph.Clear(Color.White);

                plgn.DrawAllLines(graph);

                graph.DrawLine(pen, X, Y, X, e.Y);
                graph.DrawLine(pen, X, Y, e.X, Y);
                graph.DrawLine(pen, e.X, Y, e.X, e.Y);
                graph.DrawLine(pen, X, e.Y, e.X, e.Y);
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            IsMouseDown = true;

            if (plgn.IsClosed)
            {
                X = e.X;
                Y = e.Y;
            }
        }



        public Polygon Sect(Polygon plgn)
        {
            var sides = new Line[] { rect.left, rect.top, rect.right, rect.bottom };
            var points = plgn.points;
            var newPoints = new List<Point>();

            for (var i = 0; i < sides.Length; i++)
            {
                for (var j = 1; j <= points.Count; j++)
                {
                    Point End;
                    Point Start;

                    if (j == points.Count)
                    {
                        End = points[0];
                        Start = points[points.Count - 1];
                    }
                    else
                    {
                        End = points[j];
                        Start = points[j - 1];
                    }


                    var CodeEnd = rect.GetCode(End);
                    var CodeStart = rect.GetCode(Start);
                    var Code = sides[i].Code;

                    if (Code.Contains(CodeEnd) && Code.Contains(CodeStart))
                    {
                        continue;
                    }
                    else if (!Code.Contains(CodeEnd) && !Code.Contains(CodeStart))
                    {
                        newPoints.Add(End);
                    }
                    else if (!Code.Contains(CodeStart))
                    {
                        var newPoint = new Equation(sides[i], new Line(End, Start)).GetResult();
                        newPoints.Add(newPoint);
                    }
                    else
                    {
                        var newPoint = new Equation(sides[i], new Line(End, Start)).GetResult();
                        newPoints.Add(newPoint);
                        newPoints.Add(End);
                    }

                }
                points = newPoints;
                newPoints = new List<Point>();
            }
            return new Polygon(points);
        }



        public class Polygon //: points<Point>
        {
            public List<Point> points = new List<Point>();
            private bool isClosed;
            public bool IsClosed
            {
                get { return isClosed; }
                set { return; }
            }
            public int Length
            {
                get { return points.Count; }
                set { return; }
            }
            
            public Polygon(List<Point> list) { points = list; }
            public Polygon() { }

            public void Add (Point pt)
            {
                if (Length < 2) { points.Add(pt); return; }

                var line = new Line(points.Last(), pt);
                for (var i = 0; i < points.Count - 2; i++)
                {
                    var line2 = new Line(points[i + 1], points[i]);
                    var eq = new Equation(line2, line);

                    if (eq.IsInner() || eq.GetResult().IsEmpty) return;
                }

                points.Add(pt);
            }


            public void DrawLastLine(Graphics gr)
            {
                if ( Length < 2) return;
  
                if (( points.First().X - 20 <= points.Last().X && points.First().X + 20 >= points.Last().X ) &&
                    ( points.First().Y - 20 <= points.Last().Y && points.First().Y + 20 >= points.Last().Y ))
                {
                    gr.DrawLine( new Pen(Color.Red), points.Last(), points[Length - 2] );
                    gr.DrawLine( new Pen(Color.Red), points.Last(), points.First() );
                    isClosed = true;
                }

                else gr.DrawLine( new Pen(Color.Red), points.Last(), points[Length - 2] );
            }

            public void DrawAllLines(Graphics gr)
            {
                for(var i = 0; i < Length; i++)
                {
                    if (i < Length - 1)
                        gr.DrawLine(new Pen(Color.Red), points[i], points[i + 1]);

                    else gr.DrawLine(new Pen(Color.Red), points.Last(), points.First());
                }
            }
        }


        public class Equation // Класс уравнения пересечения двух прямых, которое возвращает точку пересечения.
        {
            private Point P1, P2, P3, P4, M;
            private int A1, B1, C1, A2, B2, C2;


            public Equation(Line l1, Line l2)
            {
                P1 = l1.P1;
                P2 = l1.P2;

                P3 = l2.P1;
                P4 = l2.P2;

                A1 = P2.Y - P1.Y;
                B1 = -(P2.X - P1.X);
                C1 = -(P1.X * A1 + P1.Y * B1);

                A2 = P4.Y - P3.Y;
                B2 = -(P4.X - P3.X);
                C2 = -(P3.X * A2 + P3.Y * B2);

                if ((A1 * B2 - A2 * B1) != 0)
                {
                    M = new Point(-(B2 * C1 - B1 * C2) / (A1 * B2 - A2 * B1),
                                  -(A1 * C2 - A2 * C1) / (A1 * B2 - A2 * B1));
                }
            }

            public Point GetResult()
            {
                return M;
            }

            public bool IsInner()
            {
                var a = new Point(P1.X - M.X, P1.Y - M.Y);
                var b = new Point(P2.X - M.X, P2.Y - M.Y);
                var abScal = a.Y * b.Y + a.X * b.X;

                var a2 = new Point(P3.X - M.X, P3.Y - M.Y);
                var b2 = new Point(P4.X - M.X, P4.Y - M.Y);
                var ab2Scal = a2.Y * b2.Y + a2.X * b2.X;

                return abScal <= 0 && ab2Scal <= 0;
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
                top.Code = new int[] {9, 8, 10};

                bottom = new Line(new Point(X1, Y2), new Point(X2, Y2));
                bottom.Code = new int[] {5, 4, 6};

                right = new Line(new Point(X2, Y1), new Point(X2, Y2));
                right.Code = new int[] {10, 2, 6};

                left = new Line(new Point(X1, Y1), new Point(X1, Y2));
                left.Code = new int[] { 9, 1, 5 };
            }

            public int GetCode(Point pt)
            {

                var code = 0;

                if (pt.X < X1) return code =+ 1;
                if (pt.Y < Y1) return code =+ 8;
                if (pt.X > X2) return code =+ 2;
                if (pt.Y > Y2) return code =+ 4;

                return code;
            }

            public void DrawRect(Graphics gr)
            {
                gr.DrawRectangle(new Pen(Color.Black), X1, Y1, X2 - X1, Y2 - Y1);
            }
        }

        public class Line //Класс для линии с методом определения положения прямой относительно окна
        {
            public Point P1, P2;
            public int[] Code;
            private Rect rect;

            public Line(Point p1, Point p2, Rect rect_)
            {
                P1 = p1;
                P2 = p2;
                rect = rect_;
            }


            public Line(Point p1, Point p2)
            {
                P1 = p1;
                P2 = p2;
            }


            public void DrawLine(Graphics gr)
            {
                gr.DrawLine(new Pen(Color.Black), P1, P2);
            }
        }
    }
}
