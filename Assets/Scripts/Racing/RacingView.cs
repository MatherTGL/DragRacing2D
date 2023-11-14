using System.Collections;
using Boot;
using Racing.Rivals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Racing.View
{
    [RequireComponent(typeof(RacingControl))]
    public sealed class RacingView : MonoBehaviour, IBoot, IRacingView
    {
        private IRacingControl _IracingControl;

        private WaitForSecondsRealtime _countdownWait;


        void IBoot.InitAwake()
        {
            _countdownWait = new WaitForSecondsRealtime(3); //! hardcode

#if UNITY_EDITOR
            StartRacing();
#endif
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        void IRacingView.Init(in IRacingControl IracingControl)
        {
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
