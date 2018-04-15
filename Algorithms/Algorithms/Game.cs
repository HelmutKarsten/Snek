using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Game
    {
        Move Snek = new Move();
        ConsoleKeyInfo cki;

        public void runSnek()
        {

            while (true)
            {
                // Check whether the user did some input
                if (Console.KeyAvailable)
                {
                    // User input - react to the users input

                    cki = Console.ReadKey();

                    int passer = passDirectionChange(cki);
                    if (passer != 100)
                    {
                        Snek.validateDirection(passer);
                    }
                    else
                    {
                        break;
                    }


                }
                else
                {
                    // No user input - the gaming loop does a time step

                    // Move according to the currrent user symbol speed
                    Snek.changeCoordinates();
                    Console.Write(Snek.getCoordinate()[0] + ", ");
                    Console.WriteLine(Snek.getCoordinate()[1]);
                    // Wait some time
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }

        private int passDirectionChange(ConsoleKeyInfo pry)
        {
            if (pry.Key == ConsoleKey.UpArrow)
            {
                return 0;
            }

            if (pry.Key == ConsoleKey.DownArrow)
            {
                return 1;
            }

            if (pry.Key == ConsoleKey.LeftArrow)
            {
                return 2;
            }

            if (pry.Key == ConsoleKey.RightArrow)
            {
                return 3;
            }

            if (pry.Key == ConsoleKey.X)
            {
                return 100;
            }

            return 100;
        }
    }
}
