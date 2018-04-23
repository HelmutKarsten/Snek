using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek
{
    class genericMenue
    {
        string[] MenueItems;
        int Iterator;
        int NumberOfMenueItems;

        public genericMenue(string[] ItemList)
        {
            this.MenueItems = ItemList;
            this.NumberOfMenueItems = MenueItems.Length;
            this.Iterator = 0;
        }

        public void runMenue()
        {
            WriteMenueText();
            Console.ReadKey();
        }

        private void WriteSingleMenueItem(string menueItem, ConsoleColor consoleColor)
        {
            Console.BackgroundColor = consoleColor;
            Console.WriteLine(menueItem);
        }

        private void WriteMenueText()
        {
            for (int i = 0; i <= NumberOfMenueItems - 1; i++)
            {
                if (i == Iterator)
                {
                    WriteSingleMenueItem(MenueItems[i], ConsoleColor.DarkRed);
                }
                else
                {
                    WriteSingleMenueItem(MenueItems[i], ConsoleColor.Black);
                }
            }
        }

        private void menueIterator(ConsoleKeyInfo cki, int ArrayLength)
        {

            if (cki.Key == ConsoleKey.DownArrow)
            {
                Iterator++;
                CheckRimCaseBottom(NumberOfMenueItems, Iterator);
            }
            if (cki.Key == ConsoleKey.UpArrow)
            {
                Iterator--;
                CheckRimCaseTop(0, Iterator);
            }

            if (cki.Key == ConsoleKey.Enter)
            {
            }
        }

        private void CheckRimCaseTop(int RimCase, int IteratingInt)
        {
            if (CompareTwoIntegers(RimCase, IteratingInt))
            {
                Iterator = NumberOfMenueItems;
            }
        }

        private void CheckRimCaseBottom(int RimCase, int IteratingInt)
        {
            if (CompareTwoIntegers(IteratingInt, RimCase))
            {
                Iterator = 0;
            }
        }

        private Boolean CompareTwoIntegers(int FirstInt, int SecondInt)
        {
            if (FirstInt > SecondInt)
            {
                return true;
            }

            return false;
        }
    }
}
