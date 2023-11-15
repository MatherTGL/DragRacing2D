using System;
using Boot;
using UnityEngine;

namespace Garage.UI
{
    public sealed class GarageViewSelectCar : MonoBehaviour, IBoot
    {
        private IGarageControl _IgarageControl;

        private byte _currentCarIndex;


        void IBoot.InitAwake()
        {
            _IgarageControl = FindObjectOfType<GarageControl>();
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
    }
}
