using static Racing.Rivals.RacingControl;

namespace Racing.View
{
    public interface IRacingView
    {
        void Init();
        void CarFinished(WhoFinished finished);
    }
}
