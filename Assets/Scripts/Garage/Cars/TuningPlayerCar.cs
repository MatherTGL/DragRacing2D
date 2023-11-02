namespace Garage.PlayerCar
{
    public sealed class TuningPlayerCar
    {
        private static readonly TuningPlayerCar _instance = new TuningPlayerCar();
        public static TuningPlayerCar getInstance => _instance;

        private PlayerSelectedCar _playerSelectedCar = PlayerSelectedCar.getInstance;


        private TuningPlayerCar() { }
    }
}
