using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManagerForShowRoom : MonoBehaviour
{

    [SerializeField] private GameObject dialogUI;
    private Animator dialogAnimator;
    void Start()
    {
        dialogAnimator = dialogUI.GetComponent<Animator>();

    

        if (!PlayerPrefs.HasKey("Sergey"))
        {
            int sergey = 1;
            dialogUI.SetActive(true);
            PlayerPrefs.SetInt("Sergey", sergey);
        }
    }

    public void CloseDialog()
    {
        dialogAnimator.Play("dialogAnimOff");
    }

}
