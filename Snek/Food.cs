using System;
using System.Collections.Generic;
using System.Text;

namespace Snek
{
    public class Food : GameObject, IRenderable
    {
        public char Body { get; set; }
        public Food(Position p, char b) : base(p)
        {
            Body = b;
        }
        public override void Update()
        {

        }
    }
}
