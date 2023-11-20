using Garage;
using Racing.Rivals;

namespace Racing
{
    public interface IRacingControl
    {
        IGarageControl IgarageControl { get; }

        IRivalsControl IrivalsControl { get; }


        int winMoney { get; }

        int loseMoney { get; }

        bool IsRacingStarted();
    }
}
