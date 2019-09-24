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
        public Block[,] Field = new Block[9, 23];//x=9 y=23
        public int TickRate;//default 1 sec
        public Game()
        {
            TickRate = 1000; 
        }

        public void Tick()
        {
            
        }

        public void FillFieldTest() {
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 23; y++)
                {
                    Field[x, y] = new Block(Colors.red);
                }

            }
            Field[0, 0] = new Block(Colors.purple);
            Field[1, 9] = new Block(Colors.blue);
            Field[2, 4] = new Block(Colors.yellow);
            Field[3, 6] = new Block(Colors.green);

        }
    }
}
