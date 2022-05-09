using System.Collections.Generic;
using System.Linq;
using Battleship.Logic.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Logic.Tests.Services
{
    [TestClass]
    public class BattleSetupTester
    {
        private List<int> threeRequiredShips = new List<int>()
        {
            1, 2, 3
        };

        private BattleSetup _battleSetup = new BattleSetup();

        [TestMethod]
        public void PlaceBoats_WithRequiredShipListLengthIsZero_ThenResultLengthIsZero()
        {
            var res = _battleSetup.PlaceBoats(null, 0, new List<int>()
            {
            });
            Assert.AreEqual(0, res.Count);
        }

        [TestMethod]
        public void PlaceBoats_WithRequiredShipListLengthIsThree_ThenResultLengthIsThree()
        {
            var res = _battleSetup.PlaceBoats(null, 0, threeRequiredShips);
            Assert.AreEqual(3, res.Count);
        }

        [TestMethod]
        public void PlaceBoats_With3RequiredShips_ThenAllShipsAreSet()
        {
            var res = _battleSetup.PlaceBoats(null, 0, threeRequiredShips);
            Assert.IsTrue(res.All(x => x.IsSet()));
        }

        [TestMethod]
        public void PlaceBoats_With3RequiredShipsInGridOf4_ThenAllShipsAreInGrid()
        {
            var res = _battleSetup.PlaceBoats(null, 4, threeRequiredShips);
            Assert.IsTrue(res.All(x => x._Start.Row < 4 && x._Start.Row >= 0 ));
        }
    }
}