using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    /// <summary>
    /// Denna klass ansvara för all ritning till skärmen
    /// </summary>
    internal class ScreenManager
    {
        internal void Draw(Snake snake, Food food)
        {
            // Här kommer man behöva vara smart ... Det kommer inte blir enkelt att rita detta när man bara kan rita i ett lager ...
            Console.Write("Snake flyttar {0} ", snake.Direction.ToString());
        }

       
        internal void Clear()
        {
            Console.Clear();
        }
    }
}
