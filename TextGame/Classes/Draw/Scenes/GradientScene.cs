namespace Draw.Scenes
{
    using OpenTK.Graphics;
    using System;
    using System.Collections.Generic;
    using Utility;

    public class GradientScene : Scene
    {
        private List<ColoredString> _colStringList = new List<ColoredString>();

        public GradientScene(ExtendedConsoleWindow console) : base(console)
        {
            var rnd = new Random();

            for (int cnt = 0; cnt < Console.Rows; cnt++) {
                var colString = new ColoredString("Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod ", Colors.TextColor, Colors.BackgroundColor);

                colString.AddGradient(
                    new Color4((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble(), 1),
                    new Color4((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble(), 1),
                    true,
                    false);
                colString.AddGradient(
                    new Color4((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble(), 1),
                    new Color4((float)rnd.NextDouble(), (float)rnd.NextDouble(), (float)rnd.NextDouble(), 1),
                    false,
                    true);
                _colStringList.Add(colString);
            }
        }

        public override void Draw()
        {
            var cnt = 0;
            foreach (ColoredString colString in _colStringList) {
                Console.Write(cnt++, 0, colString);
            }
        }
    }
}
