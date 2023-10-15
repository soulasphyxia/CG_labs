using System.Collections;

namespace lab9
{
    public partial class Form1 : Form
    {
        private Pen BLACK_PEN_REGULAR = new Pen(Brushes.Black, 2);
        private Pen RED_PEN_REGULAR = new Pen(Brushes.Red, 2);
        private double[,] Sq;
        private double[,] T;
        private List<PointF> objectPoints;

        private double r1 = 70;
        private double r2 = 140;

        private int offset = 5;

        private double rotateAngle;

        private int mouse_x = -1;
        private int mouse_y = -1;

        int axis_x;
        int axis_y;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            axis_x = ClientSize.Width / 2;
            axis_y = ClientSize.Height / 2;
            objectPoints = GetStartObjectPoints();
            ListToMatrix();
            T = new double[3, 3];
        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            g.DrawLine(BLACK_PEN_REGULAR, ClientSize.Width / 2, 0, ClientSize.Width / 2, ClientSize.Height);
            g.DrawLine(BLACK_PEN_REGULAR, 0, ClientSize.Height / 2, ClientSize.Width, ClientSize.Height / 2);
            for (int i = 0; i < Sq.Length / 3 - 1; i++)
            {
                if (i != 10)
                {
                    e.Graphics.DrawLine(RED_PEN_REGULAR, (int)(axis_x + Sq[i, 0]), (int)(axis_y + Sq[i, 1]), (int)(axis_x + Sq[i + 1, 0]), (int)(axis_y + Sq[i + 1, 1]));
                }

            }



        }

        private void ResetObjectPosition()
        {
            mouse_x = -1;
            mouse_y = -1;
            axis_x = ClientSize.Width / 2;
            axis_y = ClientSize.Height / 2;
            objectPoints = GetStartObjectPoints();
            label3.Location = new Point(735, label3.Location.Y);
            label3.Text = "Центра";
            ListToMatrix();
            Invalidate();
        }

        void Transform()
        {
            var b = new double[3];
            for (int j = 0; j < Sq.Length / 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    b[i] = 0;
                    for (int k = 0; k < 3; k++)
                        b[i] = b[i] + Sq[j, k] * T[k, i];
                }
                for (int k = 0; k < 3; k++)
                    Sq[j, k] = b[k];
            }

