using static Racing.Rivals.RacingControl;

namespace Racing.View
{
    public interface IRacingView
    {
        void Init(in IRacingControl racingControl);
        void CarFinished(WhoFinished finished);
    }
}
