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
            _selectedCar = PlayerSelectedCar.selectedCar;
        }

        public sealed override void Brake()
        {
            Debug.Log("Brake");
            if (_rigidbody2D.velocity.x > 0)
                _rigidbody2D.AddForce(Vector2.left * _selectedCar.currentBrakePower, ForceMode2D.Force);
        }

        public sealed override void Drive()
        {
            Debug.Log("Drive");
            if (_rigidbody2D.velocity.x < _selectedCar.maxSpeed)
                _rigidbody2D.AddForce(Vector2.right * _selectedCar.currentPower, ForceMode2D.Force);
        }
    }
}

