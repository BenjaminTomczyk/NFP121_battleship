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
            Start = new Position()
            {
                Row = 0,
                Column = 0
            },
            End = new Position()
            {
                Row = 2,
                Column = 0
            }
        };

        private Ship ship2 = new Ship()
        {
            Start = new Position()
            {
                Row = 4,
                Column = 4
            },
            End = new Position()
            {
                Row = 4,
                Column = 3
            }
        };

        private Ship ship3 = new Ship()
        {
            Start = new Position()
            {
                Row = 4,
                Column = 4
            },
            End = new Position()
            {
                Row = 4,
                Column = 0
            }
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
        public void IsInGrid_WithShip1AndGridSize4_ThenTrue() 
        {
            Assert.IsTrue(ship1.IsInGrid(4));
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
        public void GenerationListPositions_WithShipeSize5_ThenListHasGoodValue()
        {
            
            foreach(var iposition in ship1.GenerationListPositions())
            {
                
            }
        }

    }
}