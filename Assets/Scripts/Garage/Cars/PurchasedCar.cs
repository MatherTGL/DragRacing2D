using Config;

namespace Garage.PlayerCar.Purchased
{
    public sealed class PurchasedCar : IPurchasedCar
    {
        private ConfigCarEditor _configCar;
        ConfigCarEditor IPurchasedCar.config => _configCar;

        private ushort _maxSpeed;
        ushort IPurchasedCar.maxSpeed => _maxSpeed;

        private ushort _mass;
        ushort IPurchasedCar.mass => _mass;

        private ushort _currentPower;
        ushort IPurchasedCar.currentPower => _currentPower;

        private ushort _currentBrakePower;
        ushort IPurchasedCar.currentBrakePower => _currentBrakePower;


        public PurchasedCar(in ConfigCarEditor configCar)
        {
            _configCar = configCar;

            _maxSpeed = _configCar.maxSpeed;
            _mass = _configCar.mass;
            _currentPower = _configCar.basePower;
            _currentBrakePower = _configCar.brakePower;
        }

        void IPurchasedCar.UpgradePower(in ushort power)
        {
            _currentPower += power;
        }

        void IPurchasedCar.UpgradeBrakePower(in ushort brakePower)
        {
            _currentBrakePower += brakePower;
        }
    }
}
