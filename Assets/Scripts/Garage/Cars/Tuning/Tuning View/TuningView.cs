using Boot;
using UnityEngine;

namespace Garage.PlayerCar.Tuning.UI
{
    public sealed class TuningView : MonoBehaviour, IBoot
    {
        private ITuningCarControl _ItuningCarControl;


        void IBoot.InitAwake()
        {
            _ItuningCarControl = FindObjectOfType<TuningPlayerCarControl>();
            Debug.Log(PlayerSelectedCar.selectedCar.currentPower);
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        public void TuningStage() => _ItuningCarControl.TuningCarStage();

        public void TuningPower() => _ItuningCarControl.TuningCarPower();

        public void TuningBrake() => _ItuningCarControl.TuningCarBrakePower();
    }
}
