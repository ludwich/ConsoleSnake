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
    }
    enum Direction
    {
        Right,
        Left,
        Up,
        Down

    }
}
