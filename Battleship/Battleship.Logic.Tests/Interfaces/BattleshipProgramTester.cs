using Battleship.Logic.Interfaces;
using Battleship.Logic.Services;
using Battleship.Logic.Static;
using Battleship.Model.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Battleship.Logic.Tests.Interfaces
{
    [TestClass]
    public class BattleshipProgramTester
    {
        private BattleshipProgram _program;
        private Mock<ICommunicator> _commMock;
        private Mock<IBattleService> _battleService;

        public BattleshipProgramTester()
        {
            _commMock = new Mock<ICommunicator>();
            _battleService = new Mock<IBattleService>();
            _battleService.Setup(x => x.PickPlayers()).Returns(new Player[]
            {
                new Player(),
                new Player(),
            });
            _program = new BattleshipProgram(_commMock.Object, _battleService.Object);
        }

        [TestMethod]
        public void Runs_ThenCommunicatorIsCalled()
        {
            _program.Run();
            _commMock.Verify(x => x.Write(It.IsAny<string>()), Times.Once);
        }
        [TestMethod]
        public void Runs_ThenCommunicatorIsCalledWithWelcomeMessage()
        {
            _program.Run();
            _commMock.Verify(x => x.Write(StaticStrings.WelcomeMessage), Times.Once);
        }
    }
}
