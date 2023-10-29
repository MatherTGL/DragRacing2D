using Sirenix.OdinInspector;
using UnityEngine;

namespace Config
{
    [CreateAssetMenu(fileName = "DefaultCarConfig", menuName = "Config/Car/Create New", order = 50)]
    public sealed class ConfigCarEditor : ScriptableObject
    {
        [SerializeField, MinValue(500), MaxValue(5000)]
        private ushort _mass;
        public ushort mass => _mass;

        [SerializeField, MinValue(100), MaxValue(450)]
        private ushort _maxSpeed;
        public ushort maxSpeed => _maxSpeed;
    }
}
