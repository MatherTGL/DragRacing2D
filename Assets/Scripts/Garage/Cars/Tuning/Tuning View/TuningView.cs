using Boot;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Garage.PlayerCar.Tuning.UI
{
    public sealed class TuningView : MonoBehaviour, IBoot
    {
        private ITuningCarControl _ItuningCarControl;

        [SerializeField, Required]
        private AudioSource _audioSourceClickButton;


        void IBoot.InitAwake()
        {
            _ItuningCarControl = FindObjectOfType<TuningPlayerCarControl>();
            Debug.Log(PlayerSelectedCar.selectedCar.currentPower);
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        public void TuningStage()
        {
            StartAudioClickButton();
            _ItuningCarControl.TuningCarStage();
        }

        public void TuningPower()
        {
            StartAudioClickButton();
            _ItuningCarControl.TuningCarPower();
        }

        public void TuningBrake()
        {
            StartAudioClickButton();
            _ItuningCarControl.TuningCarBrakePower();
        }

        public void StartAudioClickButton()
        {
            _audioSourceClickButton.Play();
        }
    }
}
