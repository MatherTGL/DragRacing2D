using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogManager : MonoBehaviour
{
    private int activeScene;
    [SerializeField] private GameObject dialogUI;
    private Animator dialogAnimator;
    void Start()
    {
        dialogAnimator = dialogUI.GetComponent<Animator>();
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
 
}
