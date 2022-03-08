using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Battleship.Tests
{
    [TestClass]
    public class ProgramTester
    {
        [TestMethod]
        public void Runs()
        {
            Program.Main(Array.Empty<string>());
        }

        [TestMethod]
        public void SayWelcomeToBattleshipOnStartup()
        {

        }
    }
}
