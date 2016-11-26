namespace Game.Entities
{
    public class Player : Entity
    {
        public Player(string name) : base(name)
        {

        }

        public int Coins { get; set; } = 0;
    }
}
