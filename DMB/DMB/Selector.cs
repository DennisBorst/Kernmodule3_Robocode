using System;
using System.Collections.Generic;
using System.Text;

namespace DMB
{

    /// <summary>
    /// The Selector runs all input nodes and returns succes if an input nodes returns succes
    /// </summary>
    public class Selector : BTNode
    {
        private BTNode[] inputNodes;
        public Selector(BlackBoard blackBoard, params BTNode[] input)
        {
            base.blackBoard = blackBoard;
            inputNodes = input;
        }

        public override BTNodeStatus Tick()
        {
            foreach (BTNode node in inputNodes)
            {
                BTNodeStatus result = node.Tick();
                switch (result)
                {
                    case BTNodeStatus.Failed:
                        continue;
                    case BTNodeStatus.Running:
                        return BTNodeStatus.Running; //kan ook "return result"
                    case BTNodeStatus.Succes:
                        return BTNodeStatus.Succes; //kan ook "return result"
                }
            }
            return BTNodeStatus.Failed;
        }
    }
}
