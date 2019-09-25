using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProofOfConcept
{
    public partial class Form1 : Form
    {
        Game game;
        List<Point> pointsT = new List<Point>() { new Point(0, 0), new Point(0, 1) , new Point(0, -1), new Point(1, 1)};
        Shape shapeT;


        public Form1()
        {
            InitializeComponent();
            shapeT = new Shape(pointsT, 10, 6);
            game = new Game();
            game.FillFieldTest();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            shapeT.Rotate();
            updateGraphics();
        }

        private void updateGraphics()
        {
            pnlField.Invalidate();
            this.Invalidate();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Vraag het Graphics object op, dat bij dit form hoort.
            // Met dit graphics object kunnen we op het form tekenen.
            Graphics graphics = e.Graphics;

            int margin = 100;
            int blockSize = 10;

            foreach (Point point in shapeT.ShapePoints)
            {
                int x = margin + point.X * blockSize;
                int y = margin + point.Y * blockSize;
                graphics.FillRectangle(Brushes.Black, x, y, blockSize, blockSize);
            }


            
            //foreach (Block block in game.Field)
            //{
            //    int x = margin + point.X * blockSize;
            //    int y = margin + point.Y * blockSize;
            //    graphics.FillRectangle(Brushes.Black, x, y, blockSize, blockSize);
            //}
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

        }
        private int CovertPixelsToPoints(float pixels)
        {
            Graphics g = CreateGraphics();
            float fBlockSizePoint = pixels * 72 / g.DpiX;
            g.Dispose();
            return Convert.ToInt32(fBlockSizePoint);
        }

        private void PnlField_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            int blockSizePixels = 20;

            //pixels = (1/72)*graphics.DpiX*points
            Block block;
            Brush brush = Brushes.Red;
            for (int y = 0; y < 24; y++)
            {


                for (int x = 0; x < 10; x++)
                {
                    block = game.Field[x, y];
                    if (block.Filled)
                    {
                        switch (block.Color)
                        {
                            case Colors.blue:
                                brush = Brushes.Blue;
                                break;
                            case Colors.turquoise:
                                brush = Brushes.Turquoise;
                                break;
                            case Colors.yellow:
                                brush = Brushes.Yellow;
                                break;
                            case Colors.red:
                                brush = Brushes.Red;
                                break;
                            case Colors.orange:
                                brush = Brushes.Orange;
                                break;
                            case Colors.purple:
                                brush = Brushes.Purple;
                                break;
                            case Colors.green:
                                brush = Brushes.Green;
                                break;
                        }
                        graphics.FillRectangle(brush, CovertPixelsToPoints(x * blockSizePixels), CovertPixelsToPoints(y * blockSizePixels), CovertPixelsToPoints(blockSizePixels), CovertPixelsToPoints(blockSizePixels));
                    }

                }
            }
        }
    }
}
