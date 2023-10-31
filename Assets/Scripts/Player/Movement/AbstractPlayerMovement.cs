using Config;

namespace Player.Movement
{
    public abstract class AbstractPlayerMovement
    {
        protected ConfigCarEditor _configCar;


        public abstract void Drive();

        public abstract void Brake();
    }
}

