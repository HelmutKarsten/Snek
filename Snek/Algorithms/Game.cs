using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Game
    {
        //variables
        int speed;
        Move Snek = new Move(200, 100);
        ConsoleKeyInfo cki;

        public Game(int difficultyLevel)
        {
            initializeSpeed(difficultyLevel);
        }

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
                    if (passer != 100 && passer != 99)
                    {
                        Snek.validateDirection(passer);
                    }
                    else if (passer == 99)
                    {
                        continue;
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
                    Snek.changeCoordinatesAtRim();
                    Console.Write(Snek.getCoordinate()[0] + ", ");
                    Console.WriteLine(Snek.getCoordinate()[1]);
                    // Wait some time
                    System.Threading.Thread.Sleep(speed);
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

            return 99;
        }

        private void initializeSpeed(int difficultyLevel)
        {
            speed = (11 - difficultyLevel) * 100;
        }
    }
}
