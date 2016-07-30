﻿using System;

namespace ConsoleSnake
{
    internal class Food
    {
        public int XPosition { get; private set; }
        public int YPostion { get; private set; }

        public void MakeNewFood()
        {
            Random yRandom = new Random();
            YPostion = yRandom.Next(Grid.StartY + 1, Grid.EndY - 1);
            Random xRandom = new Random();
            XPosition = xRandom.Next(Grid.StartX + 1, Grid.EndX - 1);
        }

        public Food()
        {
            MakeNewFood();
        }
    }
}