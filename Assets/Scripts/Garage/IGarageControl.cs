using Garage.PlayerCar.Purchased;

namespace Garage
{
    public interface IGarageControl
    {
        IPurchasedCars purchasedCars { get; }


        IPurchasedCar GetCurrentCar();

        //! MOVE IN THE OTHER INTERFACE 
        void ChangeCar(in byte indexCar);

        void SellCar(byte indexCar);
    }
}
