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
            Debug.Log(_IracingControl.IgarageControl.GetCurrentCar().currentClassCar);
        }

        void IRacingModel.CarFinished(RacingControl.WhoFinished finished)
        {
            Debug.Log(finished);
        }
    }
}
