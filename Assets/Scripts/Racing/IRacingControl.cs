using Garage;
using Racing.Rivals;

namespace Racing
{
    public interface IRacingControl
    {
        IGarageControl IgarageControl { get; }

        IRivalsControl IrivalsControl { get; }


        void StartRacing();

        bool IsRacingStarted();
    }
}
