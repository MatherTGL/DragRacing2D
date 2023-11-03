using UnityEngine;

namespace Garage
{
    public sealed class GarageView : IGarageView
    {
        private IGarageControl _IgarageControl;


        public GarageView(in IGarageControl garageControl)
        {
            _IgarageControl = garageControl;
        }

        void IGarageView.SellCar()
        {
            Debug.Log("car selled");
        }
    }
}
