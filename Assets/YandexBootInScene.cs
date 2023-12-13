using System.Collections;
using System.Collections.Generic;
using Boot;
using UnityEngine;

public class YandexBootInScene : MonoBehaviour, IBoot
{
    (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
    {
        return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
    }

    void IBoot.InitAwake()
    {
        DontDestroyOnLoad(this);
    }
}
