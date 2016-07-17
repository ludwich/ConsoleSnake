using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Reflection;

namespace ConsoleSnake
{
    internal class Snake
    {

        public Snake()
        {
         
        }

        

        public void Movement(int x, int y)
        {
            
        }
     
        public Direction Direction = Direction.Right;
        public int XPosition = 10;
        public int YPostion = 10;
        
    }

    // Hut lägger man denna? Borde den ligga i egen klass eller kanske som en del av Snake-klassen? 
    // Det skulle nog vara snyggare. Det skulle då bli Snake.Direction = 
    enum Direction
    {
        Right,
        Left,
        Up,
        Down
    }
}