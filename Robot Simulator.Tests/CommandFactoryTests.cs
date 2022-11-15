using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;

namespace Robot_Simulator.Tests
{
    public class CommandFactoryTests
    {

        [Fact]
        public void Example_A()
        {
            string[] stringCommands = new string[3] { "PLACE 0,0,NORTH", "MOVE", "REPORT" };
            var commandsFromFactory = CommandFactory.GetCommands(stringCommands);

            var expectedCommands = new List<Command>
            {
                new Command(){ Action = Action.PLACE, xCoord = 0, yCoord = 0, Direction = Direction.NORTH },
                new Command(){ Action = Action.MOVE },
                new Command(){ Action = Action.REPORT }
            };
            for (int i = 0; i < expectedCommands.Count; i++)
            {
                var obj1 = JsonConvert.SerializeObject(expectedCommands.ElementAt(i));
                var obj2 = JsonConvert.SerializeObject(commandsFromFactory.ElementAt(i));
                Assert.Equal(obj1, obj2);
            }
        }

        [Fact]
        public void Example_B()
        {
            string[] stringCommands = new string[3] { "PLACE 0,0,NORTH", "LEFT", "REPORT" };
            var commandsFromFactory = CommandFactory.GetCommands(stringCommands);

            var expectedCommands = new List<Command>
            {
                new Command(){ Action = Action.PLACE, xCoord = 0, yCoord = 0, Direction = Direction.NORTH },
                new Command(){ Action = Action.LEFT },
                new Command(){ Action = Action.REPORT }
            };
            for (int i = 0; i < expectedCommands.Count; i++)
            {
                var obj1 = JsonConvert.SerializeObject(expectedCommands.ElementAt(i));
                var obj2 = JsonConvert.SerializeObject(commandsFromFactory.ElementAt(i));
                Assert.Equal(obj1, obj2);
            }
        }

        [Fact]
        public void Example_C()
        {
            string[] stringCommands = new string[6] { "PLACE 1,2,EAST", "MOVE", "MOVE", "LEFT", "MOVE", "REPORT" };
            var commandsFromFactory = CommandFactory.GetCommands(stringCommands);

            var expectedCommands = new List<Command>
            {
                new Command(){ Action = Action.PLACE, xCoord = 1, yCoord = 2, Direction = Direction.EAST },
                new Command(){ Action = Action.MOVE },
                new Command(){ Action = Action.MOVE },
                new Command(){ Action = Action.LEFT },
                new Command(){ Action = Action.MOVE },
                new Command(){ Action = Action.REPORT }
            };
            for (int i = 0; i < expectedCommands.Count; i++)
            {
                var obj1 = JsonConvert.SerializeObject(expectedCommands.ElementAt(i));
                var obj2 = JsonConvert.SerializeObject(commandsFromFactory.ElementAt(i));
                Assert.Equal(obj1, obj2);
            }
        }
    }
}
