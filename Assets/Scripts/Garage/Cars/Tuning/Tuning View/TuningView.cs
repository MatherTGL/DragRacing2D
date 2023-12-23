using Boot;
using Showroom;
using Sirenix.OdinInspector;

using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Garage.PlayerCar.Tuning.UI
{
    public sealed class TuningView : MonoBehaviour, IBoot
    {
        private ITuningCarControl _ItuningCarControl;

        private ShowroomCarPool _showroomCarPool;

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

        [SerializeField, Required]
        private Color _colorBody;
        public string stagestr;
        public enum ColorType : byte { red, orange, blue, white, darkGreen, purple, grey, darkBlue, brown }
        private ColorType _currentColorType;


        void IBoot.InitAwake()
        {
            _ItuningCarControl = FindObjectOfType<TuningPlayerCarControl>();
            Debug.Log(PlayerSelectedCar.selectedCar.currentPower);
            stagestr     = PlayerSelectedCar.selectedCar.stage.ToString() ;
            _currentStageLevelText.text = "Стейдж:  " +stagestr[stagestr.Length-1];
            _currentPowerText.text = "Мощность тормоза: " + PlayerSelectedCar.selectedCar.currentPower;
            _currentBrakePowerText.text = "Мощность тормоза: " + PlayerSelectedCar.selectedCar.currentBrakePower;
            _currentMaxSpeed.text = "Макс.скорость: " + PlayerSelectedCar.selectedCar.maxSpeed;

            _showroomCarPool = GetComponent<ShowroomCarPool>();
            FindCar();

            for (int i = 0; i < _showroomCarPool.poolAllCars.Count; i++)
            {
                if (_showroomCarPool.poolAllCars[i].name == PlayerSelectedCar.selectedCar.config.machineByParts.name)
                {
                    if (PlayerSelectedCar.selectedCar.bodyColor.a < 1.0f)
                        PlayerSelectedCar.selectedCar.bodyColor = PlayerSelectedCar.selectedCar.config.carColor;
                    else
                        _showroomCarPool.poolAllCars[i].GetComponentInChildren<CarTeloComponent>().ChangeColor(PlayerSelectedCar.selectedCar.bodyColor);
                    Debug.Log(_showroomCarPool.poolAllCars[i].GetComponentInChildren<CarTeloComponent>());
                }
                else
                {
                    _showroomCarPool.poolAllCars[i].SetActive(false);
                }
            }
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        public void TuningStage()
        {
            StartAudioClickButton();
            _ItuningCarControl.TuningCarStage();
            _currentStageLevelText.text = "Cтейдж:  " + stagestr[stagestr.Length - 1];
            _currentPowerText.text = "Мощность тормоза: " + PlayerSelectedCar.selectedCar.currentPower;
            _currentMaxSpeed.text = "Макс.скорость: " + PlayerSelectedCar.selectedCar.maxSpeed;
        }

        public void TuningPower()
        {
            StartAudioClickButton();
            _ItuningCarControl.TuningCarPower();
            _currentPowerText.text = "Мощность тормоза: " + PlayerSelectedCar.selectedCar.currentPower;
            _currentMaxSpeed.text = "Макс.скорость: " + PlayerSelectedCar.selectedCar.maxSpeed;
        }

        public void TuningBrake()
        {
            StartAudioClickButton();
            _ItuningCarControl.TuningCarBrakePower();
            _currentBrakePowerText.text = "Макс.скорость: " + PlayerSelectedCar.selectedCar.currentBrakePower;
        }

        public void StartAudioClickButton()
        {
            _audioSourceClickButton.Play();
        }

        private void FindCar()
        {
            for (int i = 0; i < _showroomCarPool.poolAllCars.Count; i++)
            {
                if (_showroomCarPool.poolAllCars[i].name == PlayerSelectedCar.selectedCar.config.machineByParts.name)
                {
                    _showroomCarPool.poolAllCars[i].SetActive(true);
                    Debug.Log(PlayerSelectedCar.selectedCar.config.nameCar);
                }
                else
                {
                    _showroomCarPool.poolAllCars[i].SetActive(false);
                }
            }
        }

        public void ChangeColor()
        {
            for (int i = 0; i < _showroomCarPool.poolAllCars.Count; i++)
            {
                if (_showroomCarPool.poolAllCars[i].name == PlayerSelectedCar.selectedCar.config.machineByParts.name)
                {
                    Debug.Log(_showroomCarPool.poolAllCars[i].GetComponentInChildren<CarTeloComponent>());
                    _showroomCarPool.poolAllCars[i].GetComponentInChildren<CarTeloComponent>().ChangeColor(_colorBody);
                    PlayerSelectedCar.selectedCar.bodyColor = _colorBody;

                    YandexGame.savesData.color[0] = PlayerSelectedCar.selectedCar.bodyColor.r;
                    YandexGame.savesData.color[1] = PlayerSelectedCar.selectedCar.bodyColor.g;
                    YandexGame.savesData.color[2] = PlayerSelectedCar.selectedCar.bodyColor.b;
                    YandexGame.SaveProgress();
                }
                else
                {
                    _showroomCarPool.poolAllCars[i].SetActive(false);
                }
            }
        }

        public void SetColor(int colorNumber)
        {
            _currentColorType = (ColorType)colorNumber;
            Debug.Log(_currentColorType);

            if (_currentColorType == ColorType.red)
            {
                _colorBody = new Color(255, 0, 0);
                Debug.Log("red");
            }


            if (_currentColorType == ColorType.blue)
            {
                _colorBody = new Color(23f / 255f, 194f / 255f, 187f / 255f);
                Debug.Log("blue");
            }

            if (_currentColorType == ColorType.orange)
            {
                _colorBody = new Color(212f / 255f, 104f / 255f, 21f / 255f);
                Debug.Log("orange");
            }

            if (_currentColorType == ColorType.white)
            {
                Debug.Log("white");
                _colorBody = Color.white;
            }

            if (_currentColorType == ColorType.darkGreen)
            {
                _colorBody = new Color(53f / 255f, 173f / 255f, 84f / 255f);
                Debug.Log("darkgreen");
            }

            if (_currentColorType == ColorType.purple)
            {
                _colorBody = new Color(114f / 255f, 35f / 255f, 186f / 255f);
                Debug.Log("purple");
            }

            if (_currentColorType == ColorType.grey)
            {
                _colorBody = new Color(61f / 255f, 61f / 255f, 61f / 255f);
                Debug.Log("grey");
            }

            if (_currentColorType == ColorType.darkBlue)
            {
                _colorBody = new Color(23f / 255f, 10f / 255f, 164f / 255f);
                Debug.Log("darkblue");
            }

            if (_currentColorType == ColorType.brown)
            {
                _colorBody = new Color(94 / 255f, 31f / 255f, 0 / 255f);
                Debug.Log("brown");
            }

        }
    }
}
