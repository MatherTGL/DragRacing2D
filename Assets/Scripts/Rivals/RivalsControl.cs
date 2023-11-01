using Boot;
using Config;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Racing.Rivals
{
    public sealed class RivalsControl : MonoBehaviour, IBoot, IRivalsControl
    {
        [SerializeField, Required]
        private Rigidbody2D _rigidbody2D; //! move to racing control

        private MovementOpponent _movementOpponent;

        private bool _isRacingStarted;


        void IBoot.InitAwake()
        {
            _movementOpponent = MovementOpponent.getInstance;
            _movementOpponent.Init(_rigidbody2D);
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        private void FixedUpdate()
        {
            if (_isRacingStarted)
                _movementOpponent.Move();
        }

        void IRivalsControl.SetRival(in ConfigCarEditor configCar)
        {
            _movementOpponent.ChangeConfig(configCar);
        }

        void IRivalsControl.StartRacing()
        {
            _isRacingStarted = true;
        }
    }
}
