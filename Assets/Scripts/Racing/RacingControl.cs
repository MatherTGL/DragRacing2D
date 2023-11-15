using System;
using System.Collections;
using Boot;
using Garage;
using Garage.PlayerCar;
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
        public enum WhoFinished { Player, Rival }

        private IRacingView _IracingView;

        private IRacingModel _IracingModel;

        private IGarageControl _IgarageControl;
        IGarageControl IRacingControl.IgarageControl => _IgarageControl;

        private IRivalsControl _IrivalsControl;
        IRivalsControl IRacingControl.IrivalsControl => _IrivalsControl;

        private WaitForSecondsRealtime _countdownWait;


        private RacingControl() { }

        void IBoot.InitAwake()
        {
            Debug.Log(PlayerSelectedCar.selectedCar.config);
            _countdownWait = new WaitForSecondsRealtime(3); //! hardcode
            FindObjectOfType<FinishTrigger>().finished += CarFinished;

            _IgarageControl = FindObjectOfType<GarageControl>();
            _IrivalsControl = FindObjectOfType<RivalsControl>();

            _IracingView = (IRacingView)GetComponent(typeof(IRacingView));
            _IracingModel = new RacingModel(this);

            StartCoroutine(Countdown());
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        bool IRacingControl.IsRacingStarted() => _IracingModel.isRacingStarted;

        private void CarFinished(WhoFinished finished)
        {
            _IracingModel.CarFinished(finished);
            _IracingView.CarFinished(finished);

            //TODO ref
            //? FindObjectOfType<FinishTrigger>().finished -= CarFinished;
        }

        private IEnumerator Countdown() //TODO: finish it
        {
            while (true)
            {
                yield return _countdownWait;
                _IracingModel.StartRacing();
                break;
            }
        }
    }
}
