using Boot;
using Player.Data;
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
        private AudioSource _audioSourceClickButton;

        [SerializeField, Required]
        private Image _bodyCarSprite;

        [SerializeField, Required]
        private Text _costBuyCarText;

        [SerializeField, Required]
        private Button _buyButton;

        private byte _currentSelectedIndexCar;


        void IBoot.InitAwake()
        {
            _showroomCarPool = GetComponent<ShowroomCarPool>();
            _IshowroomControl = FindObjectOfType<AutomobileShowroomControl>();
            _costBuyCarText.text = $"${_IshowroomControl.availableCarsForPurchase[_currentSelectedIndexCar].buyCost}";

            if (_IshowroomControl.availableCarsForPurchase[_currentSelectedIndexCar].buyCost <= GamePlayerData.GetAmountMoney())
                _buyButton.interactable = true;
            else
                _buyButton.interactable = false;

            //? _bodyCarSprite.sprite = _IshowroomControl.availableCarsForPurchase[_currentSelectedIndexCar].fullCarSprite;
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        public void BuyCar()
        {
            StartAudioClickButton();
            Debug.Log(_IshowroomControl.availableCarsForPurchase[_currentSelectedIndexCar]);
            _IshowroomControl.BuyCar(_currentSelectedIndexCar);
        }

        public void SwipeAndChangeCar(bool isLeft)
        {
            StartAudioClickButton();
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

            if (_IshowroomControl.availableCarsForPurchase[_currentSelectedIndexCar].buyCost <= GamePlayerData.GetAmountMoney())
                _buyButton.interactable = true;
            else
                _buyButton.interactable = false;
            _costBuyCarText.text = $"${_IshowroomControl.availableCarsForPurchase[_currentSelectedIndexCar].buyCost}";

            Debug.Log(_IshowroomControl.availableCarsForPurchase[_currentSelectedIndexCar]);
        }

        public void StartAudioClickButton()
        {
            _audioSourceClickButton.Play();
        }
    }
}
