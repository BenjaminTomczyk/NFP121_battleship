using Battleship.Logic.Interfaces;
using Battleship.Logic.Services;
using Battleship.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Battleship.Logic.Tests.Services
{
    [TestClass]
    public class BattleServiceTester
    {
        private BattleService _battleService;
        private Mock<IRoundManager> _roundManagerMock;
        public BattleServiceTester()
        {
            _roundManagerMock = new Mock<IRoundManager>(); 
            _battleService = new BattleService(_roundManagerMock.Object);
        }

        [TestMethod]
        public void PickPlayers()
        {

        }

        [TestMethod]
        public void RunBattle()
        {
            _battleService.RunBattle(new Player(), new Player());
        }

        [TestMethod]
        public void RunBattle_WithP1WithoutBoatsAndP2HasBoats_ThenDoTurnIsCalledOnlyOnce()
        {
            var player = new Player();
            var player2 = new Player();
            _roundManagerMock.Setup(x => x.HasBoats(player)).Returns(false);
            _roundManagerMock.Setup(x => x.HasBoats(player2)).Returns(true);
            _battleService.RunBattle(player, player2);
            _roundManagerMock.Verify(x => x.DoTurn(It.IsAny<Player>()), Times.Once);
        }

        [TestMethod]
        public void RunBattle_WithP2WithoutBoatsAndP1HasBoats_ThenDoTurnIsCalledOnlyOnce()
        {
            var player = new Player();
            var player2 = new Player();
            _roundManagerMock.Setup(x => x.HasBoats(player)).Returns(true);
            _roundManagerMock.Setup(x => x.HasBoats(player2)).Returns(false);
            _battleService.RunBattle(player, player2);
            _roundManagerMock.Verify(x => x.DoTurn(It.IsAny<Player>()), Times.Once);
        }
    }
}
