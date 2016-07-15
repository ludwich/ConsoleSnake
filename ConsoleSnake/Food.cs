using System;

namespace ConsoleSnake
{
    internal class Food
    {
        public const int MaxX = 22;
        public const int MaxY = 22;
        public const int MinX = 0;
        public const int MinY = 0;

        public int XPosition;
        public int YPostion;
        public bool isFoodThere = false;

 


        public void MakeNewFood()
        {
            Random y = new Random();
            YPostion = y.Next(1, 22);
            Random x = new Random();
            XPosition = x.Next(1, 22);
            isFoodThere = true;
        }



        public Food()
        {
            if (!isFoodThere)
            {
                Random y = new Random();
                YPostion = y.Next(1, 22);
                Random x = new Random();
                XPosition = x.Next(1, 22);
                isFoodThere = true;
            }
            
            //Console.SetCursorPosition(randomFoodX, randomFoodY);
            //Console.Write("F");

        }

        public bool IsFoodThere()
        {
            return isFoodThere;
        }

       
       
    }
}