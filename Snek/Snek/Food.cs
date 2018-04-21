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
        int maxPosX, maxPosY;

        Random random = new Random();

        public Food(int type, int width, int length)
        {
            this.growthFactor = 1;
            this.scoreFactor = getScoreFactor(type);
            this.shape = getShape(type);
            this.maxPosX = width - 1;
            this.maxPosY = length - 1;
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

        public int[] getPosition()
        {
            int[] coordinate = { getPosX(), getPosY() };
            return coordinate;
        }

        public void setPosX()
        {
            posX = random.Next(maxPosX);
        }
        
        private int getPosX()
        {
            setPosX();

            return posX;
        }

        public void setPosY()
        {
            posY = random.Next(maxPosY);
        }

        private int getPosY()
        {
            setPosY();

            return posY;
        }

        public int getGrowthFactor()
        {
            return growthFactor;
        }
    }
}
