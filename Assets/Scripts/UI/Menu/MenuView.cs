using Sirenix.OdinInspector;
using UnityEngine;

public sealed class MenuView : MonoBehaviour
{
    [SerializeField, Required]
    private AudioListener _audioListener;


    public void Quit() => Application.Quit();

    public void ChangeStateAudio() => _audioListener.enabled = !_audioListener.enabled;
}
