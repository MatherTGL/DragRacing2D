using Player.Data;
using Racing.Rivals;
using UnityEngine;

namespace Racing
{
    public sealed class RacingModel : IRacingModel
    {
        private IRacingControl _IracingControl;

        private bool _isRacingStarted;

        bool IRacingModel.isRacingStarted => _isRacingStarted;


        public RacingModel(in IRacingControl IracingControl)
        {
            _IracingControl = IracingControl;
        }

        void IRacingModel.StartRacing()
        {
            if (_isRacingStarted)
                return;

            _IracingControl.IrivalsControl.SpawnRandomRival();
            _isRacingStarted = true;
        }

        void IRacingModel.CarFinished(RacingControl.WhoFinished finished)
        {
            _isRacingStarted = false;

            if (finished is RacingControl.WhoFinished.Rival)
                GamePlayerData.SpendMoney(_IracingControl.loseMoney);
            else
                GamePlayerData.AddMoney(_IracingControl.winMoney);
        }
    }
}
