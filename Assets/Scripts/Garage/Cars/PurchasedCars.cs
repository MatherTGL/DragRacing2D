using System.Collections.Generic;
using Garage.PlayerCar.Tuning;

namespace Garage.PlayerCar.Purchased
{
    public sealed class PurchasedCars : IPurchasedCars, IPurchasedCarsTuning
    {
        private List<IPurchasedCar> _listPurchasedCars = new();
        List<IPurchasedCar> IPurchasedCars.listPurchasedCars => _listPurchasedCars;


        void IPurchasedCars.AddNewTransportation(in IPurchasedCar car)
        {
            _listPurchasedCars.Add(car);
        }

        void IPurchasedCars.SellTransportation(in IPurchasedCar car)
        {
            _listPurchasedCars.Remove(car);
        }

        void IPurchasedCars.SetBaseCar(in IPurchasedCar car)
        {
            if (_listPurchasedCars[0] is null)
                _listPurchasedCars.Add(car);
        }
    }
}
