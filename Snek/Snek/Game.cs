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

        int score;
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
                    //Console.Clear();
                    Snek.moveSnakeForward();
                    checkSnekFoodRelation();
                    drawSnek();
                    drawFood();
                    drawScore();
                    // Wait some time
                    System.Threading.Thread.Sleep(speed/3);
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

        public void ShowSymbol(char symbol, int x, int y, ConsoleColor color) 
        {
            // Remember current state
            int memX = Console.CursorLeft;
            int memY = Console.CursorTop;
            ConsoleColor memColor = Console.ForegroundColor;

            ShowText(symbol, x, y, color);

            // Restore remembered state
            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            Console.ForegroundColor = memColor;
        }

        private static void ShowText(char text, int x, int y, ConsoleColor color) 
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
                if (i == 1)
                {
                    ShowSymbol('X', tupel[0], tupel[1], ConsoleColor.Black);
                }
                if (i == Snek.getLengthOfSnake() -1)
                {
                    ShowSymbol(' ', tupel[0], tupel[1], ConsoleColor.White);
                }

                continue;
            }
        }

        private void drawFood()
        {
            int[] FoodParticle = Snek.getFoodPosition();
            ShowSymbol('#', FoodParticle[0], FoodParticle[1], ConsoleColor.Black);
        }

        private void drawScore()
        {
            string StringScore = score.ToString();
            for (int i = 0; i < StringScore.Length; i++)
            {
                ShowText(StringScore[i], 0 + i, 0, ConsoleColor.Black);
            }
        }

        private int calculateScore(int intScore)
        {
            int FoodScore = Snek.getScoreFactorOfFood();
            int SpeedFactor = speed / 10;

            intScore = intScore + FoodScore * SpeedFactor;
            return intScore;
        }

        private void checkSnekFoodRelation()
        {
            int[] posSnek = Snek.getCoordinatesOfACertainPartOfTheBodyOfTheSnake(0);
            int[] posFood = Snek.getFoodPosition();
            if (posFood[0] == posSnek[0] && posFood[1] == posSnek[1])
            {
                Snek.letSnekGrow();
                Snek.setFoodPosition();
                score = calculateScore(score);
            }
        }
    }
}
