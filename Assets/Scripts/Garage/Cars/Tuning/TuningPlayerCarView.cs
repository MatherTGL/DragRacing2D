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

        void ITuningCarView.TuningCarBrakePower()
        {
            Debug.Log($"{PlayerSelectedCar.selectedCar.currentBrakePower}");
        }

        void ITuningCarView.TuningCarPower()
        {
            Debug.Log($"{PlayerSelectedCar.selectedCar.currentPower}");
        }

        void ITuningCarView.TuningCarStage()
        {
            Debug.Log($"{PlayerSelectedCar.selectedCar.stage}");
        }
    }
}
