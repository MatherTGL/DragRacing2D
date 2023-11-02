using Config;
using Garage.PlayerCar;
using Garage.PlayerCar.Purchased;

namespace Garage
{
    public interface IGarageControl
    {
        ConfigCarEditor GetCurrentCar(); //TODO: after return some car class

        TuningPlayerCar GetTuning();

        IPurchasedCars purchasedCars { get; }
    }
}
