using System;
using System.Threading;
using static System.Console;

namespace Snek
{
    public enum Direction { Up, Right, Down, Left, None }

    class Program
    {
        /// <summary>
        /// Checks Console to see if a keyboard key has been pressed, if so returns it, otherwise NoName.
        /// </summary>
        static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

        static void Loop()
        {
            CursorVisible = false;
            // Initialisera spelet
            const int frameRate = 5;
            GameWorld world = new GameWorld(50, 30, 100);
            ConsoleRenderer renderer = new ConsoleRenderer(world);

            // TODO Skapa spelare och andra objekt etc. genom korrekta anrop till vår GameWorld-instans
            // ...
            Position P = world.RandomPosition();
            Player player = new Player(P, Direction.None, '¤');
            world.gameObjects.Add(player);
            Food food = world.CreateFood();
            world.gameObjects.Add(food);
            world.CreateWall(world.Width, world.Height);
            
            // Huvudloopen
            bool running = true;
            while (running)
            {
                // Kom ihåg vad klockan var i början
                DateTime before = DateTime.Now;

                // Hantera knapptryckningar från användaren
                ConsoleKey key = ReadKeyIfExists();
                switch (key)
                {
                    case ConsoleKey.Q:
                        running = false;
                        break;
                    case ConsoleKey.W:
                        if(player.Dir != Direction.Down) player.Dir = Direction.Up;
                        break;
                    case ConsoleKey.S:
                        if (player.Dir != Direction.Up) player.Dir = Direction.Down;
                        break;
                    case ConsoleKey.A:
                        if (player.Dir != Direction.Right) player.Dir = Direction.Left;
                        break;
                    case ConsoleKey.D:
                        if (player.Dir != Direction.Left) player.Dir = Direction.Right;
                        break;
                        // TODO Lägg till logik för andra knapptryckningar
                        // ...
                }

                // Uppdatera världen och rendera om
                renderer.RenderBlank();
                world.Update();
                renderer.Render();

                // Mät hur lång tid det tog
                double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
                if (frameTime > 0)
                {
                    // Vänta rätt antal millisekunder innan loopens nästa varv
                    Thread.Sleep((int)frameTime);
                }
            }
        }

        static void Main(string[] args)
        {
            // Vi kan ev. ha någon meny här, men annars börjar vi bara spelet direkt
            Loop();
        }
    }
}
