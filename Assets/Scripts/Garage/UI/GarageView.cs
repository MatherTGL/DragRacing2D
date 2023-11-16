using Boot;
using Boot.SceneLoader;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Garage.UI
{
    public sealed class GarageView : MonoBehaviour, IBoot
    {
        private IGarageControl _IgarageControl;

        [SerializeField, Required]
        private SceneLoader _sceneLoader;

        private byte _currentCarIndex;


        void IBoot.InitAwake()
        {
            _IgarageControl = FindObjectOfType<GarageControl>();
            _sceneLoader ??= FindObjectOfType<SceneLoader>();
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
        }

        public void SellCar()
        {
            _IgarageControl.SellCar(_currentCarIndex);
        }

        public void StartRacing()
        {
            int randomIndexScene = Random.Range(5, 8);
            _sceneLoader.LoadScene(randomIndexScene);
        }
    }
}
