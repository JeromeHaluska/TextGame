namespace Game.Entities
{
    using System.Collections.Generic;
    using Paths;
    using Traits;
    using Races;

    public class Player : Entity
    {
        public Player(string name, Race race) : base(name, race.BodyParts)
        {
            Game.Player = this;
        }

        public Path Path { get; set; }

        public List<Trait> Traits { get; set; } = new List<Trait>();

        public int Coins { get; set; } = 0;
    }
}
