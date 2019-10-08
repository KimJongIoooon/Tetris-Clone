using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ProofOfConcept
{
    class Block
    {
        public bool Filled = false;
        public Colors Color;
        public Block(Colors color)
        {
            Color = color;
            Filled = true;
        }

        public Block()
        {
        }

        public override string ToString()
        {
            if (Filled)
            {
                return Color.ToString();
            } else
            {
                return "empty";
            }
            
        }
    }
}
