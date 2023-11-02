using UnityEngine;

namespace Garage.PlayerCar.Tuning
{
    public sealed class TuningPlayerCarControl : MonoBehaviour, ITuningCarControl
    {
        private IPurchasedCarsTuning _IpurchasedCars;


        private TuningPlayerCarControl() { }

        void ITuningCarControl.Init(in IPurchasedCarsTuning purchasedCars)
        {
            _IpurchasedCars = purchasedCars;
        }
    }
}
