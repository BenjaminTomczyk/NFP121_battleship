using Battleship.Logic.Interfaces;
using Battleship.Logic.Services;

namespace Battleship
{
    public class Program
    {
        private static IBattleshipProgram _battleshipProgram;
        public static void Main(string[] args)
        {
            _battleshipProgram = new BattleshipProgram(new Communicator(), new BattleService(new RoundManager()));
            _battleshipProgram.Run();
        }
    }

}
