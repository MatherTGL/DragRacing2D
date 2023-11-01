using static Racing.Rivals.RacingControl;

namespace Racing.View
{
    public interface IRacingView
    {
        void Init(in IRacingControl IracingControl);

        void CarFinished(WhoFinished finished);
    }
}
