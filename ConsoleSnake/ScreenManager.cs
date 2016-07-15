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
        
        int numberOfLines = 22;
        int numberOfComluns = 22;
        internal void Draw(Snake snake, Food food)
        {
            Console.SetCursorPosition(0, 0);
            

            for (int lineIndex = 0; lineIndex <= numberOfLines; lineIndex++)
            {
                for (int columnIndex = 0; columnIndex <= numberOfComluns; columnIndex++)
                {
                    
                    if(lineIndex == 0 || lineIndex == 22)
                    {
                        Console.Write("-");
                    }
                    else if(columnIndex == 0 || columnIndex == 22)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                   
                }

                Console.Write(Environment.NewLine);

            }
            

            // Här kommer man behöva vara smart ... Det kommer inte blir enkelt att rita detta när man bara kan rita i ett lager ...
            //Console.Write("Snake flyttar {0} ", snake.Direction.ToString());

            // varför tar vi inte bara bort alla dina ritsaker och lägger en vägg istället och låter markören vara snake ?
        }

       
        internal void Clear()
        {
            Console.Clear();
        }
    }
}
