﻿using System;

namespace ConsoleSnake
{
    internal class Food
    {
        public int XPosition;
        public int YPostion;
        Snake _snake = new Snake();

        public void MakeNewFood()
        {
            Random y = new Random();
            YPostion = y.Next(Grid.StartY + 1, Grid.EndY - 1);
            Random x = new Random();
            XPosition = x.Next(Grid.StartX + 1, Grid.EndX - 1);
            _snake.CheckBodyWhenFoodSpawn(XPosition, YPostion);
            if (_snake.bodyIsThere)
            {
                MakeNewFood();
                _snake.bodyIsThere=false;
            }
                
        }

        public Food()
        {
            MakeNewFood();
        }
    }
}