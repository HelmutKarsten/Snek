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
            Console.Clear();
            WriteMenueText();
        }

        public void AddToIterator()
        {
            Iterator++;
            CheckRimCaseBottom(NumberOfMenueItems - 1, Iterator);
        }

        public void SubstractFromIterator()
        {
            Iterator--;
            CheckRimCaseTop(Iterator);
        }

        public int GetIterator()
        {
            return Iterator;
        }


        private void WriteSingleMenueItem(string menueItem, ConsoleColor consoleColor)
        {
            Console.BackgroundColor = consoleColor;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(menueItem);
            Console.BackgroundColor = ConsoleColor.Black;
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

        // --- Rim Cases --- //

        private void CheckRimCaseTop(int IteratingInt)
        {
            if (CompareTwoIntegers(0, IteratingInt))
            {
                Iterator = NumberOfMenueItems - 1;
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

        // --- Rim Cases --- //
    }
}
