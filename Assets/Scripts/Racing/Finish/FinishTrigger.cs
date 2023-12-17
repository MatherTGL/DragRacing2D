using System;
using Player.Movement;
using Racing.Rivals;
using UnityEngine;
using YG;

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
                YandexGame.savesData.playerWinnerValue = 0;
                YandexGame.SaveProgress();
                return;
            
            }
            else if (other.GetComponent<PlayerMovementControl>())
            {
                finished.Invoke(RacingControl.WhoFinished.Player);
                YandexGame.savesData.playerWinnerValue += 1;
                RecordChecker();
                YandexGame.SaveProgress();
                return;
            }
        }

        private void RecordChecker()
        {
            if(YandexGame.savesData.playerWinnerRecord < YandexGame.savesData.playerWinnerValue)
            {
                YandexGame.savesData.playerWinnerRecord = YandexGame.savesData.playerWinnerValue;
                Debug.Log("newrecord");
                YandexGame.SaveProgress();
            }
        }
    }
}

