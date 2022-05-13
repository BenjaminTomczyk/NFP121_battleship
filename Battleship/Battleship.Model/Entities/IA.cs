namespace Battleship.Model.Entities
{
	public class IA
	{
		public int Id { get; set; }
		public string Level { get; set; }
		public Game Game { get; set; }

		public IA(int id, string level,Game game)
        {
			Id = id;
			Level = level;
			Game = game;
        }
	}
}

