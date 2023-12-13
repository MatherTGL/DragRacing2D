using System.Collections;
using System.Collections.Generic;
using Player.Data;
using Sirenix.OdinInspector;
using UnityEngine;
using YG;

public sealed class YandexAdsManager : MonoBehaviour
{
    [SerializeField]
    private int _adID;

    [SerializeField, MinValue(0)]
    private int _moneyReward;


    private void Load() => YandexGame.LoadProgress();

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }

    private void Start()
    {
        if (YandexGame.SDKEnabled == false)
            throw new System.Exception("Yandex SDK is not enabled");
    }

    private void Rewarded(int adID)
    {
        if (adID == _adID)
            GamePlayerData.AddMoney(_moneyReward);
    }
}
