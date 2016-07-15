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
        const int _speed = 350;
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
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = keyInfo = Console.ReadKey(true);
                    //while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Escape)
                    //{
                        switch (keyInfo.Key)
                        {
                            case ConsoleKey.UpArrow:
                                _snake.Direction = Direction.Up;
                                break;
                            case ConsoleKey.RightArrow:
                                _snake.Direction = Direction.Right;
                                break;
                            case ConsoleKey.DownArrow:
                                _snake.Direction = Direction.Down;
                                break;
                            case ConsoleKey.LeftArrow:
                                _snake.Direction = Direction.Left;
                                break;
                        }
                    //}
                }

                MoveSnake();
                _screenManager.Draw(_snake, new Food());
                Thread.Sleep(_speed);
            }
        }

        // Borde kanske hela denna ligga i snake klassen som en MoveSnake?
        private void MoveSnake()
        {
            if (_snake.Direction == Direction.Right)
            {
                _snake.YPostion++;
            }
            else if (_snake.Direction == Direction.Left)
            {
                _snake.YPostion--;
            }
            else if (_snake.Direction == Direction.Up)
            {
                _snake.XPosition--;
            }
            else if (_snake.Direction == Direction.Down)
            {
                _snake.XPosition++;
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
