using System.Collections.Generic;

namespace Garage.PlayerCar.Purchased
{
    public interface IPurchasedCars
    {
        List<IPurchasedCar> listPurchasedCars { get; }


        void SetBaseCar(in IPurchasedCar car);

        void AddNewTransportation(in IPurchasedCar car);

        void SellTransportation(in IPurchasedCar car);
    }
}
