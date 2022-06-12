using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fractal
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            

            

            Random random = new Random();
            
            int point1X = 728, point1Y = 50, point2X = 800, point2Y = 720 ,point3X = 30 ,point3Y = 700;

            Rectangle point1 = new Rectangle(point1X, point1Y, 1, 1);
            Rectangle point2 = new Rectangle(point2X, point2Y, 1, 1);
            Rectangle point3 = new Rectangle(point3X, point3Y, 1, 1);         

            graphics.DrawRectangle(Pens.BlueViolet, point1);
            graphics.DrawRectangle(Pens.BlueViolet, point2);
            graphics.DrawRectangle(Pens.BlueViolet, point3);


            int startX = 728, startY = 376;

            Rectangle dot = new Rectangle(startX, startY, 1, 1);
            graphics.DrawRectangle(Pens.BlueViolet, dot);
            int middleX,middleY;
            

            for (int i = 0; i < 100000; i++)
            {
                int numb = random.Next(1, 5);
                if(numb == 1)
                {
                    middleX = (startX + point1X)/2;
                    middleY = (startY + point1Y)/2;
                    Rectangle middlePoint = new Rectangle(middleX, middleY, 1, 1);
                    graphics.DrawRectangle(Pens.Black, middlePoint);
                    startX = middleX;
                    startY = middleY;
                }
                else if(numb == 2)
                {
                    middleX = (startX + point2X) / 2;
                    middleY = (startY + point2Y) / 2;
                    Rectangle middlePoint = new Rectangle(middleX, middleY, 1, 1);
                    graphics.DrawRectangle(Pens.Red, middlePoint);
                    startX = middleX;
                    startY = middleY;
                }
                else
                {
                    middleX = (startX + point3X) / 2;
                    middleY = (startY + point3Y) / 2;
                    Rectangle middlePoint = new Rectangle(middleX, middleY, 1, 1);
                    graphics.DrawRectangle(Pens.DarkGray, middlePoint);
                    startX = middleX;
                    startY = middleY;
                }
               

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();

            int point1X = 728, point1Y = 50, point2X = 1400, point2Y = 720, point3X = 30, point3Y = 700;

            Rectangle point1 = new Rectangle(point1X, point1Y, 1, 1);
            Rectangle point2 = new Rectangle(point2X, point2Y, 1, 1);
            Rectangle point3 = new Rectangle(point3X, point3Y, 1, 1);

            graphics.DrawRectangle(Pens.BlueViolet, point1);
            graphics.DrawRectangle(Pens.BlueViolet, point2);
            graphics.DrawRectangle(Pens.BlueViolet, point3);
        }
    }
}
