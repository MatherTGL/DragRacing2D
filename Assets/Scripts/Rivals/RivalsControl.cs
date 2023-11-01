using Boot;
using Config;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Rivals
{
    public sealed class RivalsControl : MonoBehaviour, IBoot
    {
        [SerializeField, Required]
        private Rigidbody2D _rigidbody2D; //! move to racing control

        [SerializeField, Required]
        private ConfigCarEditor _configCar; //! move to racing control

        private MovementOpponent _movementOpponent;


        void IBoot.InitAwake()
        {
            _movementOpponent = MovementOpponent.getInstance;
            _movementOpponent.Init(_rigidbody2D, _configCar);
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        private void FixedUpdate()
        {
            _movementOpponent.Move();
        }
    }
}
