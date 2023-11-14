using Config;
using UnityEngine;

namespace Racing.Rivals
{
    public sealed class MovementOpponent
    {
        private static readonly MovementOpponent _instance = new MovementOpponent();
        public static MovementOpponent getInstance => _instance;

        private Rigidbody2D _rigidbody2D;

        private ConfigCarEditor _configCar;


        private MovementOpponent() { }

        public void Init(in Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
        }

        public void ChangeConfig(in ConfigCarEditor configCar)
        {
            Debug.Log(configCar);
            _configCar = configCar;
            Debug.Log(configCar);
        }

        public void Move()
        {
            if (_rigidbody2D.velocity.x < _configCar.maxSpeed)
                _rigidbody2D.AddForce(Vector2.right * _configCar.basePower, ForceMode2D.Force);
        }
    }
}
