using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using Robocode;

namespace DMB
{
    public class SetColor : BTNode
    {
        private Color color;
        public SetColor(BlackBoard blackBoard, Color color)
        {
            this.color = color;
            this.blackBoard = blackBoard;
        }

        public override BTNodeStatus Tick()
        {
            blackBoard.robot.SetColors(color, color, color);
            return BTNodeStatus.Succes;
        }
    }
}
