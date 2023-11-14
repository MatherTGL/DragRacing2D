using System;
using Boot;
using Garage;
using Racing.Triggers;
using Racing.View;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Racing.Rivals
{
    [RequireComponent(typeof(RacingView))]
    public sealed class RacingControl : MonoBehaviour, IBoot, IRacingControl
    {
        private const string _NameWorkedScene = "Racing";

        public enum WhoFinished { Player, Rival }

        private IRacingView _IracingView;

        private IRacingModel _IracingModel;

        private IGarageControl _IgarageControl;
        IGarageControl IRacingControl.IgarageControl => _IgarageControl;

        private IRivalsControl _IrivalsControl;
        IRivalsControl IRacingControl.IrivalsControl => _IrivalsControl;

        private Scene _workedScene;
        Scene IRacingControl.workedScene => _workedScene;


        private RacingControl() { }

        void IBoot.InitAwake()
        {
            _workedScene = SceneManager.GetSceneByName(_NameWorkedScene);

            DontDestroyOnLoad(this);

            //FindObjectOfType<FinishTrigger>().finished += CarFinished;

            _IgarageControl = FindObjectOfType<GarageControl>();
            _IrivalsControl = FindObjectOfType<RivalsControl>();

            _IracingView = (IRacingView)GetComponent(typeof(IRacingView));
            _IracingView.Init(this);

            _IracingModel = new RacingModel(this);
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        void IRacingControl.StartRacing() => _IracingModel.StartRacing();

        bool IRacingControl.IsRacingStarted() => _IracingModel.isRacingStarted;

        private void CarFinished(WhoFinished finished)
        {
            _IracingView.CarFinished(finished);
            _IracingModel.CarFinished(finished);
        }
    }
}
