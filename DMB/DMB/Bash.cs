using System;
using System.Collections.Generic;
using System.Text;
using Robocode.Util;

namespace DMB
{
    public class Bash : BTNode
    {
        private float degrees;

        public Bash(BlackBoard blackBoard)
        {
            this.blackBoard = blackBoard;
        }

        public override BTNodeStatus Tick()
        {
            if (blackBoard.lastScannedRobotEvent != null)
            {
                blackBoard.robot.TurnRight(blackBoard.lastScannedRobotEvent.Bearing);
                blackBoard.robot.Ahead(blackBoard.lastScannedRobotEvent.Distance + 5);

                blackBoard.robot.Fire(2);
                return BTNodeStatus.Succes;
            }

            return BTNodeStatus.Failed;
        }
    }
}
