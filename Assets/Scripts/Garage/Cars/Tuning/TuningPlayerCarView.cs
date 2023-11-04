using Garage.PlayerCar.Purchased;
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

        void ITuningCarView.TuningCarPower(in IPurchasedCar car)
        {
            Debug.Log("Upgrade power car");
        }
    }
}
