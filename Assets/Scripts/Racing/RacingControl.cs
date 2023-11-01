using Boot;
using Racing.View;
using UnityEngine;

namespace Racing
{
    [RequireComponent(typeof(RacingView))]
    public sealed class RacingControl : MonoBehaviour, IBoot, IRacingControl
    {
        private IRacingView _IracingView;

        private IRacingModel _IracingModel;


        void IBoot.InitAwake()
        {
            _IracingView = (IRacingView)GetComponent(typeof(IRacingView));

            _IracingView.Init(this);
            _IracingModel = new RacingModel(this);
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        void IRacingControl.StartRacing()
        {
            Debug.Log("Racing Started");
            _IracingModel.StartRacing();
        }
    }
}
