namespace Battleship.Model.Entities
{
	public class IA
	{
		public int Id { get; set; }
		public string Level { get; set; }

		public IA()
        {
        }

		public IA(int id, string level)
        {
			Id = id;
			Level = level;
        }
	}
}

