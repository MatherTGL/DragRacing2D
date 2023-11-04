namespace Garage.PlayerCar.Tuning
{
    public interface ITuningCarModel
    {
        void TuningCarPower(in byte carIndex);

        void TuningCarBrakePower(in byte carIndex);
    }
}
