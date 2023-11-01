using Sirenix.OdinInspector;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "DefaultCarConfig", menuName = "Config/Car/Create New", order = 50)]
    public sealed class ConfigCarEditor : ScriptableObject
    {
        public enum ClassCar { A, B, C, D, E, F, J, M }

        [SerializeField, EnumToggleButtons]
        private ClassCar _currentClassCar;
        public ClassCar currentClassCar => _currentClassCar;

        [SerializeField, MinValue(500), MaxValue(5000)]
        private ushort _mass;
        public ushort mass => _mass;

        [SerializeField, MinValue(100), MaxValue(450)]
        private ushort _maxSpeed;
        public ushort maxSpeed => _maxSpeed;

        [SerializeField, MinValue(100), MaxValue(2000)]
        private ushort _basePower = 100;
        public ushort basePower => _basePower;

        [SerializeField, MinValue(20)]
        private ushort _brakePower = 70;
        public ushort brakePower => _brakePower;
    }
}
