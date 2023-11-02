using Config;

namespace Garage.PlayerCar.Purchased
{
    public sealed class PurchasedCar : IPurchasedCar
    {
        private ConfigCarEditor _configCar;

        private ushort _maxSpeed;

        private ushort _mass;

        private ushort _currentPower;

        private ushort _currentBrakePower;


        public PurchasedCar(in ConfigCarEditor configCar)
        {
            _configCar = configCar;

            _maxSpeed = _configCar.maxSpeed;
            _mass = _configCar.mass;
            _currentPower = _configCar.basePower;
            _currentBrakePower = _configCar.brakePower;
        }
    }
}

