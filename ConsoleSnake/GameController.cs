using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;

namespace ConsoleSnake
{
    class GameController
    {
        const int _speed = 150;
        public bool _running = false;
        ScreenManager _screenManager;
        Snake _snake;
        Food _food;
        ScoreKeeper _scoreKeeper;
        bool _isPaused = false;
       
        public GameController()
        {
            _screenManager = new ScreenManager();
            _snake = new Snake();
            _food = new Food();
            _scoreKeeper = new ScoreKeeper();
            
        }

        // Här borde man kunna bryta loopen och hantera loopen på ett bättre och tydligare sätt ...
        void Loop()
        {
            

            Console.Title = "Snake";
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
               
                _snake.MoveSnake();
                SnakeOnSnakeCollision();
                CheckGridCollision();
                CheckFoodCollision();
                

                _screenManager.Draw(_snake, _food, _scoreKeeper);
                Thread.Sleep(_speed);
            }
        }
        private void SnakeOnSnakeCollision()
        {
            for (int i = 1; i < _snake.Positions.Count; i++)
            {
                if (_snake.Positions[i].X == _snake.HeadPosition.X && _snake.Positions[i].Y == _snake.HeadPosition.Y)
                {
                    _screenManager.GameOver(_scoreKeeper.CurrentScore);
                    _running = false;
                }
                    
            }

        }


        private void CheckFoodCollision()
        {
            for (int i = 1; i<_snake.Positions.Count; i++)
            {
                if (_snake.Positions[i].X == _food.XPosition && _snake.Positions[i].Y == _food.YPostion)
                {
                    _food.MakeNewFood();
                }
                  
            }
            
            if (_snake.HeadPosition.X == _food.XPosition && _snake.HeadPosition.Y == _food.YPostion)
            {
                _food.MakeNewFood();
                _snake.Grow();
                _scoreKeeper.CurrentScore++;
                
            }
        }


        // Denna kanske skulle kunna ligga inne i grid-klassen?
        private void CheckGridCollision()
        {
            if (_snake.HeadPosition.X < Grid.StartX || _snake.HeadPosition.X > Grid.EndX || _snake.HeadPosition.Y < Grid.StartY || _snake.HeadPosition.Y > Grid.EndY)
            {
                _running = false;
                _screenManager.GameOver(_scoreKeeper.CurrentScore);
            }
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
