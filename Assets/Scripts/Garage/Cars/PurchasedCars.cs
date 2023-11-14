using System.Collections.Generic;
using Garage.PlayerCar.Tuning;
using UnityEngine;

namespace Garage.PlayerCar.Purchased
{
    public sealed class PurchasedCars : IPurchasedCars, IPurchasedCarsTuning
    {
        private List<IPurchasedCar> _listPurchasedCars = new();
        List<IPurchasedCar> IPurchasedCars.listPurchasedCars => _listPurchasedCars;


        void IPurchasedCars.AddNewTransportation(in IPurchasedCar car)
        {
            Debug.Log(_listPurchasedCars.Count);
            _listPurchasedCars.Add(car);
            Debug.Log(_listPurchasedCars.Count);
        }

        IPurchasedCar IPurchasedCarsTuning.GetCar(in byte indexCar)
        {
            if (_listPurchasedCars.Count - 1 >= indexCar && indexCar >= 0)
                return _listPurchasedCars[indexCar];
            return null;
        }

        void IPurchasedCars.SellTransportation(in IPurchasedCar car)
        {
            _listPurchasedCars.Remove(car);
        }

        void IPurchasedCars.SetBaseCar(in IPurchasedCar car)
        {
            _listPurchasedCars.Add(car);
        }
    }
}
