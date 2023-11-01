using UnityEngine;

namespace Racing
{
    public sealed class RacingModel : IRacingModel
    {
        private IRacingControl _IracingControl;


        public RacingModel(in IRacingControl IracingControl)
        {
            _IracingControl = IracingControl;
        }

        void IRacingModel.StartRacing()
        {
            _IracingControl.IrivalsControl.StartRacing();
            Debug.Log(_IracingControl.IgarageControl.GetCurrentCar().currentClassCar);
        }
    }
}
