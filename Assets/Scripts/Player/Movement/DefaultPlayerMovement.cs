using Config;
using UnityEngine;

namespace Player.Movement
{
    public sealed class DefaultPlayerMovement : AbstractPlayerMovement
    {
        private Rigidbody2D _rigidbody2D;


        public DefaultPlayerMovement(in Rigidbody2D rigidbody2D, in ConfigCarEditor configCar)
        {
            _rigidbody2D = rigidbody2D;
            _configCar = configCar;
        }

        public sealed override void Brake()
        {
            Debug.Log("Brake");
            _rigidbody2D.AddForce(Vector2.left * _configCar.brakePower, ForceMode2D.Force);
        }

        public sealed override void Drive()
        {
            Debug.Log("Drive");
            _rigidbody2D.AddForce(Vector2.right * _configCar.basePower, ForceMode2D.Force);
        }
    }
}

