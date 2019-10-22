using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace ProofOfConcept
{
    public enum Colors { Turquoise, Blue, Orange, Yellow, Green, Purple, Red };
    public enum Directions { Left, Right, Up, Down };
    
    class Game
    {
        
        
        bool _started = false;
        List<int> Numbers = new List<int>();
        private Block[,] _field = new Block[10, 24];
        private System.Windows.Forms.Timer _dropTimer;
        public int TickRate = 1000;//default 1 sec
        public Tetramino _activeTetramino = new Tetramino(5, 1);

        public bool Started
        {
            get { return _started; }
        }
        
        
        public void Rotate(Directions direction)
        {
            if(direction == Directions.Left)
            {
                _activeTetramino.Rotate(Directions.Left);
            }
            if (direction == Directions.Right)
            {
                _activeTetramino.Rotate(Directions.Right);
            }

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
        public void Move(Directions direction)
        {
            bool failed = false;
            int moveY = 0;
            if (direction == Directions.Down)
            {
                moveY = +1;
                foreach (Point point in _activeTetramino.Points)
                {
                    int X = _activeTetramino.X + point.X;
                    int newY = _activeTetramino.Y - point.Y + moveY;
                    try
                    {
                        if (Field[X, newY].Filled)
                        {
                            failed = true;
                            _dropTimer.Start();
                            break;
                        }
                    }
                    catch
                    {
                        failed = true;
                        _dropTimer.Start();
                        break;
                    }

                }
            }

            int moveX = 0;
            if (direction == Directions.Left || direction == Directions.Right)
            {
                if (direction == Directions.Left)
                {
                    moveX = -1;
                }
                else if (direction == Directions.Right)
                {
                    moveX = 1;
                }

                foreach (Point point in _activeTetramino.Points)
                {
                    int newX = _activeTetramino.X + point.X + moveX;
                    int Y = _activeTetramino.Y - point.Y;
                    try
                    {
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
            }

            if (!failed)
            {
                _activeTetramino.X = _activeTetramino.X + moveX;
                _activeTetramino.Y = _activeTetramino.Y + moveY;
                if(direction == Directions.Down)
                {
                    _dropTimer.Stop();
                }
            }
            
        }
        public void Drop()
        {
            for (int Y = _activeTetramino.Y; Y <= 24; Y++)
            {
                bool Failed = false;
                foreach (Point point in _activeTetramino.Points)
                {
                    int X = _activeTetramino.X + point.X;
                    int newY = Y - point.Y;
                    try
                    {
                        if (Field[X, newY].Filled)
                        {
                            Failed = true;
                            _dropTimer.Start();
                            break;
                        }
                    }
                    catch
                    {
                        Failed = true;
                        _dropTimer.Start();
                        break;
                    }

                }

                if (Failed)
                {
                    _activeTetramino.Y = Y-1;
                    AddBlockToField();
                    RemoveFullRows();
                    NewActiveTetramino();
                    break;
                }
            }   
            _dropTimer.Stop();

        }
        private void RemoveFullRows()
        {
            //Loops through the rows, the _field is inverted so we start at 23 to begin at the bottom.
            for (int Row = 23; Row >= 0; Row--)
            {
                bool isFullRow = true;//asume the row is full at start.
                //loops through all the blocks in the row
                for (int Block = 0; Block <= 9; Block++)
                {
                    if (!_field[Block, Row].Filled)//if a block is empty
                    {
                        isFullRow = false;
                        break;
                    }    

                }
                if (isFullRow)
                {
                    //Loops through all the rows from the row that is full to the top.
                    for (int newrow = Row; newrow >= 0; newrow--)
                    {
                        //Loops through the blocks in the row.
                        for (int i = 0; i <= 9; i++)
                        {
                            if(newrow != 0)
                            {
                                //Not the top row
                                _field[i, newrow] = _field[i, newrow - 1];//Copy all the blocks in the row above.
                            }
                            else
                            {
                                //The top row.
                                _field[i, newrow] = new Block();//Add empty blocks to the row.
                            }
                        }
                    }
                    //The full row is now overridden by the next row so we will have to check it again.
                    Row++;
                }
            }
        }
        private void AddBlockToField()
        {
            //Removes Block from field.
            foreach (Point point in _activeTetramino.Points)//Loop trough each point in the List<point> Points
            {
                //the Tetramino has a X and a Y coordinate. 
                //The coordinates of the blocks relative to the Tetramino are inside the List<point> Points
                int x = _activeTetramino.X + point.X;
                int y = _activeTetramino.Y - point.Y;
                //Add tetramino block to the field.
                _field[x, y].Filled = true;//Set block to filled.
                _field[x, y].Color = _activeTetramino.Color;//set the color.
            }
        }

        private void NewActiveTetramino()
        {
            //new _activetramino;
            _activeTetramino = new Tetramino(5, 1);
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

        public Game(System.Windows.Forms.Timer DropTimer)
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

            //Assign Droptimer
            _dropTimer = DropTimer;
        }

        public void Tick()
        {
            Move(Directions.Down);
            
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
