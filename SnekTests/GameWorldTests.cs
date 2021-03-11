using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snek;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snek.Tests
{
    [TestClass()]
    public class GameWorldTests
    {
        [TestMethod()]
        public void CreateFoodTest()
        {
            GameWorld world = new GameWorld(5, 8, 10);
            Food apple = world.CreateFood();
            Position p = world.RandomPosition();

            Assert.AreEqual(apple.Body, 'o');
            Assert.AreEqual(apple.P, p);
        }

        [TestMethod()]
        public void ResetTest()
        {
            GameWorld world = new GameWorld(20, 30, 10);
            Position pos = new Position(3, 3);
            Player p1 = new Player(pos, Direction.Left, '*');
            world.Reset(p1);
            Player p2 = new Player(pos, Direction.Left, '¤');
            Player p3 = new Player(pos, Direction.None, '*');

            Assert.AreNotEqual(p1.P, p2.P);
            Assert.AreNotEqual(p1.Dir, p2.Dir);
            Assert.AreEqual(p1.Body, p2.Body);
            Assert.AreEqual(p1.Dir, p3.Dir);
        }

        [TestMethod()]
        public void RandomPositionTest()
        {
            GameWorld world = new GameWorld(5, 8, 10);
            Position p = world.RandomPosition();

            Assert.AreEqual(world.RandomPosition(), p);
        }
    }
}