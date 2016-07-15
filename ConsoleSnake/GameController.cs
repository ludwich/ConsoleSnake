using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleSnake
{
    
    /// <summary>
    /// Klassen skall köra loopen. Den skall kunna pausas och avslutas. 
    /// Det är också denna som sedan skall aktivera omritning av skärmen  
    /// </summary>
    class GameController
    {
        
        bool _running = false;
        ScreenManager _screenManager;
        Snake _snake;

        public GameController()
        {
            _screenManager = new ScreenManager();
            _snake = new Snake();
        }

        // Här borde man kunna bryta loopen och hantera loopen på ett bättre och tydligare sätt ...
        void Loop()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            while (_running)
            {
                ConsoleKeyInfo keyInfo;
                while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)

                {

                    switch (keyInfo.Key)

                    {

                        case ConsoleKey.UpArrow:

                            _snake.Direction = 1;
                            _snake.YPostion--;

                            break;



                        case ConsoleKey.RightArrow:

                            // MoveHero(1, 0);

                            break;



                        case ConsoleKey.DownArrow:

                            //  MoveHero(0, 1);

                            break;



                        case ConsoleKey.LeftArrow:

                            //MoveHero(-1, 0);

                            break;




                    }

                    _screenManager.Draw(_snake, new Food());
                    Thread.Sleep(500);
                }
            }
        }

        internal void Pause()
        {
            // Skall visa snygg pauseskärm

            Console.Write("Pause. Press Space to start");
 
            do
            {
               
            } while (Console.ReadKey(true).Key != ConsoleKey.Spacebar);

            Run();
        }

        internal void Run()
        {
            _screenManager.Clear();
            _running = true;
            Loop();
        }

        internal void Start()
        {
            // Här skall vi implemntera en snygg ascii startscreen. Old school style! ;)
            // Skall finnas någon menu sak där man kan spela eller välja att titta på high score

            // Tills ovan är på plats så kör vi bara
            Run();
        }
    }
}
