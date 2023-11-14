using System.Collections;
using Boot;
using Racing.Rivals;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Racing.View
{
    [RequireComponent(typeof(RacingControl))]
    public sealed class RacingView : MonoBehaviour, IRacingView
    {
        private IRacingControl _IracingControl;

        private WaitForSecondsRealtime _countdownWait;


        void IRacingView.Init(in IRacingControl IracingControl)
        {
            _countdownWait = new WaitForSecondsRealtime(3); //! hardcode
            _IracingControl = IracingControl;
        }

        void IRacingView.CarFinished(RacingControl.WhoFinished finished)
        {
            Debug.Log(finished);
        }

        [Button("Start Racing")]
        public void StartRacing()
        {
            StartCoroutine(Countdown());
        }

        private IEnumerator Countdown() //TODO: finish it
        {
            while (true)
            {
                yield return _countdownWait;
                _IracingControl?.StartRacing();
                break;
            }
        }
    }
}
