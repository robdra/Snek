using System;
using System.Collections.Generic;
using System.Text;

namespace Snek
{
    public struct Position
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Position operator -(Position p1, Position p2)
        {
            return new Position(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static Position operator +(Position p1, Position p2)
        {
            return new Position(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static bool operator !=(Position a, Position b) => !Equals(a, b);
        public static bool operator ==(Position a, Position b) => Equals(a, b);

    }
}
