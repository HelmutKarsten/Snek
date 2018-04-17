using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek
{
    class Field
    {
        int consoleSizeX = 150;
        int consoleSizeY = 70;
        Snek sneki = new Snek();

        public void windowStart()
        {
            Food food = new Food(0);
            
            Console.Title = "SNEK";
            Console.SetWindowSize(consoleSizeX, consoleSizeY);
            Console.SetBufferSize(consoleSizeX, consoleSizeY);
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();
        }

        

        // ---------------------------------------------------------

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

        public void windowClose()
        {
            Console.ReadKey();
        }

        public void drawSnek()
        {
            for (int i = 0; i < sneki.getSnakeLength(); i++)
            {
                int[] tupel = sneki.getCorpusPart(i);
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

    }
}
