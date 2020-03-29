using System;
using System.Collections.Generic;
using System.Text;

namespace DMB
{
    public class Sequence : BTNode
    {
        private BTNode[] inputNodes;
        public Sequence(BlackBoard blackBoard, params BTNode[] input)
        {
            base.blackBoard = blackBoard;
            inputNodes = input;
        }

        public override BTNodeStatus Tick()
        {
            foreach(BTNode node in inputNodes)
            {
                BTNodeStatus result = node.Tick();
                switch (result)
                {
                    case BTNodeStatus.Failed:
                        return result;
                    case BTNodeStatus.Running:
                        return result;
                    case BTNodeStatus.Succes:
                        continue;
                }
            }
            return BTNodeStatus.Succes;
        }
    }
}
