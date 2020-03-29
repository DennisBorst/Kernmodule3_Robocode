using System;
using System.Collections.Generic;
using System.Text;

namespace DMB
{
    public class InRange : BTNode
    {
        private float maxRange;
        public InRange(BlackBoard blackBoard, float maxRange)
        {
            this.maxRange = maxRange;
            this.blackBoard = blackBoard;
        }

        public override BTNodeStatus Tick()
        {
            if(blackBoard.lastScannedRobotEvent.Distance > maxRange)
            {
                return BTNodeStatus.Failed;
            }

            return BTNodeStatus.Succes;
        }
    }
}
