using System;
using System.Collections.Generic;
using System.Text;

namespace Snek
{
    public class Tail : GameObject, IRenderable
    {
        public char Body { get; set; }

        public Tail(Position p, char b) : base(p)
        {
            Body = b;
        }

        public override void Update()
        {
            
        }
    }
}
