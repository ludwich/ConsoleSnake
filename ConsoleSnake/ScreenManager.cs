using System;
using System.Collections.Generic;
using ConsoleSnake.Model;
using Newtonsoft.Json;

namespace ConsoleSnake
{
    internal class ScreenManager
    {
        private const int NumberOfLines = 22;
        const int NumberOfComluns = 22;

        internal void Draw(Snake snake, Food food, ScoreKeeper scoreKeeper)
        {
            Console.SetCursorPosition(0, 0);
            Console.Write("Score : " + scoreKeeper.CurrentScore);
            Console.Write(Environment.NewLine);

            for (int lineIndex = 0; lineIndex <= NumberOfLines; lineIndex++)
            {
                for (int columnIndex = 0; columnIndex <= NumberOfComluns; columnIndex++)
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

        public void ShowGameOver(int score)
        {
            
            Console.Clear();
            Console.WriteLine("Crash! You got " + score + " points");
        }
        public string ReadPlayName()
        {
            Console.Write("Enter your Name for Highscore : ");
            return Console.ReadLine();
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

        internal void ShowHighScoreList(List<HighScore> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.Name + "\t" + item.Score);
            }

            Console.WriteLine("Click to play again");
            Console.ReadLine();
        }
    }
}
