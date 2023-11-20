using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public sealed class MenuView : MonoBehaviour
{
    [SerializeField, Required]
    private AudioListener _audioListener;

    [SerializeField, Required]
    private Sprite _deactiveAudio;

    [SerializeField, Required]
    private Sprite _activeAudio;

    [SerializeField, Required]
    private Image _audioIcon;


    public void Quit() => Application.Quit();

    public void ChangeStateAudio()
    {
        _audioListener.enabled = !_audioListener.enabled;

        if (_audioListener.enabled)
        {
            _audioIcon.sprite = _activeAudio;
        }
        else
        {
            _audioIcon.sprite = _deactiveAudio;
        }
    }
}
