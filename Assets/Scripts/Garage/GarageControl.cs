using System.Linq;
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

        private ITuningCarControl _ItuningControl;

        private IPurchasedCars _IpurchasedCars = new PurchasedCars();
        IPurchasedCars IGarageControl.purchasedCars => _IpurchasedCars;


        private GarageControl() { }

        void IBoot.InitAwake()
        {
            DontDestroyOnLoad(this);

            if (_ItuningControl == null)
            {
                _ItuningControl = FindObjectOfType<TuningPlayerCarControl>();
                _ItuningControl.Init((IPurchasedCarsTuning)_IpurchasedCars);

                _IgarageModel = new GarageModel(this);
                _IgarageView = new GarageView(this);
            }
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        IPurchasedCar IGarageControl.GetCurrentCar() => PlayerSelectedCar.selectedCar;

        [Button("Sell car")]
        public void SellCar(in byte indexCar)
        {
            _IgarageModel.SellCar(_IpurchasedCars.listPurchasedCars[indexCar]);
            _IgarageView.SellCar();
        }

        [Button("Change car")]
        public void ChangeCar(in byte indexCar)
        {
            PlayerSelectedCar.SetCurrentPlayerCar(_IpurchasedCars.listPurchasedCars[indexCar]);
        }
    }
}
