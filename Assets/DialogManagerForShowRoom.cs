using System.Collections;
using System.Collections.Generic;
using Boot;
using UnityEngine;
using YG;

public class DialogManagerForShowRoom : MonoBehaviour, IBoot
{

    [SerializeField] private GameObject dialogUI;
    private Animator dialogAnimator;


    public void CloseDialog()
    {
        dialogAnimator.Play("dialogAnimOff");
    }

    void IBoot.InitAwake()
    {
        dialogAnimator = dialogUI.GetComponent<Animator>();
        Debug.Log(YandexGame.savesData.sergeyDialog);

        if (YandexGame.savesData.sergeyDialog == false)
        {
            Debug.Log(YandexGame.savesData.sergeyDialog);
            dialogUI.SetActive(true);
            YandexGame.savesData.sergeyDialog = true;
            YandexGame.SaveProgress();
            Debug.Log(YandexGame.savesData.sergeyDialog);
        }
    }

    (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
    {
        return (Bootstrap.TypeLoadObject.MediumImportant, Bootstrap.TypeSingleOrLotsOf.LotsOf);
    }
}
