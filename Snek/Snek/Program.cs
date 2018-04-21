using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek
{
    class Program
    {
        static void Main(string[] args)
        {
            Game field = new Game(10);
            field.windowStart();
            field.runSnek();
            
        }
    }
}
