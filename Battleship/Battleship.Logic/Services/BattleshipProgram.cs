using Battleship.Logic.Interfaces;
using Battleship.Logic.Static;
using Battleship.Model.Entities;

namespace Battleship.Logic.Services
{
    public class BattleshipProgram : IBattleshipProgram
    {
        private ICommunicator _communicator;
        private IBattleService _battleService;
        public BattleshipProgram(ICommunicator communicator, IBattleService battleService)
        {
            _communicator = communicator;
            _battleService = battleService;
        }

        public void Run()
        {
            _communicator.Write(StaticStrings.WelcomeMessage);
            Player[] players = _battleService.PickPlayers();
            _battleService.RunBattle(players[0], players[1]);
        }

    }
}