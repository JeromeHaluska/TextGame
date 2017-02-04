namespace Game.Races
{
    using Entities;
    using Traits;

    class Human : Race
    {
        public Human()
        {
            Name = "Human";
            BodyParts = new BodyPart[5] {
                new BodyPart("Head", 1f, 1f),
                new BodyPart("Chest", 1f, 1f),
                new BodyPart("Arms", 1f, 1f),
                new BodyPart("Legs", 1f, 1f),
                new BodyPart("Feet", 1f, 1f),
            };
            Traits = new Trait[0];
        }
    }
}
