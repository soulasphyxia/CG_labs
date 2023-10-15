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
        private SolidBrush BLACK_BRUSH = new SolidBrush(Color.Black);
      
 

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillEllipse(BLACK_BRUSH, x2, y2, 20, 20);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            x1 = ClientSize.Width / 2 +200;
            y1 = ClientSize.Height / 2;
            a = 25;
            fi = -3.8;
            t = Math.Tan(fi / 3);
            x2 = x1 + (int)(a * (1 - 3 * t * t));
            y2 = y1 - (int)(a * t * (3 - t * t));
           


        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            fi += 0.03;
            t = Math.Tan(fi / 3);
            x2 = x1 + (int)(a * (1 - 3 * t * t));
            y2 = y1 - (int)(a * t * (3 - t * t));
            if(fi > 3.8)
            {
                fi = -3.8;
            }
            Invalidate();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 5;
            timer1.Enabled = true;
        }

    }
}
