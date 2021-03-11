using System;
using System.Collections.Generic;
using System.Text;

namespace Snek
{
    public class GameWorld
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Score { get; private set; }
        public int HighScore { get; private set; }
        public int DeathClock { get; set; }
        public int Clock { get; private set; }

        private bool activated;
        private bool removeTail;
       

        public List<GameObject> gameObjects = new List<GameObject>();
        public List<Tail> tails = new List<Tail>();
        public GameWorld(int w, int h, int d)
        {
            Width = w;
            Height = h;
            DeathClock = d;
        }
        
        /// <summary>
        /// The main functionality.
        /// Is responsible for checking if the player hits a wall, a piece of food or its own tail.
        /// </summary>
        public virtual void Update()
        {
            Position foodPos = new Position();
            Position playerPos = new Position();
            int value = 0;
            int foodIndex = 0;
            
            foreach (GameObject item in gameObjects)
            {
                if (item is Player)
                {
                    playerPos = item.P;

                    foreach (GameObject itm in gameObjects)
                    {
                        if(itm is Wall)
                        {
                            if(item.P == itm.P)
                            {
                                Reset(item);
                                tails.RemoveAll(item => item is Tail);
                            }
                        }
                        //Saves the position of the food in the world and its index in the list.
                        if (itm is Food)
                        {
                            foodPos = itm.P;
                            foodIndex = value;
                        }

                        value++;
                    }

                    foreach(Tail tail in tails)
                    {
                        if(item.P == tail.P)
                        {
                            Reset(item);
                            removeTail = true;
                        }
                    }

                    if(removeTail)
                        tails.RemoveAll(item => item is Tail);

                    removeTail = false;

                    if (Clock <= 0)
                    {
                        Reset(item);
                        tails.RemoveAll(item => item is Tail);
                    }

                    if ((item as Player).Dir != Direction.None)
                        activated = true;
                    else
                        activated = false;

                    Tail t = new Tail(playerPos, 'x');
                    tails.Add(t);
                }

                item.Update(); 
            }

            //Checks if player position and food position is the same outside of the foreach loop since you cant change a list while looping through it.
            //Removes the food and adds a new one to the list if the player and food has the same positon in the world.
            //Adds one point to the score and resets the deathclock
            if (foodPos == playerPos)
            {
                Score++;
                Clock = DeathClock;
                gameObjects.RemoveAt(foodIndex);
                gameObjects.Add(CreateFood());
            }
            else
                tails.RemoveAt(0);

            if (Score > HighScore)
                HighScore = Score;

            if(activated) 
                Clock--;
            
        }

        /// <summary>
        /// Resets the position, direction, score and clock if the player dies
        /// </summary>
        /// <param name="item">The player object</param>
        public void Reset(GameObject item)
        {
            item.P = RandomPosition();
            (item as Player).Dir = Direction.None;
            (item as Player).Body = '¤';
            Score = 0;
            Clock = DeathClock;
        }

        /// <summary>
        /// Creates a piece of fod with a rnadom position
        /// </summary>
        /// <returns>A food object</returns>
        public Food CreateFood()
        {
            Position p1 = RandomPosition();
            Food apple = new Food(p1, 'o');
            return apple;
        }

        /// <summary>
        /// Makes a random position within the walls
        /// </summary>
        /// <returns>A random position</returns>
        public Position RandomPosition()
        {
            Random r1 = new Random();
            int rX = r1.Next(2, Width - 2);
            Random r2 = new Random();
            int rY = r2.Next(6, Height - 2);

            return new Position(rX, rY);
        }

        /// <summary>
        /// Creates the walls within the game world
        /// </summary>
        /// <param name="width">The width of the world</param>
        /// <param name="height">The height of the world</param>
        public void CreateWall(int width, int height)
        {
            for(int i = 1; i < width; i++)
            {
                Position p1 = new Position(i, height-1);
                Wall w1 = new Wall(p1, '#');
                gameObjects.Add(w1);

                Position p2 = new Position(i, 5);
                Wall w2 = new Wall(p2, '#');
                gameObjects.Add(w2);
            }

            for (int i = 5; i < height; i++)
            {
                Position p1 = new Position(width - 1, i);
                Wall w1 = new Wall(p1, '#');
                gameObjects.Add(w1);

                Position p2 = new Position(1, i);
                Wall w2 = new Wall(p2, '#');
                gameObjects.Add(w2);
            }
        }
    }
}
