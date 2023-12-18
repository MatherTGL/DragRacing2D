using System;
using System.Collections.Generic;
using Boot;
using Boot.SceneLoader;
using Garage.PlayerCar;
using Player.Data;
using Showroom;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;
using YG;

namespace Garage.UI
{
    [RequireComponent(typeof(ShowroomCarPool))]
    public sealed class GarageView : MonoBehaviour, IBoot
    {
        private IGarageControl _IgarageControl;

        private ShowroomCarPool _showroomCarPool;

        [SerializeField, Required]
        private SceneLoader _sceneLoader;

        [SerializeField, Required]
        private AudioSource _audioSourceClickButton;

        [SerializeField, Required]
        private Image _carForwardWheelSprite;

        [SerializeField, Required]
        private Image _carBackWheelSprite;

        [SerializeField, Required]
        private Text _playerMoneyText;

        [SerializeField, Required]
        private Text _nameCarText;

        [SerializeField, Required]
        private GameObject _adConfirmationDashboard;

        [SerializeField, Required]
        private Button _buttonSellCar;

        [SerializeField]
        private int _addedMoney;

        private byte _currentCarIndex;


        void IBoot.InitAwake()
        {
            _IgarageControl = FindObjectOfType<GarageControl>();
            _showroomCarPool = GetComponent<ShowroomCarPool>();
            _sceneLoader ??= FindObjectOfType<SceneLoader>();
            _nameCarText.text = $"{PlayerSelectedCar.selectedCar.config.nameCar}";

            for (int i = 0; i < _showroomCarPool.poolAllCars.Count; i++)
            {
                if (_showroomCarPool.poolAllCars[i].name == PlayerSelectedCar.selectedCar.config.fullCarSprite.name)
                    _showroomCarPool.poolAllCars[i].SetActive(true);
                else
                    _showroomCarPool.poolAllCars[i].SetActive(false);
            }

            if (PlayerSelectedCar.selectedCar.bodyColor.a < 1.0f)
                UpdateColor(PlayerSelectedCar.selectedCar.config.carColor);
            else
                UpdateColor(PlayerSelectedCar.selectedCar.bodyColor);


            if (YandexGame.savesData.color[0] != 0f || YandexGame.savesData.color[1] != 0f)
            {
                float colorR = YandexGame.savesData.color[0];
                float colorG = YandexGame.savesData.color[1];
                float colorB = YandexGame.savesData.color[2];

                Color color = new Color(colorR, colorG, colorB);
                UpdateColor(color);
            }

            CheckSellAvailable();
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        public void SwipeAndChangeCar(bool isLeft)
        {
            StartAudioClickButton();
            if (isLeft && _currentCarIndex > 0)
                _currentCarIndex--;
            else if (isLeft == false && _currentCarIndex < _IgarageControl.purchasedCars.listPurchasedCars.Count - 1)
                _currentCarIndex++;

            _IgarageControl.ChangeCar(_currentCarIndex);
            for (int i = 0; i < _showroomCarPool.poolAllCars.Count; i++)
            {
                if (_showroomCarPool.poolAllCars[i].name == PlayerSelectedCar.selectedCar.config.fullCarSprite.name)
                    _showroomCarPool.poolAllCars[i].SetActive(true);
                else
                    _showroomCarPool.poolAllCars[i].SetActive(false);
            }

            CheckSellAvailable();
            _nameCarText.text = $"{PlayerSelectedCar.selectedCar.config.nameCar}";
        }

        public void SellCar()
        {
            StartAudioClickButton();
            _IgarageControl.SellCar(_currentCarIndex);
        }

        public void StartRacing()
        {
            StartAudioClickButton();
            int randomIndexScene = UnityEngine.Random.Range(5, 8);
            _sceneLoader.LoadScene(randomIndexScene);
        }

        private void LateUpdate()
        {
            ChangedTextPlayerMoney();
        }

        private void ChangedTextPlayerMoney()
        {
            _playerMoneyText.text = String.Format("{0,12:C2}", GamePlayerData.GetAmountMoney());
        }

        public void StartAudioClickButton()
        {
            _audioSourceClickButton.Play();
        }

        private void UpdateColor(Color customColor)
        {
            for (int i = 0; i < _showroomCarPool.poolAllCars.Count; i++)
            {
                if (_showroomCarPool.poolAllCars[i].name == PlayerSelectedCar.selectedCar.config.machineByParts.name)
                    _showroomCarPool.poolAllCars[i].GetComponentInChildren<CarTeloComponent>().ChangeColor(customColor);
                else
                    _showroomCarPool.poolAllCars[i].SetActive(false);
            }
        }

        public void ShowConfirmPanelAd()
        {
            _adConfirmationDashboard.SetActive(!_adConfirmationDashboard.activeSelf);
        }

        public void AddedMoney()
        {
            GamePlayerData.AddMoney(_addedMoney);
        }

        private void CheckSellAvailable()
        {
            if (_currentCarIndex == 0)
                _buttonSellCar.interactable = false;
            else
                _buttonSellCar.interactable = true;
        }
    }
}
