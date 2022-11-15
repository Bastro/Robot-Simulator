using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot_Simulator
{
    public class Command
    {
        public Direction Direction { get; set; } = Direction.WEST;
        public Action Action { get; set; } = Action.REPORT;
        public int xCoord { get; set; } = -int.MaxValue;
        public int yCoord { get; set; } = -int.MaxValue;
    }
}
