namespace MarsRobot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Insert grid dimensions: ");
            string? dim = Console.ReadLine();
            Console.WriteLine();

            Console.WriteLine("Insert commands: ");
            string? commands = Console.ReadLine();
            Console.WriteLine();

            string[] splittedDim = dim.Split("x");
            int x = Convert.ToInt32(splittedDim[0]);
            int y = Convert.ToInt32(splittedDim[1]);

            RobotController controller = new(commands, (x, y));
            Robot robot = new();

            controller.ExecAllActions(robot);
        }
    }
}