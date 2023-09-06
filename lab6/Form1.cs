using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab6
{
    public partial class Form1 : Form
    {

        Pen BLACK_PEN_BOLD = new Pen(Brushes.Black, 3);
        Pen BLACK_PEN_REGULAR = new Pen(Brushes.Black, 2);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            DrawBackground(g);
            DrawHouse(g, this.Width/2,this.Height-285,185, 185);
            DrawSun(g);
            DrawClouds(g);
            DrawGrass(g);
            DrawFence(g);

        }

        private void DrawBackground(Graphics g)
        {
            g.FillRectangle(new SolidBrush(Color.FromArgb(180, 153, 234, 237)), 0, 0, this.Width - 1, this.Height - 1);
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 69, 28, 3)), 0, this.Height - 100, this.Width - 1, this.Height - 100);
        }


        private void DrawHouse(Graphics g, int x_start, int y_start ,int width, int height)
        {

            //рисуем основу дома
            g.FillRectangle(new SolidBrush(Color.FromArgb(220, 255, 0, 0)), x_start + 1, y_start + 1, width - 1, height - 1);
            g.FillPolygon(new SolidBrush(Color.FromArgb(220, 255, 0, 0)),
                new Point[] {
                    new Point(x_start + 1,y_start+1),
                    new Point(x_start + width / 2, y_start - height / 2),
                    new Point(x_start+width - 1,y_start - 1)
                }
            );

           
            g.DrawLine(BLACK_PEN_BOLD, x_start, y_start, x_start + width, y_start);
            g.DrawLine(BLACK_PEN_BOLD, x_start + width, y_start, x_start + width, y_start+ height);
            g.DrawLine(BLACK_PEN_BOLD, x_start + width, y_start + height, x_start, y_start + height);
            g.DrawLine(BLACK_PEN_BOLD, x_start, y_start + height, x_start, y_start);
            g.DrawLine(BLACK_PEN_BOLD, x_start, y_start, x_start + width / 2, y_start - height / 2);
            g.DrawLine(BLACK_PEN_BOLD, x_start + width / 2, y_start - height / 2, x_start + width, y_start);
            

            //рисуем дверь
            int doorWidth = 50;
            int doorHeight = 90;
            int doorXStart = x_start + width - 80;
            int doorYStart = y_start + height;
            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 180, 67, 35)), doorXStart+1, doorYStart - doorHeight + 1, doorWidth, doorHeight-2);
            g.DrawLine(BLACK_PEN_REGULAR, doorXStart, doorYStart, doorXStart, doorYStart - doorHeight);
            g.DrawLine(BLACK_PEN_REGULAR, doorXStart, doorYStart - doorHeight, doorXStart + doorWidth, doorYStart - doorHeight);
            g.DrawLine(BLACK_PEN_REGULAR, doorXStart + doorWidth, doorYStart - doorHeight, doorXStart + doorWidth, doorYStart);

            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 0, 0, 0)), doorXStart + doorWidth - 15, (doorYStart - doorHeight/2),7,7);


            //рисуем окно

            int windowSize = 45;
            int windowXStart = x_start + 25;
            int windowYStart = y_start + 65;

            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 12, 151, 231)), windowXStart, windowYStart, windowSize, windowSize);

            g.DrawLine(BLACK_PEN_REGULAR, windowXStart, windowYStart, windowXStart + windowSize, windowYStart);
            g.DrawLine(BLACK_PEN_REGULAR, windowXStart + windowSize, windowYStart, windowXStart + windowSize, windowYStart + windowSize);
            g.DrawLine(BLACK_PEN_REGULAR, windowXStart + windowSize, windowYStart + windowSize, windowXStart, windowYStart +windowSize);
            g.DrawLine(BLACK_PEN_REGULAR, windowXStart, windowYStart + windowSize,windowXStart, windowYStart);
            g.DrawLine(BLACK_PEN_REGULAR, windowXStart + windowSize/2, windowYStart, windowXStart + windowSize / 2, windowYStart+windowSize);
            g.DrawLine(BLACK_PEN_REGULAR, windowXStart, windowYStart + windowSize/2, windowXStart + windowSize, windowYStart + windowSize / 2);

            //рисуем окно на крыше

            int roofWindowSize = 30;
            int roofWindowXStart = x_start + width / 2;
            int roofWindowYStart = y_start - 50;
            g.FillEllipse(new SolidBrush(Color.FromArgb(255, 12, 151, 231)), roofWindowXStart - roofWindowSize/2, roofWindowYStart, roofWindowSize, roofWindowSize);
            g.DrawEllipse(BLACK_PEN_REGULAR, roofWindowXStart - roofWindowSize / 2, roofWindowYStart, roofWindowSize, roofWindowSize);
            g.DrawLine(BLACK_PEN_REGULAR, roofWindowXStart, roofWindowYStart, roofWindowXStart, roofWindowYStart + roofWindowSize);
            g.DrawLine(BLACK_PEN_REGULAR, roofWindowXStart - roofWindowSize/2, roofWindowYStart + roofWindowSize/2, roofWindowXStart + roofWindowSize/2, roofWindowYStart + roofWindowSize / 2);


            //рисуем дымоход

            int chimneyWidth = 25;
            int chimneyHeight = 35;
            int chimneyXStart = x_start + 20;
            int chimneyYStart = y_start - 60;


            g.FillPolygon(new SolidBrush(Color.FromArgb(255, 110, 107, 109)), new Point[]
            {
                new Point(chimneyXStart,chimneyYStart),
                new Point(chimneyXStart, chimneyYStart + chimneyHeight+5),
                new Point(chimneyXStart+chimneyWidth,chimneyYStart + chimneyHeight/2 - 1),
                new Point(chimneyXStart+chimneyWidth,chimneyYStart)

            });

            g.DrawPolygon(BLACK_PEN_BOLD, new Point[]
            {
                new Point(chimneyXStart,chimneyYStart),
                new Point(chimneyXStart, chimneyYStart + chimneyHeight+5),
                new Point(chimneyXStart+chimneyWidth,chimneyYStart + chimneyHeight/2),
                new Point(chimneyXStart+chimneyWidth,chimneyYStart)
            });
        }


        private void DrawSun(Graphics g)
        {

        }


        private void DrawClouds(Graphics g)
        {

        }

        private void DrawGrass(Graphics g)
        {

        }

        private void DrawFence(Graphics g)
        {

        }



    }
}
