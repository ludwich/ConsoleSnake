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

        void Loop()
        {
            while (_running)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(false).Key;

                    if (key == ConsoleKey.UpArrow)
                    {
                        _snake.Direction = 1;
                    }
                    else if (key == ConsoleKey.DownArrow)
                    {
                        _snake.Direction = 2;
                    }
                    else if (key == ConsoleKey.Spacebar)
                    {
                        _running = false;
                        Pause();
                    }
                }

                _screenManager.Draw(_snake, new Food());
                Thread.Sleep(500);
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
