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
        //public IHandlerButtonPlayerMovement[] IhandlerButtonPlayerMovement => _IhandlerButtonPlayerMovements;


        void IBoot.InitAwake()
        {
            _IhandlerButtonPlayerMovements = FindObjectsOfType<MonoBehaviour>()
                .OfType<IHandlerButtonPlayerMovement>().ToArray();
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        private byte GetIndexButtonControl(in HandlerButtonPlayerMovement.TypeButtonMovement typeButtonMovement)
        {
            for (byte i = 0; i < _IhandlerButtonPlayerMovements.Length; i++)
                if (_IhandlerButtonPlayerMovements[i].typeButtonMovement == typeButtonMovement)
                    return i;
            return 0;
        }

        public IHandlerButtonPlayerMovement GetDriveButton()
        {
            return _IhandlerButtonPlayerMovements[GetIndexButtonControl(HandlerButtonPlayerMovement.TypeButtonMovement.Drive)];
        }

        public IHandlerButtonPlayerMovement GetBrakeButton()
        {
            return _IhandlerButtonPlayerMovements[GetIndexButtonControl(HandlerButtonPlayerMovement.TypeButtonMovement.Brake)];
        }
    }
}

