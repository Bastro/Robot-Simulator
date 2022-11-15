namespace Robot_Simulator.Tests
{
    public class TableTests
    {
        [Fact]
        public void Place_OutSide()
        {
            var table = new Table();
            var commands = new List<Command>
            {
                new Command(){ Action = Action.PLACE, xCoord = -1, yCoord = -2, Direction = Direction.NORTH },
                new Command(){ Action = Action.PLACE, xCoord = 7, yCoord = 7, Direction = Direction.NORTH },
                new Command(){ Action = Action.MOVE },
                new Command(){ Action = Action.LEFT },
                new Command(){ Action = Action.RIGHT },
                new Command(){ Action = Action.MOVE },
                new Command(){ Action = Action.REPORT }
            };
            table.nextCommands(commands);
            Assert.Equal("", table.LastReport);
        }

        [Fact]
        public void Place()
        {
            Table table = new Table();
            var expectedX = 3;
            var expectedY = 4;
            var expectedDirection = Direction.NORTH;
            var commands = new List<Command>
            {
                new Command(){ Action = Action.PLACE, xCoord = expectedX, yCoord = expectedY, Direction = expectedDirection },
                new Command(){ Action = Action.REPORT }
            };
            table.nextCommands(commands);
            Assert.Equal($"{expectedX},{expectedY},{expectedDirection}", table.LastReport);
        }

        [Fact]
        public void Move_Possible()
        {
            Table table = new Table();
            var commands = new List<Command>
            {
                new Command(){ Action = Action.PLACE, xCoord = 3, yCoord = 4, Direction = Direction.WEST },
                new Command(){ Action = Action.MOVE },
                new Command(){ Action = Action.REPORT }
            };
            table.nextCommands(commands);
            Assert.Equal($"{2},{4},{Direction.WEST}", table.LastReport);
        }


        [Fact]
        public void Example_A()
        {
            Table table = new Table();
            var commands = new List<Command>
            {
                new Command(){ Action = Action.PLACE, xCoord = 0, yCoord = 0, Direction = Direction.NORTH },
                new Command(){ Action = Action.MOVE },
                new Command(){ Action = Action.REPORT }
            };
            table.nextCommands(commands);
            Assert.Equal($"{0},{1},{Direction.NORTH}", table.LastReport);
        }


        [Fact]
        public void Example_B()
        {
            Table table = new Table();
            var commands = new List<Command>
            {
                new Command(){ Action = Action.PLACE, xCoord = 0, yCoord = 0, Direction = Direction.NORTH },
                new Command(){ Action = Action.LEFT },
                new Command(){ Action = Action.REPORT }
            };
            table.nextCommands(commands);
            Assert.Equal($"{0},{0},{Direction.WEST}", table.LastReport);
        }

        [Fact]
        public void Example_C()
        {
            Table table = new Table();
            var commands = new List<Command>
            {
                new Command(){ Action = Action.PLACE, xCoord = 1, yCoord = 2, Direction = Direction.EAST },
                new Command(){ Action = Action.MOVE },
                new Command(){ Action = Action.MOVE },
                new Command(){ Action = Action.LEFT },
                new Command(){ Action = Action.MOVE },
                new Command(){ Action = Action.REPORT }
            };
            table.nextCommands(commands);
            Assert.Equal($"{3},{3},{Direction.NORTH}", table.LastReport);
        }
    }
}