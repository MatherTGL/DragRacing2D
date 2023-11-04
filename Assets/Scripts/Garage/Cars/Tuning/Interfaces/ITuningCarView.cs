using Garage.PlayerCar.Purchased;

namespace Garage.PlayerCar.Tuning
{
    public interface ITuningCarView
    {
        void TuningCarPower(in IPurchasedCar car);
    }
}
