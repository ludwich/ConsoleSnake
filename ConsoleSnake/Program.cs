﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    class Program
    {
        
        static void Main(string[] args)
        {
            GameController controller = new GameController();
            controller.Run();
        }
    }
}
