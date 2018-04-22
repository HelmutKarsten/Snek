using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek
{
    class Menue
    {
        ConsoleKeyInfo cki;
        int menueItem;
        string[] menueText = { "Start Game", "Show Highscore", "Change Difficulty", "About", "Exit" };
        string[] menueDifficulty = { "easy", "normal", "hard", "2 ez 4 rtz", "exit"};
        Boolean exit, playGame, changeDificulty = false;
        int difficutlyOfGame = 5;

        public Menue()
        {
            menueItem = 0;
        }

        public void runMenue()
        {
            WriteMenueText(menueText);
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Selection();
                    menueIterator(cki, menueText.Length);
                    if (exit)
                    {
                        break;
                    }
                    else if (playGame)
                    {
                        Game game = new Game(difficutlyOfGame);
                        game.windowStart();
                        game.runSnek();
                        playGame = false;
                    }
                    else if (changeDificulty)
                    {
                        Console.Clear();
                        runDificultyMenue();
                        changeDificulty = false;
                    }
                    else
                    {
                        Console.Clear();
                        WriteMenueText(menueText);
                    }
                }
            }
        }

        private void runDificultyMenue ()
        {
            WriteMenueText(menueDifficulty);
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Selection();
                    menueIterator(cki, menueDifficulty.Length);
                    if (exit)
                    {
                        exit = false;
                        break;
                    }
                    else
                    {
                        Console.Clear();
                        WriteMenueText(menueDifficulty);
                    }
                }
            }
        }

        public void Selection()
        {
            cki = Console.ReadKey();
        }

        private void WriteMenueText(string[] menueInfo)
        {
            for(int i = 0; i <= menueInfo.Length - 1; i++)
            {
                WriteSingleMenueItems(i, menueInfo);
            }
        }

        private void WriteSingleMenueItems(int iterator, string[] menueInfo)
        {
            if (iterator == menueItem)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }

            Console.WriteLine(menueInfo[iterator]);

            Console.BackgroundColor = ConsoleColor.Black;
        }

        private void menueIterator(ConsoleKeyInfo cki, int ArrayLength)
        {
            
            if (cki.Key == ConsoleKey.DownArrow)
            {
                menueItem++;
                checkForRimCase(1, ArrayLength);
            }
            if (cki.Key == ConsoleKey.UpArrow)
            {
                menueItem--;
                checkForRimCase(0, ArrayLength);
            }

            if (cki.Key == ConsoleKey.Enter)
            {
                if (changeDificulty == false)
                {
                    switch (menueItem)
                    {
                        case 0:
                            playGame = true;
                            break;
                        case 2:
                            changeDificulty = true;
                            menueItem = 0;
                            Console.Clear();
                            WriteMenueText(menueDifficulty);
                            break;
                        case 4:
                            exit = true;
                            break;
                    }
                }
                else if (changeDificulty == true)
                {
                    switch (menueItem)
                    {
                        case 0:
                            difficutlyOfGame = 2;
                            break;
                        case 1:
                            difficutlyOfGame = 5;
                            break;
                        case 2:
                            difficutlyOfGame = 7;
                            break;
                        case 3:
                            difficutlyOfGame = 10;
                            break;
                        case 4:
                            exit = true;
                            Console.Clear();
                            WriteMenueText(menueText);
                            break;
                    }
                }
                
            }
        }

        private void checkForRimCase(int TopBottom, int ArrayLength)
        {
            if (TopBottom == 0 && CompairTwoItems(0, menueItem))
            {
                menueItem = ArrayLength - 1;
            }
            if (TopBottom == 1 && CompairTwoItems(menueItem, ArrayLength - 1))
            {
                menueItem = 0;
            }
        }

        private Boolean CompairTwoItems(int firstItem, int secondItem)
        {
            if (firstItem > secondItem)
            {
                return true;
            }

            return false;
        }
    }
}
