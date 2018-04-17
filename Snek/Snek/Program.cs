using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek
{
    class Program
    {
        static void Main(string[] args)
        {
            Field field = new Field();
            Food food = new Food(0);
            field.windowStart();
            Console.WriteLine(food.getShape(0));
            field.ShowSymbol(food.getShape(1), food.getPosX(), food.getPosY(), ConsoleColor.Black);
            field.drawSnek();
            field.windowClose();
            
        }
    }
}
