using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab7
{
    public partial class Form1 : Form
    {
        private int x1, y1, x2, y2;
        private double a, t, fi;
        private Pen pen = new Pen(Color.DarkRed, 2);





        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawEllipse(pen, x2, y2, 20, 20);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x1 = 300;
            y1 = 200;
            a = 10;
            fi = -1;
            t = Math.Tan(fi/3);
            x2 = x1 - (int)(3 * a * (3 - t * t));
            y2 = y1 + (int)(a * t * (3 - t * t));
            Console.WriteLine(x2 + " " + y2);


        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            fi += 0.01;
            t = Math.Tan(fi/3);
            x2 = x1 - (int)(3 * a * (3 - t * t));
            y2 = y1 + (int)(a * t * (3 - t * t));
            Console.WriteLine(x2 + " " + y2);
            Invalidate();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 5;
            timer1.Enabled = true;
        }
        

    }
}
