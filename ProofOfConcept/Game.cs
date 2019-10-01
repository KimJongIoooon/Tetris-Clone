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
        bool started = false;
        public bool Started
        {
            get { return started; }
        }
        
        List<int> Numbers = new List<int>();
        private Block[,] _field = new Block[10, 24];

        
        public int TickRate;//default 1 sec
        public Tetramino activeShape = new Tetramino(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(0, -1), new Point(1, 1) },0,2);

        public void Rotate()
        {
            
        }
        public void Start()
        {

            if (!started)
            {
                started = true;
            }
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
                if (started)
                {
                    Block[,] fieldWithShape = new Block[10, 24];
                    Array.Copy(_field, fieldWithShape, _field.Length);

                    foreach (Point point in activeShape.Points)
                    {
                        int shapeX = activeShape.X + point.X;
                        int shapeY = activeShape.Y + point.Y;

                        //dont draw if the block is outside the field.
                        if(shapeX >= 0 && shapeY >= 0) {
                            fieldWithShape[shapeX, shapeY].Filled = true;
                            fieldWithShape[shapeX, shapeY].Color = activeShape.Color;
                        } 
                    }
                    return fieldWithShape;
                }
                return new Block[10, 24];
            }
        }

        public bool Started1 { get => started; set => started = value; }

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
            started = false;
            TickRate = 1000; 
        }

        public void Tick()
        {
            activeShape.Y = activeShape.Y + 1;
            int currentColor = (int)activeShape.Color;
            currentColor++;
            if (currentColor > 2)
            {
                currentColor = 0;
            }
            switch (currentColor)
            {
                case 0: activeShape.Color = Colors.turquoise; break;
                case 1: activeShape.Color = Colors.blue; break;
                case 2: activeShape.Color = Colors.orange; break;
                case 3: break;
            }
        }

        public void FillFieldTest() {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    _field[x, y] = new Block();
                }
            }
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
        }
    }
}
