using Boot;
using Player.Movement.View;
using Racing;
using Racing.Rivals;
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

        private void Update()
        {
            if (_IracingControl.IsRacingStarted())
            {
                Debug.Log(_playerMovementView.GetDriveButton().isPressed);
                if (_playerMovementView.GetDriveButton().isPressed)
                    _abstractPlayerMovement.Drive();
                else if (_playerMovementView.GetBrakeButton().isPressed)
                    _abstractPlayerMovement.Brake();
            }
            else
            {
                _abstractPlayerMovement.FastBrake();
            }
        }
    }
}

