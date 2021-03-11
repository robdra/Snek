using System;
using System.Collections.Generic;
using System.Text;

namespace Snek
{
    class Wall : GameObject, IRenderable
    {
        public char Body { get; set; }

        public Wall(Position p, char b) : base(p)
        {
            Body = b;
        }

        public override void Update()
        {

        }
    }
}
