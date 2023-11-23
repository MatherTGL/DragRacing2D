using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Config
{
    [CreateAssetMenu(fileName = "DefaultCarConfig", menuName = "Config/Car/Create New", order = 50)]
    public sealed class ConfigCarEditor : ScriptableObject
    {
        public enum ClassCar { A, B, C, D, E, F, J, M }

        [SerializeField, EnumToggleButtons]
        private ClassCar _currentClassCar;
        public ClassCar currentClassCar => _currentClassCar;

        [SerializeField, Required]
        private Sprite _bodySprite;
        public Sprite bodySprite => _bodySprite;

        [SerializeField, Required]
        private GameObject _fullCarSprite;
        public GameObject fullCarSprite => _fullCarSprite;

        [SerializeField, Required]
        private GameObject _machineByParts;
        public GameObject machineByParts => _machineByParts;

        [SerializeField, Required]
        private Sprite _forwardWheelSprite;
        public Sprite forwardWheelSprite => _forwardWheelSprite;

        [SerializeField, Required]
        private Sprite _backWheelSprite;
        public Sprite backWheelSprite => _backWheelSprite;

        [SerializeField]
        private string _nameCar;
        public string nameCar => _nameCar;

        [SerializeField, MinValue(0)]
        private int _buyCost = 10_000;
        public int buyCost => _buyCost;

        [SerializeField, MinValue(500), MaxValue(5000)]
        private ushort _mass;
        public ushort mass => _mass;

        [SerializeField, MinValue(100), MaxValue(450)]
        private ushort _maxSpeed;
        public ushort maxSpeed => _maxSpeed;

        [SerializeField, MinValue(50), MaxValue("@_maxUpgradePower")]
        private ushort _basePower = 100;
        public ushort basePower => _basePower;

        [SerializeField, MinValue("@_basePower"), MaxValue(5000)]
        public ushort _maxUpgradePower = 150;
        public ushort maxUpgradePower => _maxUpgradePower;

        [SerializeField, MinValue(20)]
        private ushort _brakePower = 70;
        public ushort brakePower => _brakePower;

        [SerializeField, MinValue("@_brakePower"), MaxValue(2000)]
        private ushort _maxUpgradeBrakePower = 150;
        public ushort maxUpgradeBrakePower => _maxUpgradeBrakePower;

        [SerializeField, MinValue(50), MaxValue(500)]
        private ushort _addedPowerAfterStage = 150;
        public ushort addedPowerAfterStage => _addedPowerAfterStage;

        [SerializeField, MinValue(10), MaxValue(250)]
        private byte _addedMaxSpeedAfterStage = 30;
        public ushort addedMaxSpeedAfterStage => _addedMaxSpeedAfterStage;
    }
}
