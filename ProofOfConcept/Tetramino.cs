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
        public int X;
        public int Y;
        private Colors _color;
        public Colors Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
            }
        }
        public Shape(List<Point> baseShape, int x, int y)
        {
            this.ShapePoints = baseShape;
            X = x;
            Y = y;
            _color = Colors.red;
        }

        public Shape(List<Point> baseShape, int x, int y, Colors color)
        {
            this.ShapePoints = baseShape;
            X = x;
            Y = y;
            _color = color;
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
