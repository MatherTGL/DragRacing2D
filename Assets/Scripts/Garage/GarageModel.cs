using Garage.PlayerCar.Purchased;

namespace Garage
{
    public sealed class GarageModel : IGarageModel
    {
        private IGarageControl _IgarageControl;


        public GarageModel(in IGarageControl garageControl)
        {
            _IgarageControl = garageControl;
        }

        void IGarageModel.SellCar(in IPurchasedCar car)
        {
            _IgarageControl.purchasedCars.SellTransportation(car);
        }
    }
}
