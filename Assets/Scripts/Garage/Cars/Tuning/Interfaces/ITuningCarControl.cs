namespace Garage.PlayerCar.Tuning
{
    public interface ITuningCarControl
    {
        IPurchasedCarsTuning IpurchasedCarsTuning { get; }


        void Init(in IPurchasedCarsTuning purchasedCars);

        void TuningCarPower();

        void TuningCarBrakePower();

        void TuningCarStage();
    }
}
