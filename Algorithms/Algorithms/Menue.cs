using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Menue
    {
        private ConsoleKeyInfo cki;
        private int menueItem;
        private string[] menueText = { "Start Game", "Show Highscore", "About", "Exit" };
        private bool exit;
        private bool playGame = false;

        public Menue()
        {
            menueItem = 0;
        }
        public void runMenue()
        {
            WriteMenueText();
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    Selection();
                    menueIterator(cki);
                    if (exit)
                    {
                        break;
                    }
                    else if (playGame)
                    {
                        Game game = new Game(10);
                        game.runSnek();
                        playGame = false;
                    }
                    else
                    {
                        Console.Clear();
                        WriteMenueText();
                    }
                }
            }
        }
        public void Selection()
        {
            cki = Console.ReadKey();
        }
        private void WriteMenueText()
        {
            for(int i = 0; i < 4; i++)
            {
                WriteSingleMenueItems(i);
            }
        }
        private void WriteSingleMenueItems(int iterator)
        {
            if (iterator == menueItem)
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
            }
            Console.WriteLine(menueText[iterator]);
            Console.BackgroundColor = ConsoleColor.Black;
        }
        private void menueIterator(ConsoleKeyInfo cki)
        {
            if (cki.Key == ConsoleKey.DownArrow)
            {
                menueItem++;
                checkForRimCase(1);
            }
            if (cki.Key == ConsoleKey.UpArrow)
            {
                menueItem--;
                checkForRimCase(0);
            }
            if (cki.Key == ConsoleKey.Enter && menueItem == 3)
            {
                exit = true;
            }
            if (cki.Key == ConsoleKey.Enter && menueItem == 0)
            {
                playGame = true;
            }
        }
        private void checkForRimCase(int TopBottom)
        {
            if (TopBottom == 0 && CompairTwoItems(0, menueItem))
            {
                menueItem = 3;
            }
            if (TopBottom == 1 && CompairTwoItems(menueItem, 3))
            {
                menueItem = 0;
            }
        }
        private bool CompairTwoItems(int firstItem, int secondItem)
        {
            return (firstItem > secondItem);
        }
    }
}
