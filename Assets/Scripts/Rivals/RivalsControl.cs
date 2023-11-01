using System.Collections.Generic;
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

        private IRacingControl _IracingControl;


        void IBoot.InitAwake()
        {
            _IracingControl = FindObjectOfType<RacingControl>();

            _movementOpponent = MovementOpponent.getInstance;
            _movementOpponent.Init(_rigidbody2D);
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        private void FixedUpdate()
        {
            if (_IracingControl.IsRacingStarted())
                _movementOpponent.Move();
        }

        void IRivalsControl.SpawnRandomRival()
        {
            ConfigCarEditor[] configsCars = Resources.FindObjectsOfTypeAll<ConfigCarEditor>();
            List<ConfigCarEditor> potentialRivals = new();

            var currentPlayerClassCar = _IracingControl.IgarageControl.GetCurrentCar().currentClassCar;

            for (byte i = 0; i < configsCars.Length; i++)
                if (configsCars[i].currentClassCar == currentPlayerClassCar)
                    potentialRivals.Add(configsCars[i]);

            _movementOpponent.ChangeConfig(potentialRivals[Random.Range(0, potentialRivals.Count - 1)]);
        }
    }
}
