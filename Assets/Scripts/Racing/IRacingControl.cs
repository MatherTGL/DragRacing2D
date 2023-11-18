using Garage;
using Racing.Rivals;

namespace Racing
{
    public interface IRacingControl
    {
        IGarageControl IgarageControl { get; }

        IRivalsControl IrivalsControl { get; }


        double winMoney { get; }

        double loseMoney { get; }

        bool IsRacingStarted();
    }
}
