using Boot;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Garage.PlayerCar.Tuning.UI
{
    public sealed class TuningView : MonoBehaviour, IBoot
    {
        private ITuningCarControl _ItuningCarControl;

        [SerializeField, Required]
        private AudioSource _audioSourceClickButton;

        [SerializeField, Required]
        private Text _currentStageLevelText;

        [SerializeField, Required]
        private Text _currentPowerText;

        [SerializeField, Required]
        private Text _currentBrakePowerText;

        [SerializeField, Required]
        private Text _currentMaxSpeed;


        void IBoot.InitAwake()
        {
            _ItuningCarControl = FindObjectOfType<TuningPlayerCarControl>();
            Debug.Log(PlayerSelectedCar.selectedCar.currentPower);
            _currentStageLevelText.text = $"Stage: {PlayerSelectedCar.selectedCar.stage}";
            _currentPowerText.text = $"Power Brake: {PlayerSelectedCar.selectedCar.currentPower}";
            _currentBrakePowerText.text = $"Power Brake: {PlayerSelectedCar.selectedCar.currentBrakePower}";
            _currentMaxSpeed.text = $"Max Speed: {PlayerSelectedCar.selectedCar.maxSpeed}";
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        public void TuningStage()
        {
            StartAudioClickButton();
            _ItuningCarControl.TuningCarStage();
            _currentStageLevelText.text = $"Stage: {PlayerSelectedCar.selectedCar.stage}";
            _currentPowerText.text = $"Power Brake: {PlayerSelectedCar.selectedCar.currentPower}";
            _currentMaxSpeed.text = $"Max Speed: {PlayerSelectedCar.selectedCar.maxSpeed}";
        }

        public void TuningPower()
        {
            StartAudioClickButton();
            _ItuningCarControl.TuningCarPower();
            _currentPowerText.text = $"Power Brake: {PlayerSelectedCar.selectedCar.currentPower}";
            _currentMaxSpeed.text = $"Max Speed: {PlayerSelectedCar.selectedCar.maxSpeed}";
        }

        public void TuningBrake()
        {
            StartAudioClickButton();
            _ItuningCarControl.TuningCarBrakePower();
            _currentBrakePowerText.text = $"Power Brake: {PlayerSelectedCar.selectedCar.currentBrakePower}";
        }

        public void StartAudioClickButton()
        {
            _audioSourceClickButton.Play();
        }
    }
}
