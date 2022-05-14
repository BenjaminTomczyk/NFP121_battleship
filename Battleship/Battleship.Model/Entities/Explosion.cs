namespace Battleship.Model.Entities
{
    public class Explosion
    {
        Position ExplosionLocation { get; set; }
        bool Hit { get; set; }


        public Explosion(Position explosionLocation, bool hit)
        {
            ExplosionLocation = explosionLocation;
            Hit = hit;
        }

        

        

        
    }
}