using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace ConsoleSnake
{
    class GameController
    {
        const int _speed = 150;
        bool _running = false;
        ScreenManager _screenManager;
        Snake _snake;
        Food _food;
        bool _isPaused = false;

        public GameController()
        {
            _screenManager = new ScreenManager();
            _snake = new Snake();
            _food = new Food();
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
                        case ConsoleKey.Spacebar:
                            Pause();
                            break;
                    }
                }

                MoveSnake();
                CheckGridCollision();
                CheckFoodCollision();

                _screenManager.Draw(_snake, _food);
                Thread.Sleep(_speed);
            }
        }
        private void CheckFoodCollision()
        {
            if (_snake.HeadPosition.X == _food.XPosition && _snake.HeadPosition.Y == _food.YPostion)
            {
                _food.isFoodThere = false;
                _snake.Grow();
            }
        }


        // Denna kanske skulle kunna ligga inne i grid-klassen?
        private void CheckGridCollision()
        {
            if (_snake.HeadPosition.X < Grid.MinX || _snake.HeadPosition.X > Grid.MaxX || _snake.HeadPosition.Y < Grid.MinY || _snake.HeadPosition.Y > Grid.MaxY)
            {
                _running = false;
                _screenManager.GameOver();
            }
        }

        // Borde kanske hela denna ligga i snake klassen som en MoveSnake?
        private void MoveSnake()

        {
            var newPositions = new List<Position>();

            if (_snake.Direction == Direction.Right)
            {
                newPositions.Add(new Position(_snake.HeadPosition.X, _snake.HeadPosition.Y+1));
            }
            else if (_snake.Direction == Direction.Left)
            {
                newPositions.Add(new Position(_snake.HeadPosition.X, _snake.HeadPosition.Y-1));
            }
            else if (_snake.Direction == Direction.Up)
            {
                newPositions.Add(new Position(_snake.HeadPosition.X-1, _snake.HeadPosition.Y));
            }
            else if (_snake.Direction == Direction.Down)
            {
                newPositions.Add(new Position(_snake.HeadPosition.X+1, _snake.HeadPosition.Y));
            }

            for (int i = 0; i < _snake.Positions.Count - 1; i++)
            {
                newPositions.Add(_snake.Positions[i]);
            }

            _snake.Positions = newPositions;
        }

        internal void Pause()
        {
            // Skall visa snygg pauseskärm
            Console.Clear();
            _screenManager.Pause();
            Console.ReadKey(!_isPaused);

            _isPaused = false;

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
