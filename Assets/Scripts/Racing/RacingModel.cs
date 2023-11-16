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
            if (finished is RacingControl.WhoFinished.Rival)
                GamePlayerData.SpendMoney(500); //! hardcode
            else
                GamePlayerData.AddMoney(500); //! hardcode

            Debug.Log(finished);
        }
    }
}
