namespace Garage.PlayerCar
{
    public sealed class PlayerSelectedCar
    {
        private static readonly PlayerSelectedCar _instance = new PlayerSelectedCar();
        public static PlayerSelectedCar getInstance => _instance;


        private PlayerSelectedCar() { }
    }
}
