using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Move
    {

        enum direction
        {
            up,
            down,
            left,
            right
        }

        direction directionOfSnek;

        int[] coordinate = { 0, 0 };

        public Move()
        {
            directionOfSnek = direction.right;
            coordinate[0] = 40;
            coordinate[1] = 40;
        }

        public void changeCoordinates()
        {
            switch (directionOfSnek)
            {
                case direction.up:
                    {
                        coordinate[1] = coordinate[1] + 1;
                        break;
                    }
                case direction.down:
                    {
                        coordinate[1] = coordinate[1] - 1;
                        break;
                    }
                case direction.right:
                    {
                        coordinate[0] = coordinate[0] + 1;
                        break;
                    }
                case direction.left:
                    {
                        coordinate[0] = coordinate[0] - 1;
                        break;
                    }
            }
        }

        public int[] getCoordinate()
        {
            return coordinate;
        }


        public void validateDirection(int newDirection)
        {
            if (valUpDownDirection(directionOfSnek) && valLeftRightDirection((direction)newDirection) || valLeftRightDirection(directionOfSnek) && valUpDownDirection((direction)newDirection))
            {
                changeDirection(newDirection);
            }
        }

        private void changeDirection(int newDirection)
        {
            if (newDirection >= 0 && newDirection <= 3)
            {
                directionOfSnek = (direction)newDirection;
            }
        }

        //validators
        private Boolean valUpDownDirection(direction Dir)
        {
            if (Dir == direction.up || Dir == direction.down)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Boolean valLeftRightDirection(direction Dir)
        {
            if (Dir == direction.left || Dir == direction.right)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
