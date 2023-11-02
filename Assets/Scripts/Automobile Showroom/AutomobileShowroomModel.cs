using Garage.PlayerCar.Purchased;

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
            IPurchasedCar purchasedCar = new PurchasedCar(_IshowroomControl.availableCarsForPurchase[indexCarConfig]);
            _IshowroomControl.IgarageControl.purchasedCars.AddNewTransportation(purchasedCar);
        }
    }
}
