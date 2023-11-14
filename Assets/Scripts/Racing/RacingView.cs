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
            DontDestroyOnLoad(this);
            _countdownWait = new WaitForSecondsRealtime(3); //! hardcode

#if UNITY_EDITOR
            if (IsCorrectedScene())
                StartRacing();
#endif

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

        private bool IsCorrectedScene()
        {
            if (SceneManager.loadedSceneCount != _IracingControl.workedScene.buildIndex)
                return false;
            else
                return true;
        }
    }
}
