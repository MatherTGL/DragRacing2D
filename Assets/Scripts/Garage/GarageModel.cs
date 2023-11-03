using Garage.PlayerCar.Purchased;
using UnityEngine;

namespace Garage
{
    public sealed class GarageModel : IGarageModel
    {
        private IGarageControl _IgarageControl;


        public GarageModel(in IGarageControl garageControl)
        {
            _IgarageControl = garageControl;
        }

        void IGarageModel.SellCar(in IPurchasedCar car)
        {
            Debug.Log(_IgarageControl.purchasedCars.listPurchasedCars.Count);
            _IgarageControl.purchasedCars.SellTransportation(car);
            Debug.Log(_IgarageControl.purchasedCars.listPurchasedCars.Count);
        }
    }
}
