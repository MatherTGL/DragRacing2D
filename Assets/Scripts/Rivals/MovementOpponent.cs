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
            Debug.Log(_rigidbody2D);
            Debug.Log(_rivalCar);
        }

        public void GenerateRandomRivalParameters()
        {
            var randomPowerMin = PlayerSelectedCar.selectedCar.currentPower - (PlayerSelectedCar.selectedCar.currentPower * 10 / 100);
            var randomPowerMax = PlayerSelectedCar.selectedCar.currentPower + (PlayerSelectedCar.selectedCar.currentPower * 15 / 100);

            Debug.Log(randomPowerMax);
            Debug.Log(randomPowerMin);

            var randomSpeedMin = PlayerSelectedCar.selectedCar.maxSpeed - (PlayerSelectedCar.selectedCar.maxSpeed * 10 / 100);
            var randomSpeedMax = PlayerSelectedCar.selectedCar.maxSpeed + (PlayerSelectedCar.selectedCar.maxSpeed * 20 / 100);

            Debug.Log(_rivalCar.maxSpeed);
            _rivalCar.power = Random.Range(randomPowerMin, randomPowerMax);
            _rivalCar.maxSpeed = Random.Range(randomSpeedMin, randomSpeedMax);
            Debug.Log(_rivalCar.maxSpeed);
            Debug.Log($"{_rivalCar.power} / {_rivalCar.maxSpeed}");
            Debug.Log($"Fuck you: {_rivalCar.name}");
        }

        public void Move()
        {
            if (_rigidbody2D?.velocity.x < _rivalCar.maxSpeed)
                _rigidbody2D.AddForce(Vector2.right * _rivalCar.power, ForceMode2D.Force);
        }

        public void Brake()
        {
            if (_rigidbody2D?.velocity.x > 0)
                _rigidbody2D.AddForce(Vector2.left * 100, ForceMode2D.Force);
        }
    }
}
