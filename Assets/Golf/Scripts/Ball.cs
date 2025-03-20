using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class Ball : MonoBehaviour
    {
        public bool isAffect = false;

        public static System.Action onCollisionBall;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.transform.TryGetComponent(out Ball other))
            {
                if (!other.isAffect)
                {
                    GameEvents.CollisionBallsInvoke(collision);
                }
            }
        }

    }
}