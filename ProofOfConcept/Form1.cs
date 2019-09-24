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
        List<Point> pointsT = new List<Point>() { new Point(0, 0), new Point(0, 1) , new Point(1, 0), new Point(-1, 3)};
        Shape shapeT;


        public Form1()
        {
            InitializeComponent();
            shapeT = new Shape(pointsT, 10, 6);
            game = new Game();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            shapeT.Rotate();
            this.Invalidate();
        }

        private void Draw()
        {
           
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Vraag het Graphics object op, dat bij dit form hoort.
            // Met dit graphics object kunnen we op het form tekenen.
            Graphics graphics = e.Graphics;

            int margin = 100;
            int blockSize = 20;

            foreach (Point point in shapeT.ShapePoints)
            {
                int x = margin + point.X * blockSize;
                int y = margin + point.Y * blockSize;
                graphics.FillRectangle(Brushes.Black, x, y, blockSize, blockSize);
            }

            //foreach (Point point in game.Field)
            //{
            //    int x = margin + point.X * blockSize;
            //    int y = margin + point.Y * blockSize;
            //    graphics.FillRectangle(Brushes.Black, x, y, blockSize, blockSize);
            //}m
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
