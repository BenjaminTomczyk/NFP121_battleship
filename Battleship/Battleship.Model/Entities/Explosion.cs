namespace Battleship.Model.Entities
{
    public class Explosion
    {
        public int Id { get; set; }
        public Position ExplosionLocation { get; set; }
        public bool Hit { get; set; }

        public Explosion() { }

        public Explosion(Position explosionLocation, bool hit)
        {
            ExplosionLocation = explosionLocation;
            Hit = hit;
        }

        

        

        
    }
}