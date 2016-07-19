using System;
using System.Collections.Generic;

namespace ConsoleSnake
{
    internal class Food
    {
        public int XPosition;
        public int YPostion;
        Snake _snake;

        public void MakeNewFood()
        {
            Random y = new Random();
            YPostion = y.Next(Grid.StartY + 1, Grid.EndY - 1);
            Random x = new Random();
            XPosition = x.Next(Grid.StartX + 1, Grid.EndX - 1);
            CheckBodyWhenFoodSpawn(XPosition, YPostion);
            
            if (bodyIsThere)
            {
                MakeNewFood();
                bodyIsThere = false;
            }
                
        }
        public bool bodyIsThere = false;

        public void CheckBodyWhenFoodSpawn(int foodX, int foodY)
        {
            List<Position> foodSpot = new List<Position>();
            foodSpot.Add(new Position(foodX, foodY));


            if (_snake.Positions.Contains(new Position(foodX, foodY)))
            {
                bodyIsThere = true;
            }
        }

        public Food(Snake _snake)
        {
            this._snake = _snake;

            MakeNewFood();
        }
    }
}