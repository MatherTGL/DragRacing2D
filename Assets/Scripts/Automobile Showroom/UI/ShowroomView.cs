using Boot;
using UnityEngine;

namespace Showroom.UI
{
    public sealed class ShowroomView : MonoBehaviour, IBoot
    {
        private IShowroomControl _IshowroomControl;

        private byte _currentSelectedIndexCar;


        void IBoot.InitAwake()
        {
            _IshowroomControl = FindObjectOfType<AutomobileShowroomControl>();
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        public void BuyCar()
        {
            Debug.Log(_IshowroomControl.availableCarsForPurchase[_currentSelectedIndexCar]);
            _IshowroomControl.BuyCar(_currentSelectedIndexCar);
        }

        public void SwipeAndChangeCar(bool isLeft)
        {
            if (isLeft && _currentSelectedIndexCar > 0)
                _currentSelectedIndexCar--;
            else if (isLeft == false && _currentSelectedIndexCar < _IshowroomControl.availableCarsForPurchase.Length - 1)
                _currentSelectedIndexCar++;

            Debug.Log(_IshowroomControl.availableCarsForPurchase[_currentSelectedIndexCar]);
        }
    }
}
