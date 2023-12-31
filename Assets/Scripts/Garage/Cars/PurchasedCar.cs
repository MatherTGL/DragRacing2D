using System;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using Config;
using Player.Data;
using UnityEngine;
using YG;

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

        private int _indexCar;


        private void Save(in ConfigCarEditor configCar)
        {
            _configCar = configCar;

            for (int i = 0; i < YandexGame.savesData.carConfig.Length; i++)
                if (YandexGame.savesData.carConfig[i] == _configCar.name)
                    _indexCar = i;

            YandexGame.savesData.carConfig[_indexCar] = _configCar.name;

            _maxSpeed = _configCar.maxSpeed;
            YandexGame.savesData.carMaxSpeed[_indexCar] = _maxSpeed;

            _mass = _configCar.mass;
            YandexGame.savesData.carMass[_indexCar] = _mass;

            _currentPower = _configCar.basePower;
            YandexGame.savesData.carCurrentPower[_indexCar] = _currentPower;

            _currentBrakePower = _configCar.brakePower;
            YandexGame.savesData.carCurrentBrakePower[_indexCar] = _currentBrakePower;

            YandexGame.savesData.stage[_indexCar] = (int)_stage;

            YandexGame.SaveProgress();
        }

        private void Load(in ConfigCarEditor configCar, in int configIndex)
        {
            _configCar = configCar;

            int index = 0;

            for (int i = 0; i < YandexGame.savesData.carConfig.Length; i++)
                if (YandexGame.savesData.carConfig[i] == _configCar.name)
                    _indexCar = i;

            _maxSpeed = YandexGame.savesData.carMaxSpeed[index];
            _mass = YandexGame.savesData.carMass[index];
            _currentPower = YandexGame.savesData.carCurrentPower[index];
            _currentBrakePower = YandexGame.savesData.carCurrentBrakePower[index];
            _stage = (Stage)YandexGame.savesData.stage[index];
        }

        void IPurchasedCar.UpgradePower(in ushort power)
        {
            if ((_currentPower + power) < _configCar.maxUpgradePower)
                if (GamePlayerData.SpendMoney(2000))
                    _currentPower += power;

            YandexGame.savesData.carCurrentPower[_indexCar] = _currentPower;
        }

        void IPurchasedCar.UpgradeBrakePower(in ushort brakePower)
        {
            if ((_currentPower + brakePower) < _configCar.maxUpgradeBrakePower)
                if (GamePlayerData.SpendMoney(2000))
                    _currentBrakePower += brakePower;

            YandexGame.savesData.carCurrentBrakePower[_indexCar] = _currentBrakePower;
        }

        void IPurchasedCar.UpgradeStage()
        {
            Debug.Log((Stage)PlayerPrefs.GetInt("{_configCar}stage"));
            if (_stage < Stage.Stage3)
            {
                if (_stage == Stage.Stage1 && GamePlayerData.SpendMoney(_configCar.firstStageCost) == false)
                    return;
                else if (_stage == Stage.Stage2 && GamePlayerData.SpendMoney(_configCar.secondStageCost) == false)
                    return;
                else if (_stage == Stage.Stage3 && GamePlayerData.SpendMoney(_configCar.thirdStageCost) == false)
                    return;

                _stage++;
                _currentPower += _configCar.addedPowerAfterStage;
                _maxSpeed += _configCar.addedMaxSpeedAfterStage;


                YandexGame.savesData.stage[_indexCar] = (int)_stage;
                Debug.Log((Stage)PlayerPrefs.GetInt("{_configCar}stage"));
                YandexGame.savesData.carCurrentPower[_indexCar] = _currentPower;
                YandexGame.savesData.carMaxSpeed[_indexCar] = _maxSpeed;
                Debug.Log($"After stage: stage: {_stage} / power: {_currentPower} / maxSpeed: {_maxSpeed}");
            }
        }

        void IPurchasedCar.Init(in ConfigCarEditor config)
        {
            _configCar = config;

            if (YandexGame.savesData.carConfig.Contains(config.name))
                Load(config, _indexCar);
            else
                Save(config);
        }
    }
}
