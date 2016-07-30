using System;
using System.Threading;
using ConsoleSnake.Model;

namespace ConsoleSnake
{
    class GameController
    {
        const int Speed = 150;
        private bool _running = false;
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

        private void Loop()
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
                            if (_snake.Direction != Direction.Down)
                            {
                                _snake.Direction = Direction.Up;
                            }

                            break;
                        case ConsoleKey.RightArrow:
                            if (_snake.Direction != Direction.Left)
                            {
                                _snake.Direction = Direction.Right;
                            }

                            break;
                        case ConsoleKey.DownArrow:
                            if (_snake.Direction != Direction.Up)
                            {
                                _snake.Direction = Direction.Down;
                            }

                            break;
                        case ConsoleKey.LeftArrow:
                            if (_snake.Direction != Direction.Right)
                            {
                                _snake.Direction = Direction.Left;
                            }

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
                Thread.Sleep(Speed);
            }
        }
        private void SnakeOnSnakeCollision()
        {
            for (int i = 1; i < _snake.Positions.Count; i++)
            {
                if (_snake.Positions[i].X == _snake.HeadPosition.X && _snake.Positions[i].Y == _snake.HeadPosition.Y)
                {
                    _running = false;
                    GameOver();
                }
            }
        }


        private void CheckFoodCollision()
        {
            for (int i = 1; i < _snake.Positions.Count; i++)
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


        private void CheckGridCollision()
        {
            if (_snake.HeadPosition.X <= Grid.StartX || _snake.HeadPosition.X >= Grid.EndX || _snake.HeadPosition.Y <= Grid.StartY || _snake.HeadPosition.Y >= Grid.EndY)
            {
                _running = false;
                GameOver();
            }
        }

        private void Pause()
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

        private void GameOver()
        {
            _screenManager.ShowGameOver(_scoreKeeper.CurrentScore);

            if(_scoreKeeper.IsNewHighScore())
            {
                var name = _screenManager.ReadPlayName();
                _scoreKeeper.AddNewHighScore(new HighScore(name, _scoreKeeper.CurrentScore));
            }

            _screenManager.ShowHighScoreList(_scoreKeeper.GetHighScores());
            Reset();
            Run();
        }

        private void Reset()
        {
            _snake.ResetPositions();
            _scoreKeeper.CurrentScore = 0;
        }
    }
}
