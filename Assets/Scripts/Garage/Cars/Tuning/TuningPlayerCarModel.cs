namespace Garage.PlayerCar.Tuning
{
    public sealed class TuningPlayerCarModel : ITuningCarModel
    {
        private ITuningCarControl _ItuningCarControl;


        public TuningPlayerCarModel(in ITuningCarControl tuningCarControl)
        {
            _ItuningCarControl = tuningCarControl;
        }

        void ITuningCarModel.TuningCarBrakePower(in byte carIndex)
        {
            _ItuningCarControl.IpurchasedCarsTuning.GetCar(carIndex).UpgradeBrakePower(100);
        }

        void ITuningCarModel.TuningCarPower(in byte carIndex)
        {
            _ItuningCarControl.IpurchasedCarsTuning.GetCar(carIndex).UpgradePower(100); //TODO
            //!car.UpgradePower();
        }
    }
}
