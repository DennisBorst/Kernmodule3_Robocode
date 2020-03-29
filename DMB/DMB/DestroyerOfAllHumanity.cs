using System;
using System.Collections;
using System.Drawing;
using Robocode;

namespace DMB
{
    public class DestroyerOfAllHumanity : AdvancedRobot
    {
        public BTNode BehaviourTree;
        public BlackBoard blackBoard = new BlackBoard();

        private bool activated = false;

        public override void Run()
        {
            Start();

            while (true)
            {
                Update();
            }
        }

        private void Start()
        {
            blackBoard.robot = this;
            IsAdjustRadarForGunTurn = true;

            BTNode ShootBehaviour = new Sequence(blackBoard,
               new SetColor(blackBoard, Color.Red),
               new ScanRobot(blackBoard, 90),
               new InRange(blackBoard, 1000),
               new TurnGunShoot(blackBoard));

            BTNode WalkBehaviour = new Sequence(blackBoard,
                new SetColor(blackBoard, Color.Blue),
                new MoveAhead(blackBoard, 200),
                new Turn(blackBoard, 60));

            BTNode BashBehaviour = new Sequence(blackBoard,
                new ScanRobot(blackBoard, 360),
                new InRange(blackBoard, 300),
                new SetColor(blackBoard, Color.Black),
                new Bash(blackBoard));

            BTNode ShootWalk = new Selector(blackBoard,
                ShootBehaviour,
                WalkBehaviour);

            BTNode BashWalkBehaviour = new Selector(blackBoard,
                BashBehaviour,
                WalkBehaviour);

            BTNode FullHP = new Sequence(blackBoard,
                new BTNodeFloatEnergy(blackBoard, 50, BTNodeFloatEnergy.CompareEnum.Larger),
                BashWalkBehaviour);

            BTNode LowHP = new Sequence(blackBoard,
                new BTNodeFloatEnergy(blackBoard, 50, BTNodeFloatEnergy.CompareEnum.Smaller),
                ShootWalk);

            BehaviourTree = new Selector(blackBoard, FullHP, LowHP);
        }

        private void Update()
        {
            BehaviourTree.Tick();
        }

        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            Out.WriteLine("I scanned a Robot: " + evnt.Name);
            blackBoard.lastScannedRobotEvent = evnt;
        }
    }
}
