using Garage.PlayerCar;
using UnityEngine;

namespace Player.Movement
{
    public sealed class DefaultPlayerMovement : AbstractPlayerMovement
    {
        private Rigidbody2D _rigidbody2D;


        public DefaultPlayerMovement(in Rigidbody2D rigidbody2D)
        {
            _rigidbody2D = rigidbody2D;
        }

        public sealed override void Brake()
        {
            Debug.Log("Brake");
            if (_rigidbody2D.velocity.x > 0)
                _rigidbody2D.AddForce(Vector2.left * PlayerSelectedCar.selectedCar.currentBrakePower, ForceMode2D.Force);
        }

        public sealed override void Drive()
        {
            Debug.Log("Drive");
            if (_rigidbody2D.velocity.x < PlayerSelectedCar.selectedCar.maxSpeed)
                _rigidbody2D.AddForce(Vector2.right * PlayerSelectedCar.selectedCar.currentPower, ForceMode2D.Force);
        }

        public override void FastBrake()
        {
            if (_rigidbody2D.velocity.x > 0)
                _rigidbody2D.AddForce(Vector2.left * 100, ForceMode2D.Force);
        }
    }
}

