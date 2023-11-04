using UnityEngine;

namespace Garage.PlayerCar.Tuning
{
    public sealed class TuningPlayerCarControl : MonoBehaviour, ITuningCarControl
    {
        private IPurchasedCarsTuning _IpurchasedCars;
        IPurchasedCarsTuning ITuningCarControl.IpurchasedCarsTuning => _IpurchasedCars;

        private ITuningCarModel _ItuningCarModel;

        private ITuningCarView _ItuningCarView;


        private TuningPlayerCarControl() { }

        void ITuningCarControl.Init(in IPurchasedCarsTuning purchasedCars)
        {
            _IpurchasedCars = purchasedCars;

            _ItuningCarModel = new TuningPlayerCarModel(this);
            _ItuningCarView = new TuningPlayerCarView(this);
        }

        // void ITuningCarControl.SendCarForTuning(in byte indexCar)
        // {
        //     Debug.Log(_IpurchasedCars.GetCar(indexCar).currentPower);
        //     _ItuningCarModel.SendCarForTuning(indexCar);
        //     _ItuningCarView.SendCarForTuning();
        // }
    }
}
