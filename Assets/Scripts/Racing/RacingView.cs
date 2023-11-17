using System.Collections;
using Boot;
using Racing.Rivals;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Racing.View
{
    [RequireComponent(typeof(RacingControl))]
    public sealed class RacingView : MonoBehaviour, IRacingView
    {
        [SerializeField, Required]
        private GameObject _finishView;

        [SerializeField, Required]
        private Rigidbody2D _playerRigidbody;

        [SerializeField, Required]
        private Text _playerCarSpeedText;


        void IRacingView.CarFinished(RacingControl.WhoFinished finished)
        {
            Debug.Log(finished);
            _finishView.SetActive(true);
        }

        void IRacingView.Init() => StartCoroutine(UpdateCarSpeed());

        private IEnumerator UpdateCarSpeed()
        {
            while (true)
            {
                _playerCarSpeedText.text = $"SPEED {_playerRigidbody.velocity.x} km/h";
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
