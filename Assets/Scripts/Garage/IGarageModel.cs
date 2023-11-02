using Garage.PlayerCar.Purchased;

namespace Garage
{
    public interface IGarageModel
    {
        void SellCar();

        void AddNewTransportation(in IPurchasedCar car);
    }
}
