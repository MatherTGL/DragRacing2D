using Config;
using Garage.PlayerCar;
using UnityEngine;

namespace Racing.Rivals
{
    public sealed class MovementOpponent
    {
        private static readonly MovementOpponent _instance = new MovementOpponent();
        public static MovementOpponent getInstance => _instance;

        private RivalCar _rivalCar;

        private Rigidbody2D _rigidbody2D;


        private MovementOpponent() { }

        public void Init(in Rigidbody2D rigidbody2D, in RivalCar rivalCar)
        {
            _rigidbody2D = rigidbody2D;
            _rivalCar = rivalCar;
        }

        public void GenerateRandomRivalParameters()
        {
            var randomPowerMin = PlayerSelectedCar.selectedCar.currentPower - (PlayerSelectedCar.selectedCar.currentPower * 30 / 100);
            var randomPowerMax = PlayerSelectedCar.selectedCar.currentPower + (PlayerSelectedCar.selectedCar.currentPower * 4 / 100);

            var randomSpeedMin = PlayerSelectedCar.selectedCar.maxSpeed - (PlayerSelectedCar.selectedCar.maxSpeed * 15 / 100);
            var randomSpeedMax = PlayerSelectedCar.selectedCar.maxSpeed + (PlayerSelectedCar.selectedCar.maxSpeed * 10 / 100);

            _rivalCar.power = Random.Range(randomPowerMin, randomPowerMax);
            _rivalCar.maxSpeed = Random.Range(randomSpeedMin, randomSpeedMax);
            Debug.Log($"{_rivalCar.power} / {_rivalCar.maxSpeed}");
        }

        public void Move()
        {
            if (_rigidbody2D.velocity.x < _rivalCar.maxSpeed)
                _rigidbody2D.AddForce(Vector2.right * _rivalCar.power, ForceMode2D.Force);
        }
    }
}
