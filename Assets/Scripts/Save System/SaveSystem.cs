using System.Collections.Generic;
using Boot;
using Player.Data;
using UnityEngine;

namespace Save
{
    public sealed class SaveSystem : MonoBehaviour, IBoot
    {
        private List<ISaveSystem> saveSystems = new();


        void IBoot.InitAwake()
        {
            saveSystems.Add(GamePlayerData.gamePlayerData);

            for (byte i = 0; i < saveSystems.Count; i++)
                saveSystems[i].Init();
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }
    }
}
