using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Boot.SceneLoader
{
    public sealed class SceneLoader : MonoBehaviour, IBoot
    {
        [SerializeField, ToggleLeft, InfoBox("Load Menu Scene", InfoMessageType.Warning)]
        private bool _isAutoLoadFirstScene;


        void IBoot.InitAwake()
        {
            if (_isAutoLoadFirstScene)
                LoadScene(1);
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        public void LoadScene(int indexScene)
        {
            Debug.Log(indexScene);
            try
            {
                SceneManager.LoadScene(indexScene);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
        }
    }
}
