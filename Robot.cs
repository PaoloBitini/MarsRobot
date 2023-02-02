

namespace MarsRobot
{
    public class Robot
    {
        private Direction _direction;
        public Direction Direction { get { return _direction; } }

        private (int x, int y) _cd; //coordinates
        public (int x, int y) Cd { get { return _cd; } }

        public Robot()
        {
            _direction = Direction.North;
            _cd = (1, 1);
        }

        public void MoveForward((int x, int y) edges)
        {
            switch (_direction)
            {
                case Direction.North:
                    _cd = _cd.y < edges.y ? (_cd.x, _cd.y + 1) : _cd;
                    break;
                case Direction.South:
                    _cd = _cd.y > 1 ? (_cd.x, _cd.y - 1) : _cd;
                    break;
                case Direction.West:
                    _cd = _cd.x > 1 ? (_cd.x - 1, _cd.y) : _cd;
                    break;
                case Direction.East:
                    _cd = _cd.x < edges.x ? (_cd.x + 1, _cd.y) : _cd;
                    break;
                default: return;
            }
        }

        public void TurnLeft()
        {
            if (_direction == Direction.North)
            {
                _direction = Direction.West;
            }
            else
            {
                _direction -= 1;
            }
        }

        public void TurnRight()
        {
            if (_direction == Direction.West)
            {
                _direction = Direction.North;
            }
            else
            {
                _direction += 1;
            }
        }

        public string DirectionToString()
        {
            switch (Direction)
            {
                case Direction.North:
                    return "north";
                case Direction.South:
                    return "south";
                case Direction.East:
                    return "east";
                case Direction.West:
                    return "west";
                default: return "";
            }
        }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }
}
