namespace Battleship.Model.Entities
{
    public class Explosion
    {
        public Position ExplosionLocation { get; set; }
        public bool Hit { get; set; }


        public Explosion(Position explosionLocation, bool hit)
        {
            ExplosionLocation = explosionLocation;
            Hit = hit;
        }

        

        

        
    }
}