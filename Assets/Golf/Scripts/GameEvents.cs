using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public static class GameEvents
    {
        public static System.Action onCollisionBall;

        public static System.Action onStickHit;

        public static void CollisionBallsInvoke (Collision collision)
        {
            onCollisionBall?.Invoke();
        }

        public static void StickHit()
        {
            onStickHit?.Invoke();
        }
    }
}
