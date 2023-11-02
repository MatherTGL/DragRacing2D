using Garage.PlayerCar.Purchased;

namespace Garage.PlayerCar
{
    public sealed class PlayerSelectedCar
    {
        private static readonly PlayerSelectedCar _instance = new PlayerSelectedCar();
        public static PlayerSelectedCar getInstance => _instance;

        private static IPurchasedCar _selectedCar;
        public static IPurchasedCar selectedCar => _selectedCar;


        private PlayerSelectedCar() { }

        public static void SetBasePlayerCar(in IPurchasedCar purchasedCar)
        {
            _selectedCar = purchasedCar;
        }

        public static void SetCurrentPlayerCar(in IPurchasedCar purchasedCar)
        {
            _selectedCar = purchasedCar;
        }
    }
}
