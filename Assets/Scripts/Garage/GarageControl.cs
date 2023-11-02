using Boot;
using Config;
using Garage.PlayerCar;
using Garage.PlayerCar.Purchased;
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

        [SerializeField, Required]
        private ConfigCarEditor _configCar;

        private TuningPlayerCar _tuningSelectedCar;


        void IBoot.InitAwake()
        {
            DontDestroyOnLoad(this);
            _IgarageModel = new GarageModel(this);
            _IgarageView = new GarageView(this);
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        ConfigCarEditor IGarageControl.GetCurrentCar() => _configCar;

        TuningPlayerCar IGarageControl.GetTuning() => _tuningSelectedCar;

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
    }
}
