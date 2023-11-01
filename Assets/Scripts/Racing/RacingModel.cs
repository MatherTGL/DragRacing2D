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
            _IracingControl.IrivalsControl.SetRival(_IracingControl.IgarageControl.GetCurrentCar());
            _isRacingStarted = true;
            Debug.Log(_IracingControl.IgarageControl.GetCurrentCar().currentClassCar);
        }
    }
}
