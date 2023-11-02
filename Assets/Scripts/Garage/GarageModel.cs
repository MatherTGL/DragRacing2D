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

        void IGarageModel.AddNewTransportation(in IPurchasedCar car)
        {
            _IgarageControl.purchasedCars.AddNewTransportation(car);
        }

        void IGarageModel.SellCar()
        {
            Debug.Log("car selled");
        }
    }
}
