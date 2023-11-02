using Garage.PlayerCar.Purchased;

namespace Garage
{
    public interface IGarageControl
    {
        IPurchasedCar GetCurrentCar();

        IPurchasedCars purchasedCars { get; }
    }
}
