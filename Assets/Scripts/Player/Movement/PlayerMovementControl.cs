using Boot;
using Config;
using Player.Movement.View;
using Racing;
using Racing.Rivals;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Player.Movement
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerMovementView))]
    public sealed class PlayerMovementControl : MonoBehaviour, IBoot, IMovementView
    {
        private AbstractPlayerMovement _abstractPlayerMovement;
        AbstractPlayerMovement IMovementView.abstractPlayerMovement => _abstractPlayerMovement;

        private PlayerMovementView _playerMovementView;

        private IRacingControl _IracingControl;


        private PlayerMovementControl() { }

        void IBoot.InitAwake()
        {
            _IracingControl = FindObjectOfType<RacingControl>();

            _abstractPlayerMovement = new DefaultPlayerMovement(GetComponent<Rigidbody2D>());
            _playerMovementView = GetComponent<PlayerMovementView>();
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        private void FixedUpdate()
        {
            if (_IracingControl.IsRacingStarted())
            {
                if (_playerMovementView.GetDriveButton().isPressed)
                    _abstractPlayerMovement.Drive();
                else if (_playerMovementView.GetBrakeButton().isPressed)
                    _abstractPlayerMovement.Brake();
            }
        }
    }
}

