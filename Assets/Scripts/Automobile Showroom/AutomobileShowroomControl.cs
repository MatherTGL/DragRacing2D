using Boot;
using Config;
using Garage;
using Garage.PlayerCar;
using Garage.PlayerCar.Purchased;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Showroom
{
    public sealed class AutomobileShowroomControl : MonoBehaviour, IBoot, IShowroomControl
    {
        [ShowInInspector]
        private const string pathConfigsCarLoad = "Configs/Cars";

        private IGarageControl _IgarageControl;
        IGarageControl IShowroomControl.IgarageControl => _IgarageControl;

        private IShowroomModel _IshowroomModel;

        private IShowroomView _IshowroomView;

        [SerializeField, ReadOnly]
        private ConfigCarEditor[] _availableCarsForPurchase;
        ConfigCarEditor[] IShowroomControl.availableCarsForPurchase => _availableCarsForPurchase;


        private AutomobileShowroomControl() { }

        void IBoot.InitAwake()
        {
            Debug.Log("Showroom init");
            if (_IshowroomModel == null && _IshowroomView == null)
            {
                DontDestroyOnLoad(this);
                _IgarageControl = FindObjectOfType<GarageControl>();
                _availableCarsForPurchase = Resources.LoadAll<ConfigCarEditor>(pathConfigsCarLoad);

                var config = _availableCarsForPurchase[0];
                var baseCar = new PurchasedCar(config);
                _IgarageControl.purchasedCars.SetBaseCar(baseCar);
                PlayerSelectedCar.SetBasePlayerCar(baseCar);

                _IshowroomModel = new AutomobileShowroomModel(this);
                _IshowroomView = new AutomobileShowroomView(this);
            }
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.MediumImportant, Bootstrap.TypeSingleOrLotsOf.LotsOf);
        }

        private bool CheckAvailabilityMachinePurchased()
        {
            for (byte i = 1; i < _IgarageControl.purchasedCars.listPurchasedCars.Count; i++)
                for (byte a = 1; a < _availableCarsForPurchase.Length; a++)
                    if (_IgarageControl.purchasedCars.listPurchasedCars[i].config == _availableCarsForPurchase[a])
                        return true;
            return false;
        }

        void IShowroomControl.BuyCar(in byte indexCar)
        {
            if (CheckAvailabilityMachinePurchased())
            {
                Debug.Log("Car buyed");
                return;
            }

            _IshowroomModel.BuyCar(indexCar);
            _IshowroomView.BuyCar();
        }
    }
}
