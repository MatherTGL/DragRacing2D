using Config;

namespace Racing.Rivals
{
    public interface IRivalsControl
    {
        void StartRacing();

        void SetRival(in ConfigCarEditor configCar);
    }
}
