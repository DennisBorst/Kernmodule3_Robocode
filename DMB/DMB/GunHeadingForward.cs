using System;
using System.Collections.Generic;
using System.Text;

namespace DMB
{
    public class GunHeadingForward : BTNode
    {
        public GunHeadingForward(BlackBoard blackBoard)
        {
            this.blackBoard = blackBoard;
        }

        public override BTNodeStatus Tick()
        {
            if(blackBoard.robot.GunHeading != blackBoard.robot.Heading)
            {
                blackBoard.robot.TurnGunRight(blackBoard.robot.Heading);
                return BTNodeStatus.Running;
            }
            blackBoard.robot.IsAdjustGunForRobotTurn = false;

            return BTNodeStatus.Succes;
        }
    }
}
