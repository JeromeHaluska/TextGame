namespace Game.Scenes
{
    using Draw.Controls;
    using Draw.Utility;
    using OpenTK.Graphics;
    using System;

    public class ExceptionScene : Scene
    {
        public ExceptionScene(Exception e) : base()
        {
            var dBox = new DialogueBox(1, 1, Console.Cols - 2, Console.Rows - 2);

            dBox.Write(new ColoredString("A problem has been detected and this program has been shut down to prevent damage to your computer.", Color4.White));
            dBox.Write("");
            dBox.Write("The problem seems to be caused because of this: " + e.StackTrace);
            dBox.Write("");
            dBox.Write(new ColoredString(e.Message, Color4.White));

            Add(dBox);
        }

        public override void Draw()
        {
            Console.Fill(new Color4(0, 0, 170, 1));

            // Drawing all controls.
            base.Draw();
        }
    }
}
