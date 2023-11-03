using Garage.PlayerCar.Purchased;

namespace Garage.PlayerCar.Tuning
{
    public interface IPurchasedCarsTuning
    {
        IPurchasedCar GetCar(in byte indexCar);
    }
}
