using Boot;
using Garage;
using Racing.View;
using UnityEngine;

namespace Racing.Rivals
{
    [RequireComponent(typeof(RacingView))]
    public sealed class RacingControl : MonoBehaviour, IBoot, IRacingControl
    {
        private IRacingView _IracingView;

        private IRacingModel _IracingModel;

        private IGarageControl _IgarageControl;
        IGarageControl IRacingControl.IgarageControl => _IgarageControl;

        private IRivalsControl _IrivalsControl;
        IRivalsControl IRacingControl.IrivalsControl => _IrivalsControl;


        void IBoot.InitAwake()
        {
            _IgarageControl = (IGarageControl)FindObjectOfType(typeof(IGarageControl));

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
