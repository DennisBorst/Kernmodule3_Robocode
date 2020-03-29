using System;
using System.Collections.Generic;
using System.Text;
using Robocode.Util;

namespace DMB
{
    public class TurnGunShoot : BTNode
    {
        private float degrees;

        public TurnGunShoot(BlackBoard blackBoard)
        {
            this.blackBoard = blackBoard;
        }

        public override BTNodeStatus Tick()
        {
            if (blackBoard.lastScannedRobotEvent != null)
            {
                blackBoard.robot.IsAdjustGunForRobotTurn = true;

                double absoluteBearing = blackBoard.robot.Heading + blackBoard.lastScannedRobotEvent.Bearing;
                double bearingFromGun = Utils.NormalRelativeAngleDegrees(absoluteBearing - blackBoard.robot.GunHeading);

                if (Math.Abs(bearingFromGun) <= 3)
                {
                    blackBoard.robot.TurnGunRight(bearingFromGun);
                    if (blackBoard.robot.GunHeat == 0)
                    {
                        blackBoard.robot.Fire(Math.Min(3 - Math.Abs(bearingFromGun), blackBoard.robot.Energy - .1));
                        return BTNodeStatus.Succes;
                    }
                }
                else
                {
                    blackBoard.robot.TurnGunRight(bearingFromGun);
                    return BTNodeStatus.Running;
                }
            }

            return BTNodeStatus.Failed;
        }
    }
}
