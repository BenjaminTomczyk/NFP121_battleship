using Battleship.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

        private Ship ship4 = new Ship()
        {
            Start = new Position(4, 4),
            End = new Position(3, 3)
        };

        private Ship ship5 = new Ship()
        {
            Start = new Position(0, 0),
            End = new Position(2, 2)
        };

        private Ship shipSize5Vertical = new Ship()
        {
            Start = new Position(1,2),
            End = new Position(5,2)
        };

        private Ship shipSize5VerticalReverse = new Ship()
        {
            Start = new Position(5, 2),
            End = new Position(1, 2)
        };

        private Ship shipSize5Horizontal = new Ship()
        {
            Start = new Position(2, 1),
            End = new Position(2, 5)
        };

        private Ship shipSize5HorizontalReverse = new Ship()
        {
            Start = new Position(2, 5),
            End = new Position(2, 1)
        };

        private Ship shipSize5DiagonaleRigthBot = new Ship()
        {
            Start = new Position(1, 2),
            End = new Position(5, 6)
        };

        private Ship shipSize5DiagonaleLeftTop = new Ship()
        {
            Start = new Position(5, 6),
            End = new Position(1, 2)
        };
        
        private Ship shipSize5DiagonaleRigthTop = new Ship()
        {
            Start = new Position(5, 2),
            End = new Position(1, 6)
        };

        private Ship shipSize5DiagonaleLeftBot = new Ship()
        {
            Start = new Position(1, 6),
            End = new Position(5, 2)
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
            Ship shipNull = new Ship();
            shipNull.GenerationListPositions();
            Assert.AreEqual(0,shipNull.Positions.Count);
        }

        [TestMethod]
        public void GenerationListPositions_WithShipeSize3_ThenListCount3()
        {
            ship1.GenerationListPositions();
            Assert.AreEqual(3, ship1.Positions.Count);
        }

        [TestMethod]
        public void GenerationListPositions_WithShipeSize5_ThenListCount5()
        {
            ship3.GenerationListPositions();
            Assert.AreEqual(5, ship3.Positions.Count);
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
            foreach (var iposition in shipSize5Vertical.Positions)
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
            foreach (var iposition in shipSize5VerticalReverse.Positions)
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
            foreach (var iposition in shipSize5Horizontal.Positions)
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
            foreach (var iposition in shipSize5HorizontalReverse.Positions)
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
            foreach (var iposition in shipSize5DiagonaleRigthBot.Positions)
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
            foreach (var iposition in shipSize5DiagonaleLeftTop.Positions)
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
            foreach (var iposition in shipSize5DiagonaleRigthTop.Positions)
            {
                Console.WriteLine(iposition.Column + "," + iposition.Row);
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
            foreach (var iposition in shipSize5DiagonaleLeftBot.Positions)
            {
                Console.WriteLine(iposition.Row + ";" + iposition.Column);
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

    }
}