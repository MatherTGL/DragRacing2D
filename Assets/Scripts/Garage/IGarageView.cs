using Garage.PlayerCar.Purchased;

namespace Garage
{
    public interface IGarageView
    {
        void SellCar();

        void AddNewTransportation(in IPurchasedCar car);
    }
}
