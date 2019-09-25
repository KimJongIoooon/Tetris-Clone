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
        List<int> Numbers = new List<int>();
        public Block[,] Field = new Block[10, 24];//x=9 y=23
        public int TickRate;//default 1 sec
        public Game()
        {
            TickRate = 1000; 
        }

        public void Tick()
        {
            
        }

        public void FillFieldTest() {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 24; y++)
                {
                    Field[x, y] = new Block(Colors.red);
                }

            }
            Field[0, 0] = new Block(Colors.blue);
            Field[1, 0] = new Block(Colors.green);
            Field[2, 0] = new Block(Colors.orange);
            Field[3, 0] = new Block(Colors.purple);
            Field[4, 0] = new Block(Colors.red);
            Field[5, 0] = new Block(Colors.turquoise);
            Field[6, 0] = new Block(Colors.yellow);
            Field[7, 0] = new Block(Colors.green);
            Field[8, 0] = new Block(Colors.blue);
            Field[9, 0] = new Block(Colors.green);
            Field[2, 13].Filled = false;
            Field[4, 23].Filled = false;
            Field[1, 16].Filled = false;
            Field[4, 6].Filled = false;

        }
    }
}
