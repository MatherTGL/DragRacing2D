using static Racing.Rivals.RacingControl;

namespace Racing
{
    public interface IRacingModel
    {
        bool isRacingStarted { get; }


        void StartRacing();
        void CarFinished(WhoFinished finished);
    }
}
