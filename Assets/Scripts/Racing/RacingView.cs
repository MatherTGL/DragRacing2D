using System.Collections;
using Boot;
using Player.Data;
using Racing.Rivals;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

namespace Racing.View
{
    [RequireComponent(typeof(RacingControl))]
    public sealed class RacingView : MonoBehaviour, IRacingView
    {
        private IRacingControl _IracingControl;

        [SerializeField, Required]
        private GameObject _finishView;

        [SerializeField, Required]
        private Rigidbody2D _playerRigidbody;

        [SerializeField, Required]
        private Text _playerCarSpeedText;

        [SerializeField, Required]
        private Text _playerWinOrLoseText;

        [SerializeField, Required]
        private Text _winOrLoseMoneyText;

        [SerializeField, Required]
        private Text _promotionalOfferText;

        [SerializeField, Required]
        private Image _promotionalOfferImage;

        [SerializeField, Required]
        private AudioSource _audioSourceClickButton;


        void IRacingView.CarFinished(RacingControl.WhoFinished finished)
        {
            _finishView.SetActive(true);

            if (finished is RacingControl.WhoFinished.Player)
            {
                _playerWinOrLoseText.text = "You Win!";
                _winOrLoseMoneyText.text = $"+ ${_IracingControl.winMoney}";

                if (Advertisement.isInitialized)
                {
                    _promotionalOfferText.enabled = true;
                    _promotionalOfferText.text = "+20% MONEY?";
                    _promotionalOfferImage.enabled = true;
                }
            }
            else
            {
                _playerWinOrLoseText.text = "You Lose!";
                _winOrLoseMoneyText.text = $"- ${_IracingControl.loseMoney}";
                _promotionalOfferImage.enabled = false;
                _promotionalOfferText.enabled = false;
            }
        }

        void IRacingView.Init(in IRacingControl racingControl)
        {
            _IracingControl = racingControl;
            StartCoroutine(UpdateCarSpeed());
        }

        private IEnumerator UpdateCarSpeed()
        {
            while (true)
            {
                _playerCarSpeedText.text = $"SPEED {_playerRigidbody.velocity.x} km/h";
                yield return new WaitForSeconds(0.5f);
            }
        }

        public void StartAudioClickButton()
        {
            _audioSourceClickButton.Play();
        }
    }
}
