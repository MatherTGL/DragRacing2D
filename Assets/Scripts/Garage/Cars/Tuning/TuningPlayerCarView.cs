using UnityEngine;

namespace Garage.PlayerCar.Tuning
{
    public sealed class TuningPlayerCarView : ITuningCarView
    {
        private ITuningCarControl _ItuningCarControl;


        public TuningPlayerCarView(in ITuningCarControl tuningCarControl)
        {
            _ItuningCarControl = tuningCarControl;
        }

        void ITuningCarView.TuningCarPower(in byte carIndex)
        {
            Debug.Log($"{_ItuningCarControl.IpurchasedCarsTuning.GetCar(carIndex).currentPower}");
        }
    }
}
