using Boot;
using Garage.PlayerCar;
using Garage.PlayerCar.Purchased;
using Garage.PlayerCar.Tuning;
using Garage.Purchased;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Garage
{
    public sealed class GarageControl : MonoBehaviour, IGarageControl, IBoot, ITransportReplenishment
    {
        private IGarageModel _IgarageModel;

        private IGarageView _IgarageView;

        private IPurchasedCars _IpurchasedCars = new PurchasedCars();
        IPurchasedCars IGarageControl.purchasedCars => _IpurchasedCars;


        private GarageControl() { }

        void IBoot.InitAwake()
        {
            DontDestroyOnLoad(this);

            ITuningCarControl tuningControl = FindObjectOfType<TuningPlayerCarControl>();
            tuningControl.Init((IPurchasedCarsTuning)_IpurchasedCars);

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

        void ITransportReplenishment.AddNewTransportation(in IPurchasedCar purchasedCar)
        {
            _IgarageModel.AddNewTransportation(purchasedCar);
            _IgarageView.AddNewTransportation(purchasedCar);
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
    }
}
