using System;
using Config;
using UnityEngine;

namespace Garage.PlayerCar.Purchased
{
    public sealed class PurchasedCar : IPurchasedCar
    {
        private ConfigCarEditor _configCar;
        ConfigCarEditor IPurchasedCar.config => _configCar;

        Sprite IPurchasedCar.bodyImage => _configCar.bodySprite;

        private Color _bodyColor;
        Color IPurchasedCar.bodyColor { get => _bodyColor; set => _bodyColor = value; }

        public enum Stage : byte { Stage1, Stage2, Stage3 }
        private Stage _stage;
        Stage IPurchasedCar.stage => _stage;

        private ushort _maxSpeed;
        ushort IPurchasedCar.maxSpeed => _maxSpeed;

        private ushort _mass;
        ushort IPurchasedCar.mass => _mass;

        private ushort _currentPower;
        ushort IPurchasedCar.currentPower => _currentPower;

        private ushort _currentBrakePower;
        ushort IPurchasedCar.currentBrakePower => _currentBrakePower;


        public PurchasedCar(in ConfigCarEditor configCar)
        {
            if (PlayerPrefs.HasKey(configCar.name))
                Load(configCar);
            else
                Save(configCar);
        }

        private void Save(in ConfigCarEditor configCar)
        {
            _configCar = configCar;
            PlayerPrefs.SetString(_configCar.name, "{_configCar.name}");

            _maxSpeed = _configCar.maxSpeed;
            PlayerPrefs.SetInt($"{_configCar.maxSpeed}", _maxSpeed);

            _mass = _configCar.mass;
            PlayerPrefs.SetInt($"{_configCar.mass}", _mass);

            _currentPower = _configCar.basePower;
            PlayerPrefs.SetInt($"{_configCar.basePower}", _currentPower);

            _currentBrakePower = _configCar.brakePower;
            PlayerPrefs.SetInt($"{_configCar.brakePower}", _currentBrakePower);

            PlayerPrefs.SetInt("{_configCar}stage", (int)_stage);
        }

        private void Load(in ConfigCarEditor configCar)
        {
            _configCar = configCar;
            _maxSpeed = (ushort)PlayerPrefs.GetInt($"{_configCar.maxSpeed}");
            _mass = (ushort)PlayerPrefs.GetInt($"{_configCar.mass}");
            _currentPower = (ushort)PlayerPrefs.GetInt($"{_configCar.basePower}");
            _currentBrakePower = (ushort)PlayerPrefs.GetInt($"{_configCar.brakePower}");
            _stage = (Stage)PlayerPrefs.GetInt("{_configCar}stage");
        }

        void IPurchasedCar.UpgradePower(in ushort power)
        {
            if ((_currentPower + power) < _configCar.maxUpgradePower)
                _currentPower += power;

            PlayerPrefs.SetInt($"{_configCar.basePower}", _currentPower);
        }

        void IPurchasedCar.UpgradeBrakePower(in ushort brakePower)
        {
            if ((_currentPower + brakePower) < _configCar.maxUpgradeBrakePower)
                _currentBrakePower += brakePower;

            PlayerPrefs.SetInt($"{_configCar.brakePower}", _currentBrakePower);
        }

        void IPurchasedCar.UpgradeStage()
        {
            Debug.Log((Stage)PlayerPrefs.GetInt("{_configCar}stage"));
            if (_stage < Stage.Stage3)
            {
                _stage++;
                _currentPower += _configCar.addedPowerAfterStage;
                _maxSpeed += _configCar.addedMaxSpeedAfterStage;

                PlayerPrefs.SetInt("{_configCar}stage", (int)_stage);
                Debug.Log((Stage)PlayerPrefs.GetInt("{_configCar}stage"));
                PlayerPrefs.SetInt($"{_configCar.basePower}", _currentPower);
                PlayerPrefs.SetInt($"{_configCar.maxSpeed}", _maxSpeed);
                Debug.Log($"After stage: stage: {_stage} / power: {_currentPower} / maxSpeed: {_maxSpeed}");
            }
        }
    }
}
