using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;

namespace ConsoleSnake
{
    internal class Snake
    {
        public Direction Direction = Direction.Right;
        public List<Position> Positions =
            new List<Position>()
            {
                new Position(10, 10),
                new Position(10, 10),
                new Position(10, 10)
            };

        public Position HeadPosition
        {
            get
            {
                return Positions[0];
            }
        }

        internal void Grow()
        {
            Positions.Add(new Position(Positions.Last().X, Positions.Last().Y));
        }
        public void MoveSnake()

        {
            var newPositions = new List<Position>();

            if (Direction == Direction.Right)
            {
                newPositions.Add(new Position(HeadPosition.X, HeadPosition.Y + 1));
            }
            else if (Direction == Direction.Left)
            {
                newPositions.Add(new Position(HeadPosition.X, HeadPosition.Y - 1));
            }
            else if (Direction == Direction.Up)
            {
                newPositions.Add(new Position(HeadPosition.X - 1, HeadPosition.Y));
            }
            else if (Direction == Direction.Down)
            {
                newPositions.Add(new Position(HeadPosition.X + 1, HeadPosition.Y));
            }

            for (int i = 0; i < Positions.Count - 1; i++)
            {
                newPositions.Add(Positions[i]);
            }

            Positions = newPositions;
        }

        public void SnakeOnSnakeCollision()
        {
            List<Position> BodyParts = new List<Position>();
            for (int i = 1; i < Positions.Count; i++)
            {
                if (Positions[i] == Positions[0])
                {
                    ScreenManager death = new ScreenManager();
                    death.GameOver();
                }
            }
                      
        }
    


   


    }
    // Hut lägger man denna? Borde den ligga i egen klass eller kanske som en del av Snake-klassen? 
    // Det skulle nog vara snyggare. Det skulle då bli Snake.Direction = 
    enum Direction
    {
        Right,
        Left,
        Up,
        Down

    }
}
