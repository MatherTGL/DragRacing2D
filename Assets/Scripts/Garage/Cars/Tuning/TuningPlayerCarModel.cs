namespace Garage.PlayerCar.Tuning
{
    public sealed class TuningPlayerCarModel : ITuningCarModel
    {
        private ITuningCarControl _ItuningCarControl;


        public TuningPlayerCarModel(in ITuningCarControl tuningCarControl)
        {
            _ItuningCarControl = tuningCarControl;
        }

        void ITuningCarModel.TuningCarBrakePower()
        {
            PlayerSelectedCar.selectedCar.UpgradeBrakePower(100);
        }

        void ITuningCarModel.TuningCarPower()
        {
            PlayerSelectedCar.selectedCar.UpgradePower(100); //TODO
            //!car.UpgradePower();
        }

        void ITuningCarModel.TuningCarStage()
        {
            PlayerSelectedCar.selectedCar.UpgradeStage();
        }
    }
}
