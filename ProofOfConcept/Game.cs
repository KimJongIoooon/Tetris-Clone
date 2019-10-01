    using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept
{
    class Game
    {
        bool gameStarted=false;
        List<int> Numbers = new List<int>();
        private Block[,] _field = new Block[10, 24];

        
        public int TickRate;//default 1 sec
        public Shape activeShape = new Shape(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(0, -1), new Point(1, 1) },5,5);

        public void Rotate()
        {
            
        }
        public void Start()
        {

        }
        public void Stop()
        {

        }
        public void Left()
        {

        }
        public void Right()
        {

        }
        public void Drop()
        {

        }
        public Block[,] Field
        {
            get
            {
                if (gameStarted)
                {
                    Block[,] fieldWithShape = _field;
                    foreach (Point point in activeShape.ShapePoints)
                    {
                        int shapeX = activeShape.X + point.X;
                        int shapeY = activeShape.Y + point.Y;
                        if(shapeX > 0 && shapeY > 0) {
                            fieldWithShape[shapeX, shapeY].Filled = true;
                            fieldWithShape[shapeX, shapeY].Color = activeShape.Color;
                        }
                    }
                    return fieldWithShape;
                }
                return new Block[10, 24];
            }
        }

        public Game()
        {
            _field[0, 0] = new Block();
            //Assign empty blocks to field.
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    _field[x, y] = new Block();
                }

            }
            gameStarted = true;
            TickRate = 1000; 
        }

        public void Tick()
        {
            activeShape.Y++;    
        }

        public void FillFieldTest() {

            _field[0, 0] = new Block(Colors.blue);
            _field[1, 0] = new Block(Colors.green);
            _field[2, 0] = new Block(Colors.orange);
            _field[3, 0] = new Block(Colors.purple);
            _field[4, 0] = new Block(Colors.red);
            _field[5, 0] = new Block(Colors.turquoise);
            _field[6, 0] = new Block(Colors.yellow);
            _field[7, 0] = new Block(Colors.green);
            _field[8, 0] = new Block(Colors.blue);
            _field[9, 0] = new Block(Colors.green);
            _field[2, 13].Filled = false;
            _field[4, 23].Filled = false;
            _field[1, 16].Filled = false;
            _field[4, 6].Filled = false;

        }
    }
}
