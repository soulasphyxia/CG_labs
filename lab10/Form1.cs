namespace lab10
{
    public partial class Form1 : Form
    {

        private double[,] Sq;
        private double[,] T;
        private double[,] P;
        private double[,] Sq_copy;
        private List<List<double>> points;

        Pen BLACK_REGULAR_PEN = new Pen(Brushes.Black, 1);
        Pen RED_REGULAR_PEN = new Pen(Brushes.Red);



        private int offset = 15;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int cx = ClientSize.Width / 2;
            int cy = ClientSize.Height / 2;

            g.DrawLine(BLACK_REGULAR_PEN, cx, 0, cx, ClientSize.Height);
            g.DrawLine(BLACK_REGULAR_PEN, 0, cy, ClientSize.Width, cy);




            List<Point> points = new List<Point>();
            for (int i = 0; i < Sq.GetLength(0); i++)
            {
                points.Add(new Point(cx + (int)Sq_copy[i, 0], cy - (int)Sq_copy[i, 1]));
            }
            g.DrawLines(RED_REGULAR_PEN, points.ToArray());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            points = new List<List<double>>();

            points.Add(new List<double> { 0, 0, 0, 1 });
            points.Add(new List<double> { 0, 0, 100, 1 });
            points.Add(new List<double> { 0, 100, 100, 1 });
            points.Add(new List<double> { 0, 100, 100, 1 });
            points.Add(new List<double> { 0, 100, 0, 1 });
            points.Add(new List<double> { 0, 0, 0, 1 });
            points.Add(new List<double> { 100, 0, 0, 1 });
            points.Add(new List<double> { 100, 0, 100, 1 });
            points.Add(new List<double> { 100, 100, 100, 1 });
            points.Add(new List<double> { 50, 50, 50, 1 });
            points.Add(new List<double> { 0, 100, 100, 1 });
            points.Add(new List<double> { 100, 100, 100, 1 });
            points.Add(new List<double> { 100, 100, 0, 1 });
            points.Add(new List<double> { 50, 50, 50, 1 });
            points.Add(new List<double> { 0, 100, 0, 1 });
            points.Add(new List<double> { 100, 100, 0, 1 });
            points.Add(new List<double> { 100, 0, 0, 1 });
            points.Add(new List<double> { 100, 0, 100, 1 });
            points.Add(new List<double> { 0, 0, 100, 1 });

            Sq = new double[points.Count, 4];
            Sq_copy = new double[points.Count, 4];


            int k = 0;
            foreach (var item in points)
            {
                for (int j = 0; j < item.Count; j++)
                {
                    Sq[k, j] = item[j];
                }

                k++;
            }

            Array.Copy(Sq, Sq_copy, Sq.Length);

            P = new double[4, 4];


            T = new double[4, 4] {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {0,0,0,1}
            };
            comboBox1.SelectedIndex = 1;
        }

        void Transformation()
        {

            var b = new double[4];

            for (int j = 0; j < Sq.GetLength(0); j++)
            {

                for (int i = 0; i < 4; i++)
                {
                    b[i] = 0;
                    for (int k = 0; k < 4; k++)
                        b[i] = b[i] + Sq[j, k] * T[k, i];
                }
                for (int k = 0; k < 4; k++)
                    Sq[j, k] = b[k];
            }

            for (int j = 0; j < Sq.GetLength(0); j++)
            {
                Sq[j, 0] = Sq[j, 0] / Sq[j, 3];
                Sq[j, 1] = Sq[j, 1] / Sq[j, 3];
                Sq[j, 2] = Sq[j, 2] / Sq[j, 3];
                Sq[j, 3] = 1;
            }
        }

        void Projection_Transformation()
        {
            var b = new double[4];
            for (int j = 0; j < Sq.GetLength(0); j++)
            {

                for (int i = 0; i < 4; i++)
                {
                    b[i] = 0;
                    for (int k = 0; k < 4; k++)
                        b[i] = b[i] + Sq[j, k] * P[k, i];
                }
                for (int k = 0; k < 4; k++)
                    Sq_copy[j, k] = b[k];
            }

            for (int j = 0; j < Sq_copy.GetLength(0); j++)
            {
                Sq_copy[j, 0] = Sq_copy[j, 0] / Sq_copy[j, 3];
                Sq_copy[j, 1] = Sq_copy[j, 1] / Sq_copy[j, 3];
                Sq_copy[j, 2] = Sq_copy[j, 2] / Sq_copy[j, 3];
                Sq_copy[j, 3] = 1;
            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                T = new double[4, 4] {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {offset,0,0,1} };
            }
            else if (radioButton2.Checked)
            {
                T = new double[4, 4] {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {0,offset,0,1} };
            }
            else if (radioButton3.Checked)
            {
                T = new double[4, 4] {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {0,0,offset,1} };
            }
            Transformation();
            Projection_Transformation();
            Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                T = new double[4, 4] {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {-offset,0,0,1} };
            }
            else if (radioButton2.Checked)
            {
                T = new double[4, 4] {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {0,-offset,0,1} };
            }
            else if (radioButton3.Checked)
            {
                T = new double[4, 4] {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {0,0,-offset,1} };
            }
            Transformation();
            Projection_Transformation();
            Invalidate();
        }


        private void button4_Click(object sender, EventArgs e)
        {
            double rotateAngle = double.Parse(textBox1.Text);

            double fi = Math.PI / 180 * rotateAngle;
            if (radioButton1.Checked)
            {
                T = new double[4, 4] {
                {1,0,0,0},
                {0,Math.Cos(fi),Math.Sin(fi),0},
                {0,-Math.Sin(fi),Math.Cos(fi),0},
                {0,0,0,1} };
            }
            else if (radioButton2.Checked)
            {
                T = new double[4, 4] {
                {Math.Cos(fi),0,-Math.Sin(fi),0},
                {0,1,0,0},
                {Math.Sin(fi),0,Math.Cos(fi),0},
                {0,0,0,1} };
            }
            else if (radioButton3.Checked)
            {
                T = new double[4, 4] {
                {Math.Cos(fi),Math.Sin(fi),0,0},
                {-Math.Sin(fi),Math.Cos(fi),0,0},
                {0,0,1,0},
                {0,0,0,1} };
            }
            Transformation();
            Projection_Transformation();
            Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            double rotateAngle = double.Parse(textBox1.Text);

            double fi = Math.PI / 180 * rotateAngle;
            if (radioButton1.Checked)
            {
                T = new double[4, 4] {
                {1,0,0,0},
                {0,Math.Cos(-fi),Math.Sin(-fi),0},
                {0,-Math.Sin(-fi),Math.Cos(-fi),0},
                {0,0,0,1} };
            }
            else if (radioButton2.Checked)
            {
                T = new double[4, 4] {
                {Math.Cos(-fi),0,-Math.Sin(-fi),0},
                {0,1,0,0},
                {Math.Sin(-fi),0,Math.Cos(-fi),0},
                {0,0,0,1} };
            }
            else if (radioButton3.Checked)
            {
                T = new double[4, 4] {
                {Math.Cos(-fi),Math.Sin(-fi),0,0},
                {-Math.Sin(-fi),Math.Cos(-fi),0,0},
                {0,0,1,0},
                {0,0,0,1} };
            }
            Transformation();
            Projection_Transformation();
            Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int it = 0;
            foreach (var item in points)
            {
                for (int j = 0; j < item.Count; j++)
                {
                    Sq[it, j] = item[j];

                }

                it++;
            }
            Sq_copy = Sq;
            P = new double[4, 4] {
                {1,0,0,0},
                {0,1,0,0},
                {0.5*Math.Cos(Math.PI/180*30), Math.Sin(Math.PI/180*30),0,0},
                {0,0,0,1}
            };

            T = new double[4, 4] {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {0,0,0,1}
            };
            Transformation();
            Projection_Transformation();
            Invalidate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                T = new double[4, 4] {
                {-1,0,0,0},
                {0,1,0,0},
                {0,0,1,0},
                {0,0,0,1} };
            }
            else if (radioButton2.Checked)
            {
                T = new double[4, 4] {
                {1,0,0,0},
                {0,-1,0,0},
                {0,0,1,0},
                {0,0,0,1} };
            }
            else if (radioButton3.Checked)
            {
                T = new double[4, 4] {
                {1,0,0,0},
                {0,1,0,0},
                {0,0,-1,0},
                {0,0,0,1} };
            }
            Transformation();
            Projection_Transformation();
            Invalidate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            double x_scaling = double.Parse(textBox2.Text);
            double y_scaling = double.Parse(textBox3.Text);
            double z_scaling = double.Parse(textBox4.Text);

            if (z_scaling != 1)
            {
                T = new double[4, 4] {
                {z_scaling,0,0,0},
                {0,z_scaling,0,0},
                {0,0,z_scaling,0},
                {0,0,0,1} };
            }
            else
            {
                T = new double[4, 4] {
                {x_scaling,0,0,0},
                {0,y_scaling,0,0},
                {0,0,z_scaling,0},
                {0,0,0,1} };
            }
            Transformation();
            Projection_Transformation();
            Invalidate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    P = new double[4, 4] {
                        {1,0,0,0},
                        {0,1,0,0},
                        {0,0,0,0},
                        {0,0,0,1}
                    };
                    break;
                case 1:
                    P = new double[4, 4] {
                        {1,0,0,0},
                        {0,1,0,0},
                        {0.5*Math.Cos(Math.PI/180*30), Math.Sin(Math.PI/180*30),0,0},
                        {0,0,0,1} 
                    };
                    break;
            
                case 2:
                    P = new double[4, 4] {
                        {1,0,0,0},
                        {0,1,0,0},
                        {0,0,0,0.001},
                        {0,0,0,1}
                    };
                    break;
            }

            Projection_Transformation();
            Invalidate();
        }
    }


}