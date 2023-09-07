using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace lab6
{
    public partial class Form1 : Form
    {

        Pen BLACK_PEN_BOLD = new Pen(Brushes.Black, 3);
        Pen BLACK_PEN_REGULAR = new Pen(Brushes.Black, 2);
        Pen YELLOW_PEN_BOLD = new Pen(Color.FromArgb(255, 255, 255, 50), 3);
        SolidBrush BROWN_BRUSH = new SolidBrush(Color.FromArgb(255, 180, 67, 35));
        SolidBrush GREEN_BRUSH = new SolidBrush(Color.FromArgb(255, 42, 154, 78));
        SolidBrush YELLOW_BRUSH = new SolidBrush(Color.FromArgb(255, 255, 255, 50));
        SolidBrush BLACK_BRUSH = new SolidBrush(Color.FromArgb(255, 0, 0, 0));
        SolidBrush BLUE_BRUSH = new SolidBrush(Color.FromArgb(255, 12, 151, 231));
        SolidBrush WHITE_BRUSH = new SolidBrush(Color.FromArgb(255, 255, 255, 255));
        SolidBrush GRAY_BRUSH = new SolidBrush(Color.FromArgb(255, 196, 200, 197));

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.White);
            DrawBackground(g);
            DrawHouse(g, this.Width/2 + 20,this.Height-285,185, 185);
            DrawSun(g);
            DrawClouds(g);
            DrawTree(g,350,this.Height - 300);
            DrawTree(g, 120, this.Height - 300);
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
            g.FillRectangle(BROWN_BRUSH, doorXStart+1, doorYStart - doorHeight + 1, doorWidth, doorHeight-2);
            g.DrawLine(BLACK_PEN_REGULAR, doorXStart, doorYStart, doorXStart, doorYStart - doorHeight);
            g.DrawLine(BLACK_PEN_REGULAR, doorXStart, doorYStart - doorHeight, doorXStart + doorWidth, doorYStart - doorHeight);
            g.DrawLine(BLACK_PEN_REGULAR, doorXStart + doorWidth, doorYStart - doorHeight, doorXStart + doorWidth, doorYStart);

            g.FillEllipse(BLACK_BRUSH, doorXStart + doorWidth - 15, (doorYStart - doorHeight/2),7,7);


            //рисуем окно

            int windowSize = 45;
            int windowXStart = x_start + 25;
            int windowYStart = y_start + 65;

            g.FillRectangle(BLUE_BRUSH, windowXStart, windowYStart, windowSize, windowSize);

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
            g.FillEllipse(BLUE_BRUSH, roofWindowXStart - roofWindowSize/2, roofWindowYStart, roofWindowSize, roofWindowSize);
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


            //рисуем дым
            int smokeXStart = chimneyXStart + 25;
            int smokeYStart = chimneyYStart - chimneyHeight - 5;
            g.FillClosedCurve(GRAY_BRUSH, new Point[]
            {
                new Point(smokeXStart,smokeYStart),
                new Point(smokeXStart - 20,smokeYStart + 20),
                new Point(smokeXStart,smokeYStart - 20),
                

            }) ;


        }


        private void DrawSun(Graphics g)
        {
            g.FillPie(YELLOW_BRUSH, new Rectangle(-100, -100, 200, 200), 0, 90);
            g.DrawLine(YELLOW_PEN_BOLD, 0, 0, 160, 80);
            g.DrawLine(YELLOW_PEN_BOLD, 0, 0, 180, 30);
            g.DrawLine(YELLOW_PEN_BOLD, 0, 0, 100, 150);
            g.DrawLine(YELLOW_PEN_BOLD, 0, 0, 30, 180);
        }


        private void DrawClouds(Graphics g)
        {
            g.FillClosedCurve(WHITE_BRUSH, GetCloudPoints(250, 60));
            g.FillClosedCurve(WHITE_BRUSH, GetCloudPoints(480, 60));
            g.FillClosedCurve(WHITE_BRUSH, GetCloudPoints(730, 60));
        }


        private Point[] GetCloudPoints(int x_start, int y_start)
        {
            Point[] cloudPoints = new Point[14];
            int x_increment = 30;
            int y_increment = 30;
            cloudPoints[0] = new Point(x_start, y_start);
            for (int i = 1; i < cloudPoints.Length; i++)
            {
                if(i == cloudPoints.Length / 2)
                {
                    x_increment = -x_increment;
                    y_increment = -y_increment;
                    cloudPoints[i] = new Point(cloudPoints[i - 1].X, y_start);
                    continue;
                }
               
                if(i % 2 != 0)
                {
                    cloudPoints[i] = new Point(cloudPoints[i - 1].X + x_increment, y_start - y_increment);
                }
                else
                {
                    cloudPoints[i] = new Point(cloudPoints[i - 1].X + x_increment, y_start - y_increment / 2);
                }
               
                
            }
            cloudPoints[cloudPoints.Length - 1].Y = y_start;
            return cloudPoints;
        }

        private void DrawGrass(Graphics g)
        {
            int x_start = 1;
            int y_start = this.Height - 100;
            int pieceHeight = 10;
            int pieceWidth = 15;
            for (int i = 0; i < 34; i++)
            {
                
                g.FillPolygon(GREEN_BRUSH, new Point[]
                {
                    new Point(x_start, y_start),
                    new Point(x_start, y_start - pieceHeight),
                    new Point(x_start + pieceWidth / 2, y_start - pieceHeight - 10),
                    new Point(x_start + pieceWidth, y_start - pieceHeight),
                    new Point(x_start + pieceWidth, y_start)
                }
                );
                x_start += 15;
            }
        }



        private void DrawFence(Graphics g)
        {
            int x = this.Width / 2 + 206;
            int y = this.Height - 100;
            for(int i = 0; i < 8; i++)
            {
                Point[] points = getFencePiecePoints(x, y);
                g.FillPolygon(BROWN_BRUSH, points);
                g.DrawPolygon(BLACK_PEN_REGULAR, points);
                x += 40;
            }
            
        }

        private Point[] getFencePiecePoints(int x_start, int y_start)
        {
            Point[] fencePiecePoints = new Point[5];
            int pieceHeight = 70;
            int pieceWidth = 40;

            fencePiecePoints[0] = new Point(x_start, y_start);
            fencePiecePoints[1] = new Point(x_start, y_start - pieceHeight);
            fencePiecePoints[2] = new Point(x_start + pieceWidth/2, y_start - pieceHeight - 10);
            fencePiecePoints[3] = new Point(x_start + pieceWidth, y_start - pieceHeight);
            fencePiecePoints[4] = new Point(x_start + pieceWidth, y_start);

            return fencePiecePoints;
        }


        private void DrawTree(Graphics g, int x_start, int y_start)
        {

            g.FillRectangle(BROWN_BRUSH, x_start, y_start, 40, 200);

            g.FillEllipse(GREEN_BRUSH, x_start-55, y_start-30,150,120);


            


        }
    }
}
