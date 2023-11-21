using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    private int activeScene;
    [SerializeField] private GameObject dialogUI;
    [SerializeField] private GameObject dialogKostya;
    private Animator dialogAnimator;
    private Animator dialogKostyaAnimator;
    void Start()
    {
        dialogAnimator = dialogUI.GetComponent<Animator>();
        dialogKostyaAnimator = dialogKostya.GetComponent<Animator>();
        activeScene = SceneManager.GetActiveScene().buildIndex;

        if (!PlayerPrefs.HasKey("Money") && activeScene == 2)
        {
            dialogUI.SetActive(true);
        }
    }

    public void CloseDialog()
    {
        dialogAnimator.Play("dialogAnimOff");
    }

    public void CloseKostyaDialog()
    {
        dialogKostyaAnimator.Play("dialogAnimOff");
    }


}
