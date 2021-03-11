using System;
using System.Collections.Generic;
using System.Text;



namespace Snek
{
    public class Player : GameObject, IRenderable, IMovable  
    {
        public Direction Dir { get; set; }
        public char Body { get; set; }

        public Player(Position p, Direction d, char h) : base (p)
        {
            Dir = d;
            Body = h;
        }

        /// <summary>
        /// Gives the player a new position based on the direction
        /// Changes the body based on direction as well
        /// </summary>
        public override void Update()  
        {
            switch (Dir)
            {
                case Direction.Down:
                    P = new Position(P.X, P.Y + 1);
                    Body = 'v';
                    break;
                case Direction.Up:
                    P = new Position(P.X, P.Y - 1);
                    Body = '^';
                    break;
                case Direction.Left:
                    P = new Position(P.X - 1, P.Y);
                    Body = '<';
                    break;
                case Direction.Right:
                    P = new Position(P.X + 1, P.Y);
                    Body = '>';
                    break;
                case Direction.None:
                    break;
                default:
                    break;
            }
        }
    }
}
