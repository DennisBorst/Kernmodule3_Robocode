using System;
using System.Collections.Generic;
using System.Text;

namespace DMB
{
    public class MoveAhead : BTNode
    {
        private int moveDistance;
        public MoveAhead(BlackBoard blackBoard, int moveDistance)
        {
            this.blackBoard = blackBoard;
            this.moveDistance = moveDistance;
        }

        public override BTNodeStatus Tick()
        {
            blackBoard.robot.Ahead(moveDistance);
            return BTNodeStatus.Succes;
        }
    }
}
