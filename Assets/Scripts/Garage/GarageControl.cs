using Config;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Garage
{
    public sealed class GarageControl : MonoBehaviour, IGarageControl
    {
        [SerializeField, Required]
        private ConfigCarEditor _configCar;


        ConfigCarEditor IGarageControl.GetCurrentCar() => _configCar;
    }
}
