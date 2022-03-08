using Battleship.Model.Entities;

namespace Battleship.Logic.Interfaces
{
    public interface IBattleService
    {
        Player[] PickPlayers();
        void RunBattle(Player p1, Player p2);
    }
}