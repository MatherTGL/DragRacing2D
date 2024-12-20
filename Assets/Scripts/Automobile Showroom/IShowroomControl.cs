using Config;
using Garage;

namespace Showroom
{
    public interface IShowroomControl
    {
        IGarageControl IgarageControl { get; }

        ConfigCarEditor[] availableCarsForPurchase { get; }


        void BuyCar(in byte indexCar);
    }
}
