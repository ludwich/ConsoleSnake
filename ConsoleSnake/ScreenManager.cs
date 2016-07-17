﻿using System;
using System.Collections.Generic;

namespace ConsoleSnake
{
    /// <summary>
    /// Denna klass ansvara för all ritning till skärmen
    /// </summary>
    internal class ScreenManager
    {
        
        int numberOfLines = 22;
        int numberOfComluns = 22;
        static int sizeOfTheSnake = 0;
        public List<Tuple<int, int>> _oldSnake = new List<Tuple<int, int>>(20);






        internal void Draw(Snake snake, Food food)
        {
            Console.SetCursorPosition(30, 10);
            Console.Write("Score : " +sizeOfTheSnake);
            Console.SetCursorPosition(30, 15);
            Console.Write(snake.XPosition + " är x " + snake.YPostion + " är y");
            _oldSnake.Insert(0, new Tuple<int, int>(snake.XPosition, snake.YPostion));



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
                        //Ja men ska vi ens ge oss in med det här ? 
                        // kollar lite på hur man ska lagra förra pos och det vore nog enklast med en multidim array
                        // lagar både x och y och sen lagar vi i=0;points>oldBody;i++ och skirver ut på gamla positionen
                        // hur menar du att man ska göra det enklare ?=
                      
                         Console.Write("X");

                        for (int i =0; i<sizeOfTheSnake;i++)
                        {
                            
                            Console.SetCursorPosition(30, 18);
                            Console.Write(_oldSnake[i].Item2.ToString());
                            Console.SetCursorPosition(30, 20);
                            Console.Write(_oldSnake[i].Item1.ToString());
                            Console.SetCursorPosition(_oldSnake[i].Item2, _oldSnake[i].Item1);
                            Console.Write("x");
                            
                        }
                        

                    }
                    else if (food.XPosition == lineIndex && food.YPostion == columnIndex && food.isFoodThere)
                    {
                      
                        Console.Write("F");
                    }
                    else if (food.XPosition == lineIndex && food.YPostion == columnIndex && !food.isFoodThere)
                    {
                        sizeOfTheSnake++;
                        food.MakeNewFood();
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
