using Battleship.Logic.Services;
using Battleship.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Battleship.Logic.Tests.Models
{
    [TestClass]
    public class ShipTester
    {

        private ShipService  ship1 = new ShipService(new Position(0,0),new Position(2,0));

        private ShipService ship2 = new ShipService(new Position(4, 4), new Position(4, 3));

        private ShipService ship3 = new ShipService(new Position(4,4),new Position(4,0));

        private ShipService ship4 = new ShipService(new Position(4, 4),new Position(3, 3));

        private ShipService ship5 = new ShipService(new Position(0, 0),new Position(2, 2));

        private ShipService shipSize5Vertical = new ShipService(new Position(1,2),new Position(5,2));

        private ShipService shipSize5VerticalReverse = new ShipService(new Position(5, 2), new Position(1, 2));

        private ShipService shipSize5Horizontal = new ShipService(new Position(2, 1),new Position(2, 5));

        private ShipService shipSize5HorizontalReverse = new ShipService(new Position(2, 5),new Position(2, 1));

        private ShipService shipSize5DiagonaleRigthBot = new ShipService(new Position(1, 2),new Position(5, 6));

        private ShipService shipSize5DiagonaleLeftTop = new ShipService(new Position(5, 6), new Position(1, 2));
        
        private ShipService shipSize5DiagonaleRigthTop = new ShipService(new Position(5, 2),new Position(1, 6));

        private ShipService shipSize5DiagonaleLeftBot = new ShipService(new Position(1, 6),new Position(5, 2));

        
        private ShipService shipSize1 = new ShipService(new Position(1, 1),new Position(1, 1));

        [TestMethod]
        public void IsInGrid_WithGridSize_ThenFalse()
        {
            Assert.IsFalse(new ShipService() .IsInGrid(0));
        }

        [TestMethod]
        public void IsInGrid_WithShip1AndGridSize1_ThenFalse()
        {
            Assert.IsFalse(ship1.IsInGrid(-1));
        }

        [TestMethod]
        public void IsInGrid_WithShip2AndGridSize5_ThenTrue() 
        {
            Assert.IsTrue(ship2.IsInGrid(5));
        }

        [TestMethod]
        public void GenerationListPositions_WithEmptyShipe_ThenListNull()
        {
            ShipService shipNull = new ShipService() ;
            shipNull.GenerationListPositions();
            Assert.AreEqual(0,shipNull._Positions.Count);
        }

        [TestMethod]
        public void GenerationListPositions_WithShipeSize3_ThenListCount3()
        {
            ship1.GenerationListPositions();
            Assert.AreEqual(3, ship1._Positions.Count);
        }

        [TestMethod]
        public void GenerationListPositions_WithShipeSize5_ThenListCount5()
        {
            ship3.GenerationListPositions();
            Assert.AreEqual(5, ship3._Positions.Count);
        }

        [TestMethod]
        public void GenerationListPositions_WithShipSize5Vertical_ThenListHasGoodValue()
        {
            int i = 0;
            List<Position> truePosShip5 = new List<Position>() 
            { 
                new Position(1,2),
                new Position(2,2),
                new Position(3,2),
                new Position(4,2),
                new Position(5,2),
            };
            shipSize5Vertical.GenerationListPositions();
            foreach (var iposition in shipSize5Vertical._Positions)
            {
                Assert.IsTrue(iposition.Equals(truePosShip5[i]));
                i++;
            }
        }

        [TestMethod]
        public void GenerationListPositions_WithShipSize5VerticalReverse_ThenListHasGoodValue()
        {
            int i = 0;
            List<Position> truePosShip5 = new List<Position>()
            {
                new Position(1,2),
                new Position(2,2),
                new Position(3,2),
                new Position(4,2),
                new Position(5,2),
            };
            shipSize5VerticalReverse.GenerationListPositions();
            foreach (var iposition in shipSize5VerticalReverse._Positions)
            {
                Assert.IsTrue(iposition.Equals(truePosShip5[i]));
                i++;
            }
        }

        [TestMethod]
        public void GenerationListPositions_WithShipSize5Horizontal_ThenListHasGoodValue()
        {
            int i = 0;
            List<Position> truePosShip5 = new List<Position>()
            {
                new Position(2,1),
                new Position(2,2),
                new Position(2,3),
                new Position(2,4),
                new Position(2,5),
            };
            shipSize5Horizontal.GenerationListPositions();
            foreach (var iposition in shipSize5Horizontal._Positions)
            {
                Assert.IsTrue(iposition.Equals(truePosShip5[i]));
                i++;
            }
        }

        [TestMethod]
        public void GenerationListPositions_WithShipSize5HorizontalReverse_ThenListHasGoodValue()
        {
            int i = 0;
            List<Position> truePosShip5 = new List<Position>()
            {
                new Position(2,1),
                new Position(2,2),
                new Position(2,3),
                new Position(2,4),
                new Position(2,5),
            };
            shipSize5HorizontalReverse.GenerationListPositions();
            foreach (var iposition in shipSize5HorizontalReverse._Positions)
            {
                Assert.IsTrue(iposition.Equals(truePosShip5[i]));
                i++;
            }
        }

        [TestMethod]
        public void GenerationListPositions_WithShipSize5DiagonaleRigthBot_ThenListHasGoodValue()
        {
            int i = 0;
            List<Position> truePosShip5 = new List<Position>()
            {
                new Position(1,2),
                new Position(2,3),
                new Position(3,4),
                new Position(4,5),
                new Position(5,6),
            };
            shipSize5DiagonaleRigthBot.GenerationListPositions();
            foreach (var iposition in shipSize5DiagonaleRigthBot._Positions)
            {
                
                Assert.IsTrue(iposition.Equals(truePosShip5[i]));
                i++;
            }
        }

        [TestMethod]
        public void GenerationListPositions_WithShipSize5DiagonaleLeftTop_ThenListHasGoodValue()
        {
            int i = 0;
            List<Position> truePosShip5 = new List<Position>()
            {
                new Position(1,2),
                new Position(2,3),
                new Position(3,4),
                new Position(4,5),
                new Position(5,6)
            };
            shipSize5DiagonaleLeftTop.GenerationListPositions();
            foreach (var iposition in shipSize5DiagonaleLeftTop._Positions)
            {
                Assert.IsTrue(iposition.Equals(truePosShip5[i]));
                i++;
            }
        }

        [TestMethod]
        public void GenerationListPositions_WithShipSize5DiagonaleRigthTop_ThenListHasGoodValue()
        {
            int i = 0;
            List<Position> truePosShip5 = new List<Position>()
            {
                new Position(5,2),    
                new Position(4,3),
                new Position(3,4),
                new Position(2,5),
                new Position(1,6),
            };
            shipSize5DiagonaleRigthTop.GenerationListPositions();
            foreach (var iposition in shipSize5DiagonaleRigthTop._Positions)
            {
                Assert.IsTrue(iposition.Equals(truePosShip5[i]));
                i++;
            }
        }

        [TestMethod]
        public void GenerationListPositions_WithShipSize5DiagonaleLeftBot_ThenListHasGoodValue()
        {
            int i = 0;
            List<Position> truePosShip5 = new List<Position>()
            {
                new Position(5,2),
                new Position(4,3),
                new Position(3,4),
                new Position(2,5),
                new Position(1,6),
            };
            shipSize5DiagonaleLeftBot.GenerationListPositions();
            foreach (var iposition in shipSize5DiagonaleLeftBot._Positions)
            {
                Assert.IsTrue(iposition.Equals(truePosShip5[i]));
                i++;
            }
        }

        [TestMethod]
        public void IsNotCollision_WithNull_ThenFalse()
        {
            Assert.IsFalse(new ShipService() .IsCollision(null));
        }

        [TestMethod]
        public void IsCollision_WithSameShip_ThenTrue()
        {
            Assert.IsTrue(ship1.IsCollision(ship1));
        }

        [TestMethod]
        public void IsNotCollision_WithTwoShipWithPositionDifferent_ThenFalse()
        {
            Assert.IsFalse(ship1.IsCollision(ship2));
        }

        [TestMethod]
        public void IsNotCollision_WithTwoShipDiagonale_ThenFalse()
        {
            Assert.IsFalse(ship4.IsCollision(ship5));
        }

        [TestMethod]
        public void IsCollision_WithTwoShipDiagonale_ThenTrue()
        {
            Assert.IsTrue(ship5.IsCollision(ship1));
        }

        [TestMethod]
        public void AddPositionInvalid_WithShip_ThenListCount8()
        {
            Game game = new Game();
            ship4.GenerationListPositions();
            ship4.AddPositionInvalid(game);
            //Game game = Game.GetInstance();
            //Console.WriteLine(game.PositionsInvalid.Count.ToString());
            Assert.AreEqual(12, game.PositionsInvalid.Count);
        }

    }
}