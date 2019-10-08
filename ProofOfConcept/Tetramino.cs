using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProofOfConcept
{
    enum TetraminoTypes {I, O, T, J, L, S, Z}

    class Tetramino
    {
        public List<Point> Points;
        public int X;
        public int Y;
        public TetraminoTypes Type;
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

        public int LowestPoint
        {
            get
            {
                int lowestPoint=0;
                foreach(Point point in Points)
                {
                    if(point.Y > lowestPoint)
                    {
                        lowestPoint = point.Y; 
                    }
                }
                return lowestPoint;
            }
        }
        public int HighestPoint
        {
            get
            {
                int highestPoint = 0;
                foreach (Point point in Points)
                {
                    if (point.Y > highestPoint)
                    {
                        highestPoint = point.Y;
                    }
                }
                return highestPoint; 
            }
        }
        
        public Tetramino(int x, int y)
        {
            Random random=new Random();
            int rand = random.Next(0, 6);
            switch (rand)
            {
                case 0:
                    Type = TetraminoTypes.I;
                    Color = Colors.Turquoise;
                    Points = new List<Point>() { new Point(0, 0), new Point(-1, 0), new Point(1, 0), new Point(2, 0) };
                    break;
                case 1:
                    Type = TetraminoTypes.J;
                    Color = Colors.Blue;
                    Points = new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(0, -1), new Point(1, 1) };
                    break;
                case 2:
                    Type = TetraminoTypes.L;
                    Color = Colors.Orange;
                    Points = new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(0, -1), new Point(-1, 1) };
                    break;
                case 3:
                    Type = TetraminoTypes.O;
                    Color = Colors.Yellow;
                    Points = new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(1, 0), new Point(1, 1) };
                    break;
                case 4:
                    Type = TetraminoTypes.S;
                    Color = Colors.Green;
                    Points = new List<Point>() { new Point(0, 0), new Point(-1, 0), new Point(0, 1), new Point(1, 1) };
                    break;
                case 5:
                    Type = TetraminoTypes.T;
                    Color = Colors.Purple;
                    Points = new List<Point>() { new Point(0, 0), new Point(1, 0), new Point(-1, 0), new Point(0, 1) };
                    break;
                case 6:
                    Type = TetraminoTypes.Z;
                    Color = Colors.Red;
                    Points = new List<Point>() { new Point(0, 0), new Point(-1, 1), new Point(0, 1), new Point(1, 0) };
                    break;
            }

            
            X = x;
            Y = y;
            
        }

        public void Rotate(Directions direction)
        {
            if (Type == TetraminoTypes.O)
            {

            }
            else if (Type == TetraminoTypes.O)
            {
                
            }
            else
            {
                List<Point> newShape = new List<Point>();

                if (direction == Directions.Right)
                {
                    //rotates the figure
                    foreach (Point point in Points)
                    {
                        double rotateX = Math.Round(point.X * Math.Cos(Math.PI / 2) - point.Y * Math.Sin(Math.PI / 2));
                        double rotateY = Math.Round(point.X * Math.Sin(Math.PI  / 2) - point.Y * Math.Cos(Math.PI / 2));
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
}
