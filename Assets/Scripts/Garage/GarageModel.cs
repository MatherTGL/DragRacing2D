using Garage.PlayerCar.Purchased;
using Player.Data;
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
            GamePlayerData.AddMoney(car.config.buyCost * 20 / 100);
            Debug.Log(_IgarageControl.purchasedCars.listPurchasedCars.Count);
        }
    }
}