            for (int j = 0; j < Sq.Length / 3; j++)
            {
                Sq[j, 0] = Sq[j, 0] / Sq[j, 2];
                Sq[j, 1] = Sq[j, 1] / Sq[j, 2];
                Sq[j, 2] = 1;
            }
        }


        private List<PointF> GetStartObjectPoints()
        {
            List<PointF> pointsList = new List<PointF>();
            int a = 54;
            for (int i = 0; i < 11; i++)
            {
                if (i % 2 == 0)
                {
                    pointsList.Add(new PointF(
                        Convert.ToInt32((r2 / 2 * Math.Cos(a * Math.PI / 180))),
                        Convert.ToInt32((r2 / 2 * Math.Sin(a * Math.PI / 180)))
                        )
                    );
                }
                else
                {
                    pointsList.Add(new PointF(
                        Convert.ToInt32((r1 / 2 * Math.Cos(a * Math.PI / 180))),
                        Convert.ToInt32((r1 / 2 * Math.Sin(a * Math.PI / 180)))
                        )
                    );
                }
                a += 36;
            }

            for (int i = 0; i < 360; i++)
            {
                double angle = i * Math.PI / 180;
                double x = r1 / 2 * Math.Cos(angle);
                double y = r1 / 2 * Math.Sin(angle);

                pointsList.Add(new PointF((float)x, (float)y));
            }

            return pointsList;
        }

        private void ListToMatrix()
        {
            Sq = new double[objectPoints.Count, 3];
            for (int i = 0; i < objectPoints.Count; i++)
            {
                Sq[i, 0] = objectPoints[i].X;
                Sq[i, 1] = objectPoints[i].Y;
                Sq[i, 2] = 1;
            }
        }

        private void setTMatrixToDefault()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j)
                    {
                        T[i, j] = 1;
                    }
                    else
                    {
                        T[i, j] = 0;
                    }
                }
            }
        }



        //обработчики для кнопок: вправо, влево, вверх, вниз
        private void button1_Click(object sender, EventArgs e)
        {
            setTMatrixToDefault();
            T[2, 0] = offset;
            Transform();
            Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            setTMatrixToDefault();
            T[2, 0] = -offset;
            Transform();
            Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            setTMatrixToDefault();
            T[2, 1] = -offset;
            Transform();
            Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            setTMatrixToDefault();
            T[2, 1] = offset;
            Transform();
            Invalidate();
        }

        //обработчики для кнопок: увеличить масштаб, уменьшить масштаб

        private void button6_Click(object sender, EventArgs e)
        {
            setTMatrixToDefault();
            T[0, 0] = 1.25;
            T[1, 1] = 1.25;
            T[2, 2] = 1;
            Transform();
            Invalidate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            setTMatrixToDefault();
            T[0, 0] = 0.75;
            T[1, 1] = 0.75;
            T[2, 2] = 1;
            Transform();
            Invalidate();
        }

        //обработчики для кнопок: отражение по Х, отражение по У
        private void button8_Click(object sender, EventArgs e)
        {
            setTMatrixToDefault();
            T[1, 1] = -1;
            Transform();
            Invalidate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            setTMatrixToDefault();
            T[0, 0] = -1;
            Transform();
            Invalidate();
        }

        //обработчики для кнопок: поворот вправо, поворот влево
        private void button10_Click(object sender, EventArgs e)
        {
            setTMatrixToDefault();
            rotateAngle = double.Parse(textBox1.Text);
            double fi = rotateAngle * Math.PI / 180;
            T[0, 0] = Math.Cos(fi);
            T[0, 1] = Math.Sin(fi);
            T[1, 0] = -Math.Sin(fi);
            T[1, 1] = Math.Cos(fi);
            Transform();
            Invalidate();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            setTMatrixToDefault();
            rotateAngle = double.Parse(textBox1.Text);
            double fi = -rotateAngle * Math.PI / 180;
            T[0, 0] = Math.Cos(fi);
            T[0, 1] = Math.Sin(fi);
            T[1, 0] = -Math.Sin(fi);
            T[1, 1] = Math.Cos(fi);
            Transform();
            Invalidate();
        }

        //обработчик для кнопки сброса позиции
        private void button2_Click(object sender, EventArgs e)
        {
            ResetObjectPosition();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouse_x = e.Location.X;
                mouse_y = e.Location.Y;
                axis_x = mouse_x;
                axis_y = mouse_y;
                label3.Location = new Point(700, label3.Location.Y);
                label3.Text = "Точки (" + $"{mouse_x}," + $"{mouse_y})";
            }
            if (e.Button == MouseButtons.Right)
            {
                mouse_x = -1;
                mouse_y = -1;
                axis_x = ClientSize.Width / 2;
                axis_y = ClientSize.Height / 2;
                label3.Location = new Point(735, label3.Location.Y);
                label3.Text = "Центра";
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.Right:
                        if (e.Shift)
                        {
                            button10.PerformClick();
                        }
                        else
                        {
                            button1.PerformClick();
                        }
                        break;
                    case Keys.Left:

                        if (e.Shift)
                        {
                            button11.PerformClick();
                        }
                        else
                        {
                            button3.PerformClick();
                        }
                        break;
                    case Keys.Up:
                        
                        button4.PerformClick();
                       
                        break;
                    case Keys.Down:
                        button5.PerformClick();
                        break;
                    case Keys.Oemplus:
                        button6.PerformClick();
                        break;
                    case Keys.OemMinus:
                        button7.PerformClick();
                        break;
                    case Keys.Z:
                        button8.PerformClick();
                        break;
                    case Keys.X:
                        button9.PerformClick();
                        break;
                    case Keys.Delete:
                        button2.PerformClick();
                        break;


                }
            }
        }
    }
}