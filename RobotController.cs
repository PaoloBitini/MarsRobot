using System.Text.RegularExpressions;

namespace MarsRobot
{
    public class RobotController
    {
        private List<Action>? actions;

        private (int x, int y) edges;
        public RobotController(string commands, (int x, int y) edges)
        {
            SetActions(commands);
            this.edges = edges;
        }




        private void SetActions(string commands)
        {
            Regex rxForIvalidCommands = new("^(f|r|l)+$");
            actions = new List<Action>();

            if (!rxForIvalidCommands.IsMatch(commands))
            {
                Console.WriteLine($"invalid commands: {commands}");
                return;
            }

            char[] splittedCommands = commands.ToLower().ToArray();

            foreach (char command in splittedCommands)
            {
                switch (command)
                {
                    case 'f':
                        actions.Add(Action.MoveForward);
                        break;
                    case 'l':
                        actions.Add(Action.TurnLeft);
                        break;
                    case 'r':
                        actions.Add(Action.TurnRight);
                        break;
                    default:
                        return;
                }
            }
        }

        private void ExecAction(Action action, Robot robot)
        {
            switch (action)
            {
                case Action.TurnLeft:
                    robot.TurnLeft();
                    break;

                case Action.TurnRight:
                    robot.TurnRight();
                    break;

                case Action.MoveForward:
                    robot.MoveForward(edges);
                    break; 
            }
        }

        public void ExecAllActions( Robot robot)
        {
            if (actions != null)
                foreach (Action action in actions)
                {
                    ExecAction(action, robot);
                }

            PrintResult(robot);
        }

        private void PrintResult(Robot robot)
        {
            Console.WriteLine($"{robot.Cd.x},{robot.Cd.y},{robot.DirectionToString()}");
        }
    }

    enum Action
    {
        TurnLeft,
        TurnRight,
        MoveForward
    }
}
