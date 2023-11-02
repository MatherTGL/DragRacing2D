using System.Collections.Generic;

namespace Garage.PlayerCar.Purchased
{
    public sealed class PurchasedCars : IPurchasedCars
    {
        private List<IPurchasedCar> listPurchasedCars = new();


        void IPurchasedCars.AddNewTransportation(in IPurchasedCar car)
        {
            listPurchasedCars.Add(car);
        }

        void IPurchasedCars.SellTransportation(in IPurchasedCar car)
        {
            listPurchasedCars.Remove(car);
        }
    }
}
