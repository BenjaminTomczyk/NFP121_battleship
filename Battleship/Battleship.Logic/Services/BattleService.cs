using Battleship.Logic.Interfaces;
using Battleship.Model.Entities;

namespace Battleship.Logic.Services
{
    public class BattleService : IBattleService
    {
        private IRoundManager _roundManager;

        public BattleService(IRoundManager roundManager)
        {
            _roundManager = roundManager;
        }

        public Player[] PickPlayers()
        {
            return new Player[2]{new Player(), new Player()};
        }

        public void RunBattle(Player p1, Player p2)
        {
            var p1hb = true;
            var p2hb = true;
            do
            {
                _roundManager.DoTurn(p1);
                p1hb = _roundManager.HasBoats(p1);
                p2hb = _roundManager.HasBoats(p2);
            } while (p1hb && p2hb);
        }
    }
}