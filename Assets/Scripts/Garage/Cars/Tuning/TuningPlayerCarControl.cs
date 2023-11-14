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
        [SerializeField, MinValue(0), BoxGroup("Parameters"), DisableInEditorMode]
        private byte _carIndex;
#endif

        [Button("Tuning Power"), BoxGroup("Parameters/Engine"), DisableInEditorMode]
        public void TuningCarPower()
        {
            if (_IpurchasedCars.GetCar(_carIndex) == null)
                return;

            _ItuningCarModel.TuningCarPower(_carIndex);
            _ItuningCarView.TuningCarPower(_carIndex);
        }

        [Button("Tuning Brake Power"), BoxGroup("Parameters/Brake"), DisableInEditorMode]
        public void TuningCarBrakePower()
        {
            if (_IpurchasedCars.GetCar(_carIndex) == null)
                return;

            _ItuningCarModel.TuningCarBrakePower(_carIndex);
            _ItuningCarView.TuningCarBrakePower(_carIndex);
        }

        [Button("Tuning Stage"), BoxGroup("Parameters/Engine"), DisableInEditorMode]
        public void TuningCarStage()
        {
            if (_IpurchasedCars.GetCar(_carIndex) == null)
                return;

            _ItuningCarModel.TuningCarStage(_carIndex);
            _ItuningCarView.TuningCarStage(_carIndex);
        }
    }
}
