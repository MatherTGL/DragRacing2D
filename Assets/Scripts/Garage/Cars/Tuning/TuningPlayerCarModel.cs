namespace Garage.PlayerCar.Tuning
{
    public sealed class TuningPlayerCarModel : ITuningCarModel
    {
        private ITuningCarControl _ItuningCarControl;


        public TuningPlayerCarModel(in ITuningCarControl tuningCarControl)
        {
            _ItuningCarControl = tuningCarControl;
        }

        void ITuningCarModel.TuningCarPower(in byte carIndex)
        {
            _ItuningCarControl.IpurchasedCarsTuning.GetCar(carIndex).UpgradePower(100); //TODO
            //!car.UpgradePower();
        }
    }
}
