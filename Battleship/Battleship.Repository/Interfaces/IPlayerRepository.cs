namespace Battleship.Repository.Interfaces
{
    public interface IPlayerRepository
    {
        bool Exists(string name);
    }
}