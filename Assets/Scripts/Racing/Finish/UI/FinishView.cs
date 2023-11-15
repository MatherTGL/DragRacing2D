using UnityEngine;
using UnityEngine.SceneManagement;

namespace Racing.View
{
    public sealed class FinishView : MonoBehaviour
    {
        public void MoveToGarage() => SceneManager.LoadScene(2);
    }
}
