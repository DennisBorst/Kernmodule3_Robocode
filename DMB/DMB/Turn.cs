using System;
using System.Collections.Generic;
using System.Text;

namespace DMB
{
    public class Turn : BTNode
    {
        private float degrees;

        public Turn(BlackBoard blackBoard, float degrees)
        {
            this.degrees = degrees;
            this.blackBoard = blackBoard;
        }

        public override BTNodeStatus Tick()
        {
            blackBoard.robot.TurnLeft(degrees);
            return BTNodeStatus.Succes;
        }
    }
}
