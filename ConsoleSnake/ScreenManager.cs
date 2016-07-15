using System;

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
                    // Topp och botten-raden är griden
                    if(lineIndex == 0 || lineIndex == 22)
                    {
                        Console.Write("—");
                    }
                    // Höger och vänster kolumen är grid
                    else if(columnIndex == 0 || columnIndex == 22)
                    {
                        Console.Write("|");
                    }
                    // Om det är maskposition
                    else if(snake.XPosition == lineIndex && snake.YPostion == columnIndex)
                    {
                        Console.Write("X");
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
