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
        public List<Point> Field = new List<Point>();
        public int TickRate;//default 1 sec
        public Game()
        {
            Field.Add(new Point(0, 0));
            Field.Add(new Point(1, 0));
            Field.Add(new Point(0, 1));
            Field.Add(new Point(0, 3));
            TickRate = 1000; 
        }

        public void Tick()
        {
            
        }
    }
}
