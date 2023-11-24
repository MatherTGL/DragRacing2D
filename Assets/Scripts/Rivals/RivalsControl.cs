using System.Collections.Generic;
using Boot;
using Config;
using Garage.PlayerCar;
using Showroom;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Racing.Rivals
{
    public sealed class RivalsControl : MonoBehaviour, IBoot, IRivalsControl
    {
        private RivalCar _rivalCar;

        private ShowroomCarPool _showroomCarPool;

        private Rigidbody2D _rigidbody2D;

        private MovementOpponent _movementOpponent;

        private IRacingControl _IracingControl;

        private List<ConfigCarEditor> _potentialRivals = new();

        private ConfigCarEditor[] _configsCars;


        private RivalsControl() { }

        void IBoot.InitAwake()
        {
            _showroomCarPool = GetComponent<ShowroomCarPool>();

            _configsCars = Resources.FindObjectsOfTypeAll<ConfigCarEditor>();
            _IracingControl = FindObjectOfType<RacingControl>();

            _movementOpponent = MovementOpponent.getInstance;

            var currentPlayerClassCar = PlayerSelectedCar.selectedCar.config.currentClassCar;
            Debug.Log(currentPlayerClassCar);

            for (byte i = 0; i < _configsCars.Length; i++)
                if (_configsCars[i].currentClassCar == currentPlayerClassCar)
                    _potentialRivals.Add(_configsCars[i]);

            Debug.Log(_potentialRivals.Count);

            for (int i = 0; i < _showroomCarPool.poolAllCars.Count; i++)
            {
                if (_showroomCarPool.poolAllCars[i].name == _potentialRivals[Random.Range(0, _potentialRivals.Count)].rivalCar.name)
                {
                    _showroomCarPool.poolAllCars[i].SetActive(true);
                    _rivalCar = _showroomCarPool.poolAllCars[i].GetComponent<RivalCar>();
                    _rigidbody2D = _showroomCarPool.poolAllCars[i].GetComponent<Rigidbody2D>();
                    _movementOpponent.Init(_rigidbody2D, _rivalCar);
                    return;
                }
                else
                {
                    _showroomCarPool.poolAllCars[i].SetActive(false);
                }
            }

            Debug.Log($"{_rigidbody2D} / {_rivalCar}");
            _movementOpponent.GenerateRandomRivalParameters();
            _potentialRivals.Clear();
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        private void FixedUpdate()
        {
            if (_IracingControl.IsRacingStarted())
                _movementOpponent.Move();
            else
                _movementOpponent.Brake();
        }

        void IRivalsControl.SpawnRandomRival()
        {

        }
    }
}
