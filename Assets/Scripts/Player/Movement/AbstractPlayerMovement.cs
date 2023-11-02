using Garage.PlayerCar.Purchased;

namespace Player.Movement
{
    public abstract class AbstractPlayerMovement
    {
        protected IPurchasedCar _selectedCar;


        public abstract void Drive();

        public abstract void Brake();
    }
}

