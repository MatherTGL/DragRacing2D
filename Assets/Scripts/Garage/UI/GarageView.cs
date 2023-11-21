using System;
using System.Collections.Generic;
using Boot;
using Boot.SceneLoader;
using Garage.PlayerCar;
using Player.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Garage.UI
{
    public sealed class GarageView : MonoBehaviour, IBoot
    {
        private IGarageControl _IgarageControl;

        [SerializeField, Required]
        private SceneLoader _sceneLoader;

        [SerializeField, Required]
        private AudioSource _audioSourceClickButton;

        [SerializeField, Required]
        private Image _carBodySprite;

        [SerializeField, Required]
        private Image _carForwardWheelSprite;

        [SerializeField, Required]
        private Image _carBackWheelSprite;

        [SerializeField, Required]
        private Text _playerMoneyText;

        [SerializeField, Required]
        private Text _nameCarText;

        private byte _currentCarIndex;


        void IBoot.InitAwake()
        {
            _IgarageControl = FindObjectOfType<GarageControl>();
            _sceneLoader ??= FindObjectOfType<SceneLoader>();
            _carBodySprite.sprite = PlayerSelectedCar.selectedCar.bodyImage;
            _nameCarText.text = $"{PlayerSelectedCar.selectedCar.config.nameCar}";
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
            Debug.Log(_currentCarIndex);

            _IgarageControl.ChangeCar(_currentCarIndex);
            _carBodySprite.sprite = PlayerSelectedCar.selectedCar.config.bodySprite;

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
            Debug.Log("fsdf");
            _playerMoneyText.text = String.Format("${0,12:C2}", GamePlayerData.GetAmountMoney());
        }

        public void StartAudioClickButton()
        {
            _audioSourceClickButton.Play();
        }
    }
}
