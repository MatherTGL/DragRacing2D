using Garage.PlayerCar.Purchased;
using Player.Data;

namespace Showroom
{
    public sealed class AutomobileShowroomModel : IShowroomModel
    {
        private IShowroomControl _IshowroomControl;


        public AutomobileShowroomModel(in IShowroomControl showroomControl)
        {
            _IshowroomControl = showroomControl;
        }

        void IShowroomModel.BuyCar(in byte indexCarConfig)
        {
            IPurchasedCar purchasedCar = new PurchasedCar();
            purchasedCar.Init(_IshowroomControl.availableCarsForPurchase[indexCarConfig]);

            if (GamePlayerData.SpendMoney(purchasedCar.config.buyCost))
                _IshowroomControl.IgarageControl.purchasedCars.AddNewTransportation(purchasedCar);
        }
    }
}
