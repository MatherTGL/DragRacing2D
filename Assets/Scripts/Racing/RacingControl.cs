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
using UnityEngine.UI;

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

        [SerializeField, Required]
        private Text _countdownStartRacingText;

        [SerializeField]
        private int _winMoney = 10_000;
        int IRacingControl.winMoney => _winMoney;

        [SerializeField]
        private int _loseMoney = 3_000;
        int IRacingControl.loseMoney => _loseMoney;

        private byte _currentNumber = 3;


        private RacingControl() { }

        void IBoot.InitAwake()
        {
            _countdownWait = new WaitForSecondsRealtime(1);
            FindObjectOfType<FinishTrigger>().finished += CarFinished;

            _IgarageControl = FindObjectOfType<GarageControl>();
            _IrivalsControl = FindObjectOfType<RivalsControl>();

            _IracingView = (IRacingView)GetComponent(typeof(IRacingView));
            _IracingView.Init(this);
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

        private IEnumerator Countdown()
        {
            while (true)
            {
                _countdownStartRacingText.text = $"{_currentNumber}";
                yield return _countdownWait;
                _currentNumber--;

                if (_currentNumber <= 0)
                {
                    _countdownStartRacingText.text = $"START!";
                    _IracingModel.StartRacing();
                    yield return new WaitForSeconds(0.4f);
                    _countdownStartRacingText.text = "";
                    break;
                }
            }
        }
    }
}
