using Config;
using UnityEngine;

namespace Rivals
{
    public sealed class MovementOpponent
    {
        private static readonly MovementOpponent _instance = new MovementOpponent();
        public static MovementOpponent getInstance => _instance;

        private Rigidbody2D _rigidbody2D;

        private ConfigCarEditor _configCar;


        private MovementOpponent() { }

        public void Init(in Rigidbody2D rigidbody2D, in ConfigCarEditor configCar)
        {
            _rigidbody2D = rigidbody2D;
            _configCar = configCar;
        }

        public void Move()
        {
            _rigidbody2D.AddForce(Vector2.right * _configCar.basePower, ForceMode2D.Force);
        }
    }
}
