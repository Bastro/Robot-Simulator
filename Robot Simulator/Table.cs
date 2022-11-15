using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Simulator
{
    public class Table
    {
        private int _xDimension = 4;
        private int _yDimension = 4;
        private int _currentX = 0;
        private int _currentY = 0;
        private Direction _currentDirection = Direction.EAST;
        private bool _hasBeenPlaced = false;

        public string LastReport { get; private set; } = "";

        public void nextCommands(IEnumerable<Command> commands)
        {
            foreach (Command command in commands)
            {
                nextCommand(command);
            }
        }

        private void nextCommand(Command command)
        {
            var action = command.Action;
            if (action == Action.REPORT && _hasBeenPlaced)
            {
                Report();
            } 
            else if (action == Action.MOVE && _hasBeenPlaced)
            {
                Move(command);
            } 
            else if (action == Action.PLACE)
            {
                _hasBeenPlaced = Place(command);
            }
            else if (action == Action.LEFT || action == Action.RIGHT && _hasBeenPlaced)
            {
                ChangeDirection(command);
            }
        }

        private bool isWithinXrange(int xCoord) => xCoord <= _xDimension && xCoord >= 0;
        private bool isWithinYrange(int yCoord) => yCoord <= _yDimension && yCoord >= 0;
        private bool canMove(Command command) => (isWithinXrange(command.xCoord) && isWithinYrange(command.yCoord));
 
        private void Move(Command command)
        {
            var direction = _currentDirection;
            if (direction == Direction.SOUTH)
            {
                MoveInY(-1);
            }
            else if (direction == Direction.NORTH)
            {
                MoveInY(1);
            }
            else if (direction == Direction.EAST)
            {
                MoveInX(1);
            }
            else if (direction == Direction.WEST)
            {
                MoveInX(-1);
            }
        }

        private void MoveInY(int amount)
        {
            var wantedNextMove = _currentY + amount;
            if (isWithinYrange(wantedNextMove))
            {
                _currentY = wantedNextMove;
            }
        }

        private void MoveInX(int amount)
        {
            var wantedNextMove = _currentX + amount;
            if (isWithinXrange(wantedNextMove))
            {
                _currentX = wantedNextMove;
            }
        }

        private bool Place(Command command)
        {
            var canBePlaced = canMove(command);
            if (canBePlaced)
            {
                _currentX = command.xCoord;
                _currentY = command.yCoord;
                _currentDirection = command.Direction;
            }
            return canBePlaced;
        }

        public Direction ChangeDirection(Command command)
        {
            var allDirections = new Direction[] { Direction.WEST, Direction.NORTH, Direction.EAST, Direction.SOUTH };
            var currentIndex = Array.IndexOf(allDirections, _currentDirection);
            if (command.Action == Action.RIGHT)
            {
                _currentDirection = allDirections[currentIndex == allDirections.Length - 1 ? 0 : currentIndex + 1];
            }
            else if (command.Action == Action.LEFT)
            {
                _currentDirection = allDirections[currentIndex == 0 ? allDirections.Length - 1 : currentIndex - 1];
            }
            return _currentDirection;
        }

        private void Report()
        {
            var direction = _currentDirection.ToString() ?? "";
            LastReport = $"{_currentX},{_currentY},{direction}";
            Console.WriteLine(LastReport);
        }
    }
}
