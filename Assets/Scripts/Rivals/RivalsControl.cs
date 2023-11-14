using System.Collections.Generic;
using Boot;
using Config;
using Garage.PlayerCar;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Racing.Rivals
{
    public sealed class RivalsControl : MonoBehaviour, IBoot, IRivalsControl
    {
        private Rigidbody2D _rigidbody2D;

        private MovementOpponent _movementOpponent;

        private IRacingControl _IracingControl;

        private List<ConfigCarEditor> _potentialRivals = new();

        private ConfigCarEditor[] _configsCars;


        private RivalsControl() { }

        void IBoot.InitAwake()
        {
            _configsCars = Resources.FindObjectsOfTypeAll<ConfigCarEditor>();
            _IracingControl = FindObjectOfType<RacingControl>();

            _rigidbody2D = FindObjectOfType<RivalCar>().GetComponent<Rigidbody2D>();

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
            var currentPlayerClassCar = PlayerSelectedCar.selectedCar.config.currentClassCar;
            Debug.Log(currentPlayerClassCar);

            for (byte i = 0; i < _configsCars.Length; i++)
                if (_configsCars[i].currentClassCar == currentPlayerClassCar)
                    _potentialRivals.Add(_configsCars[i]);

            Debug.Log(_potentialRivals.Count);
            _movementOpponent.ChangeConfig(_potentialRivals[Random.Range(0, _potentialRivals.Count)]);
            _potentialRivals.Clear();
        }
    }
}
