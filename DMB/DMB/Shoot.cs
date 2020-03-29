using System;
using System.Collections.Generic;
using System.Text;

namespace DMB
{
    public class Shoot : BTNode
    {
        private float power;
        public Shoot(BlackBoard blackBoard, float power)
        {
            this.power = power;
            this.blackBoard = blackBoard;
        }

        public override BTNodeStatus Tick()
        {
            blackBoard.robot.Fire(power);
            return BTNodeStatus.Succes;
        }
    }
}
