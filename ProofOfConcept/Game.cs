    using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProofOfConcept
{
    public enum Colors { Turquoise, Blue, Orange, Yellow, Green, Purple, Red };
    class Game
    {
        
        public enum Directions {Left, Right, Up, Down}
        bool _started = false;
        List<int> Numbers = new List<int>();
        private Block[,] _field = new Block[10, 24];
        public int TickRate = 1000;//default 1 sec
        public Tetramino _activeTetramino = new Tetramino(new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(0, -1), new Point(1, 1) }, 0, 2);

        public bool Started
        {
            get { return _started; }
        }
        
        
        public void Rotate()
        {
            
        }
        public void Start()
        {

            if (!_started)
            {
                _started = true;
            }
        }
        public void Stop()
        {

        }
        public void Move(string direction)
        {
            int move;
            if (direction == "left") {
                move = -1;
            } else if (direction == "right")
            {
                move = 1;
            }
            else
            {
                throw new System.ArgumentException("Only left or right allowed", "direction");
            }


            bool failed = false;
            foreach (Point point in _activeTetramino.Points)
            {
                int newX = _activeTetramino.X + point.X + move;
                int Y = _activeTetramino.Y + point.Y;
                try{
                    if (Field[newX, Y].Filled)
                    {
                        failed = true;
                        break;
                    }
                }
                catch
                {
                    failed = true;
                    break;
                }
                
            }

            if (!failed)
            {
                _activeTetramino.X = _activeTetramino.X + move;
            }
        }
        public void Drop()
        {
            
        }

        public Block[,] Field
        {
            get
            {
                if (_started)
                {
                    return _field;
                }
                else
                {
                    return new Block[10, 24];
                }
                
            }
        }
        public Tetramino ActiveTetramino
        {
            get
            {
                return _activeTetramino;
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
            _started = false;
            TickRate = 1000; 
        }

        public void Tick()
        {
            _activeTetramino.Y = _activeTetramino.Y + 1;
            int currentColor = (int)_activeTetramino.Color;
            currentColor++;
            if (currentColor > 2)
            {
                currentColor = 0;
            }
            switch (currentColor)
            {
                case 0: _activeTetramino.Color = Colors.Turquoise; break;
                case 1: _activeTetramino.Color = Colors.Blue; break;
                case 2: _activeTetramino.Color = Colors.Orange; break;
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
            _field[0, 0] = new Block(Colors.Blue);
            _field[1, 0] = new Block(Colors.Green);
            _field[2, 0] = new Block(Colors.Orange);
            _field[3, 0] = new Block(Colors.Purple);
            _field[4, 0] = new Block(Colors.Red);
            _field[5, 0] = new Block(Colors.Turquoise);
            _field[6, 0] = new Block(Colors.Yellow);
            _field[7, 0] = new Block(Colors.Green);
            _field[8, 0] = new Block(Colors.Blue);
            _field[9, 0] = new Block(Colors.Green);
        }
    }
}
