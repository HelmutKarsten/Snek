using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms
{
    class Move
    {
        private enum direction
        {
            up, down, left, right
        }
        private direction directionOfSnek;
        private int maxX;
        private int maxY;
        int[] coordinate = { 0, 0 };

        public Move(int max_X, int max_Y)
        {
            directionOfSnek = direction.right;
            coordinate[0] = 40;
            coordinate[1] = 40;
            maxX = max_X;
            maxY = max_Y;
        }
        public void changeCoordinates()
        {
            switch (directionOfSnek)
            {
                case direction.up:
                        coordinate[1] = coordinate[1] - 1;
                        break;
                case direction.down:
                        coordinate[1] = coordinate[1] + 1;
                        break;
                case direction.right:
                        coordinate[0] = coordinate[0] + 1;
                        break;
                case direction.left:
                        coordinate[0] = coordinate[0] - 1;
                        break;
            }
        }
        public void changeCoordinatesAtRim()
        {
            if (coordinate[0] == maxX)
            {
                coordinate[0] = 0;
            }
            if (coordinate[0] < 0)
            {
                coordinate[0] = maxX;
            }
            if (coordinate[1] == maxY)
            {
                coordinate[1] = 0;
            }
            if (coordinate[1] < 0)
            {
                coordinate[1] = maxY;
            }
        }
        public int[] getCoordinate
        {
            get
            {
                return coordinate;
            }
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
        private bool valUpDownDirection(direction Dir)
        {
            return (Dir == direction.up || Dir == direction.down);
        }
        private bool valLeftRightDirection(direction Dir)
        {
            return (Dir == direction.left || Dir == direction.right);
        }
    }
}
