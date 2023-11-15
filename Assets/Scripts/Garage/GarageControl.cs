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

        void IGarageControl.SellCar(byte indexCar)
        {
            if (indexCar != 0)
            {
                Debug.Log(PlayerSelectedCar.selectedCar.config);
                _IgarageModel.SellCar(_IpurchasedCars.listPurchasedCars[indexCar]);
                _IgarageView.SellCar();
                ChangeCar(0);
                Debug.Log(PlayerSelectedCar.selectedCar.config);
            }
        }

        public void ChangeCar(in byte indexCar)
        {
            Debug.Log(PlayerSelectedCar.selectedCar.config);
            PlayerSelectedCar.SetCurrentPlayerCar(_IpurchasedCars.listPurchasedCars[indexCar]);
            Debug.Log(PlayerSelectedCar.selectedCar.config);
        }
    }
}
