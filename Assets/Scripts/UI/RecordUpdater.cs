using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class RecordUpdater : MonoBehaviour
{
    [SerializeField] private Text recordText;
    void Start()
    {
        if(YandexGame.savesData.playerWinnerRecord == 0)
        {
            recordText.text = "0";
        }
        else
        {
            recordText.text = YandexGame.savesData.playerWinnerRecord.ToString();
        }
    }

 
}
