namespace Garage.PlayerCar.Tuning
{
    public interface ITuningCarView
    {
        void TuningCarPower(in byte carIndex);

        void TuningCarBrakePower(in byte carIndex);
    }
}
