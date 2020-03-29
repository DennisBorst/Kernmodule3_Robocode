using System;
using System.Collections.Generic;
using System.Text;

namespace DMB
{
    public class BTNodeFloatEnergy : BTNode
    {
        public enum CompareEnum { Equals, Larger, Smaller };
        private CompareEnum comparer;
        private BlackBoard blackboard;
        private float valueToCheck;
        public BTNodeFloatEnergy(BlackBoard blackboard, float valueToCheck, CompareEnum comparer)
        {
            this.comparer = comparer;
            this.blackboard = blackboard;

            this.valueToCheck = valueToCheck;
        }

        public override BTNodeStatus Tick()
        {
            float val = (float)blackboard.robot.Energy;

            switch (comparer)
            {
                case CompareEnum.Equals:
                    return (val == valueToCheck) ? BTNodeStatus.Succes : BTNodeStatus.Failed;
                case CompareEnum.Larger:
                    return (val > valueToCheck) ? BTNodeStatus.Succes : BTNodeStatus.Failed;
                case CompareEnum.Smaller:
                    return (val < valueToCheck) ? BTNodeStatus.Succes : BTNodeStatus.Failed;
                default:
                    break;
            }
            return BTNodeStatus.Running;
        }
    }
}
