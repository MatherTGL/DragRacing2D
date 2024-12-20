using Boot;
using Player.Data;
using Sirenix.OdinInspector;

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public sealed class MenuView : MonoBehaviour, IBoot
{
    [SerializeField, Required]
    private AudioListener _audioListener;

    [SerializeField, Required]
    private AudioSource _audioClipClickButton;

    [SerializeField, Required]
    private Sprite _deactiveAudio;

    [SerializeField, Required]
    private Sprite _activeAudio;

    [SerializeField, Required]
    private Image _audioIcon;

    [SerializeField, Required]
    private GameObject _resumeButton;


    void IBoot.InitAwake()
    {
        if (YandexGame.savesData.isFirstSession == false)
            _resumeButton.SetActive(true);
        else
            _resumeButton.SetActive(false);
    }

    (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
    {
        return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
    }

    public void Quit()
    {
        StartAudioClickButton();
        Application.Quit();
    }

    public void ChangeStateAudio()
    {
        StartAudioClickButton();
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

    public void StartNewGame()
    {
        YandexGame.ResetSaveProgress();
        StartAudioClickButton();
        SceneManager.LoadScene(2);
    }

    private void StartAudioClickButton()
    {
        _audioClipClickButton.Play();
    }
}
