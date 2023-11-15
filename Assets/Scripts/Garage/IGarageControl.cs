using Garage.PlayerCar.Purchased;

namespace Garage
{
    public interface IGarageControl
    {
        IPurchasedCars purchasedCars { get; }


        IPurchasedCar GetCurrentCar();

        void ChangeCar(in byte indexCar);
    }
}
