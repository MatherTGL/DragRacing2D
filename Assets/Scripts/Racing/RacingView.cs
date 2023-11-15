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
        [SerializeField, Required]
        private GameObject _finishView;


        void IRacingView.CarFinished(RacingControl.WhoFinished finished)
        {
            Debug.Log(finished);
            _finishView.SetActive(true);
            //SceneManager.LoadScene(2);
        }
    }
}
