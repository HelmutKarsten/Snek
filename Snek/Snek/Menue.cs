using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek
{
    class Menue
    {
        genericMenue MainMenue = new genericMenue(menueText);
        genericMenue DifficultyMenue = new genericMenue(menueDifficulty);
        ConsoleKeyInfo cki;
        int menueItem;
        static string[] menueText = { "Start Game", "Show Highscore", "Change Difficulty", "About", "Exit" };
        static string[] menueDifficulty = { "easy", "normal", "hard", "2 ez 4 rtz", "exit"};
        Boolean exit, playGame, changeDificulty = false;
        int difficutlyOfGame = 5;

        public Menue()
        {
            menueItem = 0;
        }

        public void runMenue()
        {
            MainMenue.runMenue();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Selection();
                    MainMenueIterator(cki);
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
                        DifficultyMenue.runMenue();
                        while (true)
                        {
                            if (Console.KeyAvailable)
                            {
                                Selection();
                                DifficultyMenueIterator(cki);
                                if (exit)
                                {
                                    changeDificulty = false;
                                    exit = false;
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    DifficultyMenue.runMenue();
                                }
                            }
                        }
                        
                    }
                    else
                    {
                        //WriteMenueText(menueText);
                        MainMenue.runMenue();
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

        private void MainMenueIterator(ConsoleKeyInfo cki)
        {

            UpDownMechanics(cki, MainMenue);

            if (cki.Key == ConsoleKey.Enter)
            {  
                switch (MainMenue.GetIterator())
                {
                    case 0:
                        playGame = true;
                        break;
                    case 2:
                        changeDificulty = true;
                        break;
                    case 4:
                        exit = true;
                        break;
                }
            }
        }

        private void DifficultyMenueIterator(ConsoleKeyInfo cki)
        {
            UpDownMechanics(cki, DifficultyMenue);

            if (cki.Key == ConsoleKey.Enter)
            {
                exit = true;
                switch (DifficultyMenue.GetIterator())
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
                        break;
                }
            }
        }

        private void UpDownMechanics(ConsoleKeyInfo cki, genericMenue Menue)
        {
            if (cki.Key == ConsoleKey.DownArrow)
            {
                Menue.AddToIterator();
            }
            if (cki.Key == ConsoleKey.UpArrow)
            {
                Menue.SubstractFromIterator();
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
