using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Garage.PlayerCar.Tuning
{
    public sealed class TuningPlayerCarControl : MonoBehaviour, ITuningCarControl
    {
        private const string _NameWorkedScene = "Tuning";

        private IPurchasedCarsTuning _IpurchasedCars;
        IPurchasedCarsTuning ITuningCarControl.IpurchasedCarsTuning => _IpurchasedCars;

        private ITuningCarModel _ItuningCarModel;

        private ITuningCarView _ItuningCarView;


        private TuningPlayerCarControl() { }

        void ITuningCarControl.Init(in IPurchasedCarsTuning purchasedCars)
        {
            DontDestroyOnLoad(this);

            _IpurchasedCars = purchasedCars;

            _ItuningCarModel ??= new TuningPlayerCarModel(this);
            _ItuningCarView ??= new TuningPlayerCarView(this);
        }


#if UNITY_EDITOR
        [SerializeField, MinValue(0), BoxGroup("Parameters"), DisableInEditorMode]
        private byte _carIndex;
#endif

        void ITuningCarControl.TuningCarPower()
        {
            _ItuningCarModel.TuningCarPower();
            _ItuningCarView.TuningCarPower();
        }

        void ITuningCarControl.TuningCarBrakePower()
        {
            _ItuningCarModel.TuningCarBrakePower();
            _ItuningCarView.TuningCarBrakePower();
        }

        void ITuningCarControl.TuningCarStage()
        {
            _ItuningCarModel.TuningCarStage();
            _ItuningCarView.TuningCarStage();
        }
    }
}
