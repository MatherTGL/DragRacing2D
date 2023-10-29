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
        }

        public sealed override void Drive()
        {
            Debug.Log("Drive");
        }

        public override void NaturalBraking()
        {
            Debug.Log("Natural Braking");
        }
    }
}

