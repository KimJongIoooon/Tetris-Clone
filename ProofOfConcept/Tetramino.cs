using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProofOfConcept
{
    class Tetramino
    {
        public List<Point> Points;
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
        public Tetramino(List<Point> baseShape, int x, int y)
        {
            this.Points = baseShape;
            X = x;
            Y = y;
            _color = Colors.Red;
        }

        public Tetramino(List<Point> baseShape, int x, int y, Colors color)
        {
            this.Points = baseShape;
            X = x;
            Y = y;
            _color = color;
        }

        public void Rotate(Directions direction)
        {
            List<Point> newShape = new List<Point>();

            if (direction == Directions.Right)
            {
                //rotates the figure
                foreach (Point point in Points)
                {
                    double rotateX = Math.Round(point.X * Math.Cos(Math.PI / 2) - point.Y * Math.Sin(Math.PI / 2));
                    double rotateY = Math.Round(point.X * Math.Sin(Math.PI / 2) - point.Y * Math.Cos(Math.PI / 2));
                    Point rotatedPoint = new Point(Convert.ToInt32(rotateX), Convert.ToInt32(rotateY));
                    newShape.Add(rotatedPoint);
                }
            }
            if (direction == Directions.Left)
            {
                //rotates the figure
                foreach (Point point in Points)
                {
                    double rotateX = Math.Round(point.X * Math.Cos(Math.PI * 1.5) - point.Y * Math.Sin(Math.PI * 1.5));
                    double rotateY = Math.Round(point.X * Math.Sin(Math.PI * 1.5) - point.Y * Math.Cos(Math.PI * 1.5));
                    Point rotatedPoint = new Point(Convert.ToInt32(rotateX), Convert.ToInt32(rotateY));
                    newShape.Add(rotatedPoint);
                }
            }
            Points = newShape;
        }
        
    }
}
