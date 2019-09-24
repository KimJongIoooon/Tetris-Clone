using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ProofOfConcept
{
    class Shape
    {
        public List<Point> ShapePoints;
        int X;
        int Y; 
        enum Color {Red, DarkBlue, LightBlue, Green, Yellow, Orange, purple};

        public Shape(List<Point> baseShape, int x, int y)
        {
            this.ShapePoints = baseShape;
            X = x;
            Y = y;
        }

        public void Rotate()
        {
            //rotates the figure
            int[,] rotateMatrix = new int[,] { { 0, 1 }, { -1, 0 } };
            List<Point> newShape = new List<Point>();
            foreach (Point point in ShapePoints)
            {
                double rotateX = Math.Round(point.X * Math.Cos(Math.PI / 2) - point.Y * Math.Sin(Math.PI / 2));
                double rotateY = Math.Round(point.X * Math.Sin(Math.PI / 2) - point.Y * Math.Cos(Math.PI / 2));
                Point rotatedPoint = new Point(Convert.ToInt32(rotateX), Convert.ToInt32(rotateY));
                newShape.Add(rotatedPoint);
            }
            ShapePoints = newShape;
        }
        
    }
}
