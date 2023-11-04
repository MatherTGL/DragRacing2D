using Garage.PlayerCar.Purchased;
using Sirenix.OdinInspector;
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

#if UNITY_EDITOR
        [SerializeField, MinValue(0)]
        private byte _carIndex;
#endif

        [Button("Tuning Power"), BoxGroup("Engine")]
        public void TuningCarPower()
        {
            IPurchasedCar car = _IpurchasedCars.GetCar(_carIndex);
            if (car == null)
                return;

            _ItuningCarModel.TuningCarPower(car);
            _ItuningCarView.TuningCarPower(car);
        }
    }
}
