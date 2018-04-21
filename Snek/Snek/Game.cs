using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek
{
    class Game
    {
        //variables
        static int consoleSizeX = 100;
        static int consoleSizeY = 50;

        int speed;

        Move Snek = new Move(consoleSizeX - 1, consoleSizeY - 1);
        ConsoleKeyInfo cki;

        public Game(int difficultyLevel)
        {
            initializeSpeed(difficultyLevel);
        }

        public void windowStart()
        {
            Console.Title = "SNEK";
            Console.SetWindowSize(consoleSizeX, consoleSizeY);
            Console.SetBufferSize(consoleSizeX, consoleSizeY);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }

        public void runSnek()
        {
            
            while (Snek.getLost() == false)
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
                    Console.Clear();
                    Snek.moveSnakeForward();
                    checkSnekFoodRelation();
                    drawSnek();
                    drawFood();
                    // Wait some time
                    System.Threading.Thread.Sleep(speed/2);
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

        public void ShowSymbol(char symbol, int x, int y, ConsoleColor color) // diese funktionen sind kackendreist kopiert
        {
            // Remember current state
            int memX = Console.CursorLeft;
            int memY = Console.CursorTop;
            ConsoleColor memColor = Console.ForegroundColor;

            ShowText(symbol, x, y, color);

            // Restore remembered state
            Console.CursorLeft = memX;
            Console.CursorTop = memY;
            Console.ForegroundColor = memColor;
        }

        private static void ShowText(char text, int x, int y, ConsoleColor color) // diese funktionen sind kackendreist kopiert
        {
            // Show symbol regarding its paramters
            Console.CursorLeft = x;
            Console.CursorTop = y;
            Console.ForegroundColor = color;
            Console.Write(text);
        }

        // .-----------------------------------------------------------


        public void drawSnek()
        {
            for (int i = 0; i < Snek.getLengthOfSnake(); i++)
            {
                int[] tupel = Snek.getCoordinatesOfACertainPartOfTheBodyOfTheSnake(i);
                if (i == 0)
                {
                    ShowSymbol('O', tupel[0], tupel[1], ConsoleColor.Black);
                }
                else
                {
                    ShowSymbol('X', tupel[0], tupel[1], ConsoleColor.Black);
                }

            }
        }

        private void drawFood()
        {
            int[] FoodParticle = Snek.getFoodPosition();
            ShowSymbol('#', FoodParticle[0], FoodParticle[1], ConsoleColor.Black);
        }

        private void checkSnekFoodRelation()
        {
            int[] posSnek = Snek.getCoordinatesOfACertainPartOfTheBodyOfTheSnake(0);
            int[] posFood = Snek.getFoodPosition();
            if (posFood[0] == posSnek[0] && posFood[1] == posSnek[1])
            {
                Snek.letSnekGrow();
                Snek.setFoodPosition();
            }
        }
    }
}
