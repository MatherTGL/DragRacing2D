using System.Linq;
using Boot;
using UI.Player.Movement;
using UnityEngine;

namespace Player.Movement.View
{
    [RequireComponent(typeof(PlayerMovementControl))]
    public sealed class PlayerMovementView : MonoBehaviour, IBoot
    {
        private IHandlerButtonPlayerMovement[] _IhandlerButtonPlayerMovements;


        void IBoot.InitAwake()
        {
            _IhandlerButtonPlayerMovements = FindObjectsOfType<MonoBehaviour>()
                .OfType<IHandlerButtonPlayerMovement>().ToArray();
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }
    }
}

