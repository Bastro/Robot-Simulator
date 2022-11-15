using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Simulator
{
    public static class CommandFactory
    {
        public static IEnumerable<Command> GetCommands(string[] commands)
        {
            var commandsList = new List<Command>();
            foreach (string command in commands)
            {
                commandsList.Add(GetCommand(command));
            }
            return commandsList;
        }

        private static Command GetCommand(string commandText)
        {
            string[] commandParts = commandText.Trim().Split(' ');
            var command = new Command();
            command = AddActions(command, commandParts[0]);
            if (commandParts.Length > 1)
            {
                command = AddCoords(command, commandParts[1].Split(','));
            }
            return command;
        }

        private static Command AddActions(Command command, string actionString)
        {
            Action action;
            var isAction = actionString.TryParseAsEnum(out action);
            if (isAction)
            {
                command.Action = action;
            }
            return command;
        }

        private static Command AddCoords(Command command, string[] parsedValues) 
        {
            int xCoord;
            int.TryParse(parsedValues[0], out xCoord);
            command.xCoord = xCoord;
            int yCoord;
            int.TryParse(parsedValues[1], out yCoord);
            command.yCoord = yCoord;
            Direction direction;
            var isAction = parsedValues[2].TryParseAsEnum(out direction);
            if (isAction)
            {
                command.Direction = direction;
            }
            return command;
        }

        private static bool TryParseAsEnum<T>(this string value, out T output) where T : struct
        {
            T result;

            var isEnum = Enum.TryParse(value, out result);

            output = isEnum ? result : default(T);

            return isEnum;
        }
    }
}
