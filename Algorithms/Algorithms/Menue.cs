using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Menue
    {
        ConsoleKeyInfo cki;
        int menueItem;

        public Menue()
        {
            menueItem = 0;
        }

        public void Selection()
        {
            cki = Console.ReadKey();
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
        }

        private void checkForRimCase(int TopBottom)
        {
            if (TopBottom == 0 && CompairTwoItems(0, menueItem))
            {
                menueItem = 4;
            }
            if (TopBottom == 1 && CompairTwoItems(menueItem, 5))
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
