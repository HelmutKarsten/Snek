using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snek
{
    class Food
    {
        int growthFactor;
        int scoreFactor;
        char shape;
        int posX;
        int posY;

        Random random = new Random();

        public Food(int type)
        {
            this.growthFactor = 1;
            this.scoreFactor = getScoreFactor(type);
            this.shape = getShape(type);
        }

        public int getScoreFactor(int type)
        {
            int score = 10;
            
            if(type == 1)
            {
              score = 80;
            }
          
            return score;
        }

        public char getShape(int type)
        {
            char shape = '*';
            
            if (type == 1)
            {
                shape = '#';
            }
            
            return shape;
        }

        public void setPosX()
        {
            posX = random.Next(80);
        }
        
        public int getPosX()
        {
            setPosX();

            return posX;
        }

        public void setPosY()
        {
            posY = random.Next(40);
        }

        public int getPosY()
        {
            setPosY();

            return posY;
        }
    }
}
