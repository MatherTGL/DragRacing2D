using System.Collections;
using System.Collections.Generic;
using Boot;
using UnityEngine;
using UnityEngine.Advertisements;

public sealed class AdsInitializer : MonoBehaviour, IBoot, IUnityAdsInitializationListener
{
    [SerializeField] string _androidGameId = "5479974";
    [SerializeField] bool _testMode = true;
    private string _gameId;


    void IBoot.InitAwake()
    {
        InitializeAds();
    }

    (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
    {
        return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
    }

    private void InitializeAds()
    {
#if UNITY_ANDROID
            _gameId = _androidGameId;
#elif UNITY_EDITOR
        _gameId = _androidGameId; //Only for testing the functionality in the Editor
#endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }

    void IUnityAdsInitializationListener.OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    void IUnityAdsInitializationListener.OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
