using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

        if (!PlayerPrefs.HasKey("Egor") && activeScene == 2)
        {
            int egor = 1;
            dialogUI.SetActive(true);
            PlayerPrefs.SetInt("Egor", egor);
        }
    }

    public void CloseDialog()
    {
        dialogAnimator.Play("dialogAnimOff");
    }




}
