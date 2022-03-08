using Battleship.Model.Entities;

namespace Battleship.Logic.Interfaces
{
    public interface IRoundManager
    {
        public bool HasBoats(Player player);
        public void DoTurn(Player p);
    }
}