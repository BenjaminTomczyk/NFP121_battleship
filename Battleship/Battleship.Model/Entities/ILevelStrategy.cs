
namespace Battleship.Model.Entities
{
	public interface ILevelStrategy
	{
		Position LogicIA();
		string GetName();
	}
}

