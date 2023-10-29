using Boot;
using Config;
using Player.Movement.View;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Player.Movement
{
    [RequireComponent(typeof(Rigidbody2D), typeof(PlayerMovementView))]
    public sealed class PlayerMovementControl : MonoBehaviour, IBoot, IMovementView
    {
        private AbstractPlayerMovement _abstractPlayerMovement;
        AbstractPlayerMovement IMovementView.abstractPlayerMovement => _abstractPlayerMovement;

        [SerializeField, Required]
        private ConfigCarEditor _configCar;


        private PlayerMovementControl() { }

        void IBoot.InitAwake()
        {
            _abstractPlayerMovement = new DefaultPlayerMovement(GetComponent<Rigidbody2D>(), _configCar);
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        private void OnEnable()
        {
            LoadCarConfig();
        }

        private void LoadCarConfig()
        {
            Debug.Log("Config not loaded");
        }

        private void FixedUpdate()
        {
            _abstractPlayerMovement.Drive();
            _abstractPlayerMovement.Brake();
            _abstractPlayerMovement.NaturalBraking();
        }
    }
}

