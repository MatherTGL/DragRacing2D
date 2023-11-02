using Garage.PlayerCar.Purchased;

namespace Garage.Purchased
{
    public interface ITransportReplenishment
    {
        void AddNewTransportation(in IPurchasedCar purchasedCar);
    }
}

