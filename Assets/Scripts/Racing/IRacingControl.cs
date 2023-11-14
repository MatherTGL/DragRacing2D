using Garage;
using Racing.Rivals;
using UnityEngine.SceneManagement;

namespace Racing
{
    public interface IRacingControl
    {
        IGarageControl IgarageControl { get; }

        IRivalsControl IrivalsControl { get; }

        Scene workedScene { get; }


        void StartRacing();

        bool IsRacingStarted();
    }
}
