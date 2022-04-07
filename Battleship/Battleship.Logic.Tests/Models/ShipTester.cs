using Battleship.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Battleship.Logic.Tests.Models
{
    [TestClass]
    public class ShipTester
    {

        private Ship ship1 = new Ship()
        {
            Start = new Position(0,0),
            End = new Position(2,0)
        };

        private Ship ship2 = new Ship()
        {
            Start = new Position(4,4),
            End = new Position(4,3)
        };

        private Ship ship3 = new Ship()
        {
            Start = new Position(4,4),
            End = new Position(4,0)
        };

        private Ship shipSize5Vertical = new Ship()
        {
            Start = new Position(1,2),
            End = new Position(5,2)
        };

        private Ship shipSize5Horizontal = new Ship()
        {
            Start = new Position(2, 5),
            End = new Position(2, 1)
        };

        private Ship shipSize5Diagonale = new Ship()
        {
            Start = new Position(1, 2),
            End = new Position(5, 6)
        };

        private Ship shipSize5Diagonale2 = new Ship()
        {
            Start = new Position(5, 6),
            End = new Position(1, 2)
        };



        [TestMethod]
        public void IsInGrid_WithGridSize_ThenFalse()
        {
            Assert.IsFalse(new Ship().IsInGrid(0));
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
            Assert.AreEqual(0,new Ship().GenerationListPositions().Count);
        }

        [TestMethod]
        public void GenerationListPositions_WithShipeSize3_ThenListCount3()
        {
            Assert.AreEqual(3, ship1.GenerationListPositions().Count);
        }

        [TestMethod]
        public void GenerationListPositions_WithShipeSize5_ThenListCount5()
        {
            Assert.AreEqual(5, ship3.GenerationListPositions().Count);
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
            foreach(var iposition in shipSize5Vertical.GenerationListPositions())
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
            foreach (var iposition in shipSize5Horizontal.GenerationListPositions())
            {
                Assert.IsTrue(iposition.Equals(truePosShip5[i]));
                i++;
            }
        }

        [TestMethod]
        public void GenerationListPositions_WithShipSize5Diagonale_ThenListHasGoodValue()
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
            foreach (var iposition in shipSize5Diagonale.GenerationListPositions())
            {
                
                Assert.IsTrue(iposition.Equals(truePosShip5[i]));
                i++;
            }
        }

        [TestMethod]
        public void GenerationListPositions_WithShipSize5Diagonale2_ThenListHasGoodValue()
        {
            int i = 0;
            List<Position> truePosShip5 = new List<Position>()
            {
                new Position(5,6),
                new Position(4,5),
                new Position(3,4),
                new Position(2,3),
                new Position(1,2),
            };
            foreach (var iposition in shipSize5Diagonale2.GenerationListPositions())
            {

                Assert.IsTrue(iposition.Equals(truePosShip5[i]));
                i++;
            }
        }

        [TestMethod]
        public void IsNotCollision_WithNull_ThenFalse()
        {
            Assert.IsFalse(new Ship().IsCollision(null));
        }

        [TestMethod]
        public void IsNotCollision_WithSameShip_ThenTrue()
        {
            Assert.IsTrue(ship1.IsCollision(ship1));
        }

        [TestMethod]
        public void IsNotCollision_WithTwoShipWithPositionDifferent_ThenFalse()
        {
            Assert.IsFalse(ship1.IsCollision(ship2));
        }

    }
}