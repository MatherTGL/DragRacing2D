using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Boot.Scene
{
    public sealed class SceneLoader : MonoBehaviour, IBoot
    {
        [SerializeField, ToggleLeft]
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

        public void LoadScene(byte indexScene)
        {
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
