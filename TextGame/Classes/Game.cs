namespace Game
{
    public static class Game
    {
        public static string GetApplicationPath()
        {
            return System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
        }
    }
}
