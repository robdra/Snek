using System;
using System.Collections.Generic;
using System.Text;

namespace Snek
{
    class ConsoleRenderer
    {
        public GameWorld World { get; set; }

        public ConsoleRenderer(GameWorld gameWorld)
        {
            World = gameWorld;
            Console.SetWindowSize(World.Width, World.Height);
            Console.SetBufferSize(World.Width, World.Height);
        }
        
        /// <summary>
        /// Removes the player, food and tails from the world before their new position is updated.
        /// Does not affect the walls because the walls are stationary and to avoid flickering.
        /// </summary>
        public void RenderBlank()
        {
            foreach (GameObject item in World.gameObjects)
            {
                //item as player or food instead of item as IRenderable since item as IRenderable affects the walls as well which causes flickering.
                if (item is Player || item is Food)
                {
                    Console.SetCursorPosition(item.P.X, item.P.Y);
                    Console.Write(" ");
                }
            }

            foreach (Tail item in World.tails)
            {
                if (item is IRenderable)
                {
                    Console.SetCursorPosition(item.P.X, item.P.Y);
                    Console.Write(" ");
                }
            }
        }

        /// <summary>
        /// Writes the whole world again with updated positions
        /// Also writes Highscore, Score and the steps the player has left before they die if not eating food
        /// </summary>
        public void Render()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write($"Highscore: {World.HighScore}   ");
            Console.SetCursorPosition(0, 1);
            Console.Write($"Current Score: {World.Score}   ");
            Console.SetCursorPosition(0, 2);
            Console.Write($"Steps until death: {World.Clock}   ");

            foreach (GameObject item in World.gameObjects)
            {
                if (item is IRenderable)
                {
                    Console.SetCursorPosition(item.P.X, item.P.Y);
                    Console.Write((item as IRenderable).Body);
                }

            }

            foreach (Tail item in World.tails)
            {
                if (item is IRenderable)
                {
                    Console.SetCursorPosition(item.P.X, item.P.Y);
                    Console.Write((item as IRenderable).Body);
                }

            }
        }
    }
}
