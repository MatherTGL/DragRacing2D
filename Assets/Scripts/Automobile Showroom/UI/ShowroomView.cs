using Boot;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Showroom.UI
{
    [RequireComponent(typeof(ShowroomCarPool))]
    public sealed class ShowroomView : MonoBehaviour, IBoot
    {
        private IShowroomControl _IshowroomControl;

        private ShowroomCarPool _showroomCarPool;

        [SerializeField, Required]
        private Image _bodyCarSprite;

        private byte _currentSelectedIndexCar;


        void IBoot.InitAwake()
        {
            _showroomCarPool = GetComponent<ShowroomCarPool>();
            _IshowroomControl = FindObjectOfType<AutomobileShowroomControl>();
            //? _bodyCarSprite.sprite = _IshowroomControl.availableCarsForPurchase[_currentSelectedIndexCar].fullCarSprite;
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
            //? _bodyCarSprite.sprite = _IshowroomControl.availableCarsForPurchase[_currentSelectedIndexCar].fullCarSprite;

            Debug.Log(_currentSelectedIndexCar);

            for (int i = 0; i < _showroomCarPool.poolAllCars.Count; i++)
            {
                if (_showroomCarPool.poolAllCars[i].name == _IshowroomControl.availableCarsForPurchase[_currentSelectedIndexCar].fullCarSprite.name)
                    _showroomCarPool.poolAllCars[i].SetActive(true);
                else
                    _showroomCarPool.poolAllCars[i].SetActive(false);
            }

            Debug.Log(_IshowroomControl.availableCarsForPurchase[_currentSelectedIndexCar]);
        }
    }
}
