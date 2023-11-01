using System;
using Player.Movement;
using Racing.Rivals;
using UnityEngine;

namespace Racing.Triggers
{
    public sealed class FinishTrigger : MonoBehaviour
    {
        public event Action<RacingControl.WhoFinished> finished;

        private bool _isFinished;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (_isFinished)
                return;

            _isFinished = true;

            if (other.GetComponent<RivalCar>())
            {
                finished.Invoke(RacingControl.WhoFinished.Rival);
                return;
            }
            else if (other.GetComponent<PlayerMovementControl>())
            {
                finished.Invoke(RacingControl.WhoFinished.Player);
                return;
            }
        }
    }
}

