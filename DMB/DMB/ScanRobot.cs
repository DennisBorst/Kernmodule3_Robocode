using System;
using System.Collections.Generic;
using System.Text;

namespace DMB
{
    public class ScanRobot : BTNode
    {
        private float scanDegrees;
        public ScanRobot(BlackBoard blackBoard, float scanDegrees)
        {
            this.blackBoard = blackBoard;
            this.scanDegrees = scanDegrees;
        }

        public override BTNodeStatus Tick()
        {
            blackBoard.robot.TurnRadarLeft(scanDegrees);

            if(blackBoard.lastScannedRobotEvent != null)
            {
                return BTNodeStatus.Succes;
            }
            else
            {
                return BTNodeStatus.Failed;
            }
        }
    }
}
