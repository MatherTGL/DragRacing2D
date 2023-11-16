using System.Collections.Generic;
using Boot;
using Boot.SceneLoader;
using Garage.PlayerCar;
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
        private Image _carBodySprite;

        private byte _currentCarIndex;


        void IBoot.InitAwake()
        {
            _IgarageControl = FindObjectOfType<GarageControl>();
            _sceneLoader ??= FindObjectOfType<SceneLoader>();
            _carBodySprite.sprite = PlayerSelectedCar.selectedCar.bodyImage.sprite;
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        public void SwipeAndChangeCar(bool isLeft)
        {
            if (isLeft && _currentCarIndex > 0)
                _currentCarIndex--;
            else if (isLeft == false && _currentCarIndex < _IgarageControl.purchasedCars.listPurchasedCars.Count - 1)
                _currentCarIndex++;

            _IgarageControl.ChangeCar(_currentCarIndex);
            _carBodySprite.sprite = PlayerSelectedCar.selectedCar.config.bodySprite;
        }

        public void SellCar() => _IgarageControl.SellCar(_currentCarIndex);

        public void StartRacing()
        {
            int randomIndexScene = Random.Range(5, 8);
            _sceneLoader.LoadScene(randomIndexScene);
        }
    }
}
