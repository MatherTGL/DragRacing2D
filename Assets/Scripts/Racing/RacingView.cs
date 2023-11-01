using Sirenix.OdinInspector;
using UnityEngine;

namespace Racing.View
{
    [RequireComponent(typeof(RacingControl))]
    public sealed class RacingView : MonoBehaviour, IRacingView
    {
        private IRacingControl _IracingControl;


        void IRacingView.Init(in IRacingControl IracingControl)
        {
            _IracingControl = IracingControl;
        }

        [Button("Start Racing")]
        public void StartRacing()
        {
            _IracingControl.StartRacing();
        }
    }
}
