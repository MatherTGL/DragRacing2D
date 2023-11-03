using Boot;
using Garage.PlayerCar;
using Garage.PlayerCar.Purchased;
using Garage.PlayerCar.Tuning;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Garage
{
    public sealed class GarageControl : MonoBehaviour, IGarageControl, IBoot
    {
        private IGarageModel _IgarageModel;

        private IGarageView _IgarageView;

        ITuningCarControl _ItuningControl;

        private IPurchasedCars _IpurchasedCars = new PurchasedCars();
        IPurchasedCars IGarageControl.purchasedCars => _IpurchasedCars;


        private GarageControl() { }

        void IBoot.InitAwake()
        {
            DontDestroyOnLoad(this);

            _ItuningControl = FindObjectOfType<TuningPlayerCarControl>();
            _ItuningControl.Init((IPurchasedCarsTuning)_IpurchasedCars);

            _IgarageModel = new GarageModel(this);
            _IgarageView = new GarageView(this);
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        IPurchasedCar IGarageControl.GetCurrentCar()
        {
            Debug.Log(PlayerSelectedCar.selectedCar);
            return PlayerSelectedCar.selectedCar;
        }

        [Button("Sell car")]
        public void SellCar()
        {
            _IgarageModel.SellCar(null); //!
            _IgarageView.SellCar();
        }

        [Button("Change car")]
        public void ChangeCar(in byte indexCar)
        {
            PlayerSelectedCar.SetCurrentPlayerCar(_IpurchasedCars.listPurchasedCars[indexCar]);
        }

        [Button("Send Car for Tuning")]
        public void SendCarForTuning(in byte indexCar)
        {
            if (_IpurchasedCars.listPurchasedCars[indexCar] is not { })
                _ItuningControl.SendCarForTuning(indexCar);
        }

#if UNITY_EDITOR
        [Button("Get Parameters Car")]
        public void GetParametersCar(in byte indexCar)
        {
            if (_IpurchasedCars.listPurchasedCars.Count < indexCar)
                Debug.Log(_IpurchasedCars.listPurchasedCars[indexCar].currentPower);
        }
#endif
    }
}
