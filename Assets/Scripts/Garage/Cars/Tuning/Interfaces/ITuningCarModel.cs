using Garage.PlayerCar.Purchased;

namespace Garage.PlayerCar.Tuning
{
    public interface ITuningCarModel
    {
        void TuningCarPower(in IPurchasedCar car);
    }
}
