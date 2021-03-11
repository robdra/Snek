using System;
using System.Collections.Generic;
using System.Text;



namespace Snek
{
    public abstract class GameObject
    {
        public Position P { get; set; }

        public GameObject(Position p)
        {
            P = p;
        }

        public abstract void Update();

    }
}