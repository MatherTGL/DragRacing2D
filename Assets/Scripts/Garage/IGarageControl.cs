using Config;
using Garage.PlayerCar.Purchased;

namespace Garage
{
    public interface IGarageControl
    {
        ConfigCarEditor GetCurrentCar(); //TODO: after return some car class

        IPurchasedCars purchasedCars { get; }
    }
}
