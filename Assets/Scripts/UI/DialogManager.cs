using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using YG;

public class DialogManager : MonoBehaviour
{
    private int activeScene;
    [SerializeField] private GameObject dialogUI;

    private Animator dialogAnimator;
    private Animator dialogKostyaAnimator;
    void Start()
    {
        dialogAnimator = dialogUI.GetComponent<Animator>();

        activeScene = SceneManager.GetActiveScene().buildIndex;

        if (YandexGame.savesData.egorDialog == false && activeScene == 2)
        {
            dialogUI.SetActive(true);
            YandexGame.savesData.egorDialog = true;
            YandexGame.SaveProgress();
        }
    }

    public void CloseDialog()
    {
        dialogAnimator.Play("dialogAnimOff");
    }
}
