using System;

namespace ConsoleSnake
{
    internal class ScreenManager
    {
        int _numberOfLines = 22;
        int _numberOfComluns = 22;
     
        internal void Draw(Snake snake, Food food, ScoreKeeper scoreKeeper)
        {
 
            Console.SetCursorPosition(0, 0);
            Console.Write("Score : " + scoreKeeper.CurrentScore);

            for (int lineIndex = 0; lineIndex <= _numberOfLines; lineIndex++)
            {
                for (int columnIndex = 0; columnIndex <= _numberOfComluns; columnIndex++)
                {
                    // Topp och botten-raden är griden
                    if (lineIndex == Grid.StartX || lineIndex == Grid.EndX)
                    {
                        Console.Write("—");
                    }
                    // Höger och vänster kolumen är grid
                    else if (columnIndex == Grid.StartY || columnIndex == Grid.EndY)
                    {
                        Console.Write("|");
                    }
                    // Om det är maskposition
                    else if (snake.Positions[0].X == lineIndex && snake.Positions[0].Y == columnIndex)
                    {
                        //Ja men ska vi ens ge oss in med det här ? 
                        // kollar lite på hur man ska lagra förra pos och det vore nog enklast med en multidim array
                        // lagar både x och y och sen lagar vi i=0;points>oldBody;i++ och skirver ut på gamla positionen
                        // hur menar du att man ska göra det enklare ?=

                        Console.Write("X");
                    }
                    else if(snake.Positions.Exists(p => p.X==lineIndex && p.Y==columnIndex && !p.Equals(snake.Positions[0])))
                    {
                        Console.Write("x");
                    }
                    else if (food.XPosition == lineIndex && food.YPostion == columnIndex)
                    {
                        Console.Write("F");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                Console.Write(Environment.NewLine);
            }
        }

        internal void Clear()
        {
            Console.Clear();
        }

        public void GameOver()
        {
            Console.Clear();
            Console.WriteLine("You died!");
            Console.ReadKey();
        }

        public void Pause()
        {


            Console.WriteLine("                    `,:::,.                     ");
            Console.WriteLine("               `:::::::::::::,                  ");
            Console.WriteLine("           .;;;;;;;;;;;;;;;;;;;;;:              ");
            Console.WriteLine("          ;;;;;;;''':,.,:;''';;;;;;`            ");
            Console.WriteLine("       `;;;;'',..```````````...'';;;;:          ");
            Console.WriteLine("       ;;;;''..```````````````..,';;;;,         ");
            Console.WriteLine("    .;;;':.```                ````..'';;;       ");
            Console.WriteLine("    ;;;''.``                   ````.,';;;`      ");
            Console.WriteLine("   ;;;',.``                      ```..'';;`     ");
            Console.WriteLine("  `;;''.``     ::;;:     ;;''';   ```.;';;;     ");
            Console.WriteLine("  ;;'':.`      :;;;:     ;'''''    ``..'';;     ");
            Console.WriteLine("  ;;''.``      :;;;;     ;''+''    ```.+';;     ");
            Console.WriteLine(" :''':.``      ;;'';     ;++#+'     ```.''';    ");
            Console.WriteLine(" ;''',.``      ;''';     ;+##+'     ```.''''    ");
            Console.WriteLine("  '''+.```     '+++'     ;++++'    ```.+'''.    ");
            Console.WriteLine("  '''',.```    '+++'     ;'++''    ```.+'''     ");
            Console.WriteLine("  ,'''+.```    ''+''     ;'++';   ```.,''''     ");
            Console.WriteLine("   '''+..```   '''';     ;'''';   ```.+''',     ");
            Console.WriteLine("   ''''+.````                    ```.:+'''      ");
            Console.WriteLine("    '''+:.```                   ```..+''';      ");
            Console.WriteLine("    ''''+..````                ```..+''''       ");
            Console.WriteLine("      :''''+,..````````````````..++''''         ");
            Console.WriteLine("       ;''''++...````````````..:++''''          ");
            Console.WriteLine("        :''''++'....`````....,++'''''           ");
            Console.WriteLine("            .''''''''''''''''''';               ");
            Console.WriteLine("              `''''''''''''''',                 ");
            Console.WriteLine("                  ;''''''''.                    ");

        }
    }
}
