using Racing.Rivals;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Racing.View
{
    [RequireComponent(typeof(RacingControl))]
    public sealed class RacingView : MonoBehaviour, IRacingView
    {
        void IRacingView.CarFinished(RacingControl.WhoFinished finished)
        {
            Debug.Log(finished);
            SceneManager.LoadScene(2);
        }
    }
}
