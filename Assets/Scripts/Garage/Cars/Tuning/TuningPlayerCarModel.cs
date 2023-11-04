using Garage.PlayerCar.Purchased;

namespace Garage.PlayerCar.Tuning
{
    public sealed class TuningPlayerCarModel : ITuningCarModel
    {
        private ITuningCarControl _ItuningCarControl;


        public TuningPlayerCarModel(in ITuningCarControl tuningCarControl)
        {
            _ItuningCarControl = tuningCarControl;
        }

        void ITuningCarModel.TuningCarPower(in IPurchasedCar car)
        {
            car.UpgradePower();
        }
    }
}
