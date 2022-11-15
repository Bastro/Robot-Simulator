namespace Robot_Simulator
{
    public sealed class Simulator
    {
        public static void Run(string pathToFile)
        {
            string[] lines = File.ReadAllLines(@pathToFile);
            var table = new Table();
            table.nextCommands(CommandFactory.GetCommands(lines));
        }
    }
}
