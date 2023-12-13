using System;
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


        public PurchasedCar(in ConfigCarEditor configCar)
        {
            if (YandexGame.savesData.carConfig == configCar.name)
                Load(configCar);
            else
                Save(configCar);
        }

        private void Save(in ConfigCarEditor configCar)
        {
            _configCar = configCar;
            YandexGame.savesData.carConfig = _configCar.name;

            _maxSpeed = _configCar.maxSpeed;
            YandexGame.savesData.carMaxSpeed = _maxSpeed;

            _mass = _configCar.mass;
            YandexGame.savesData.carMass = _mass;

            _currentPower = _configCar.basePower;
            YandexGame.savesData.carCurrentPower = _currentPower;

            _currentBrakePower = _configCar.brakePower;
            YandexGame.savesData.carCurrentBrakePower = _currentBrakePower;

            YandexGame.savesData.stage = (int)_stage;

            YandexGame.SaveProgress();
        }

        private void Load(in ConfigCarEditor configCar)
        {
            _configCar = configCar;
            _maxSpeed = YandexGame.savesData.carMaxSpeed;
            _mass = YandexGame.savesData.carMass;
            _currentPower = YandexGame.savesData.carCurrentPower;
            _currentBrakePower = YandexGame.savesData.carCurrentBrakePower;
            _stage = (Stage)YandexGame.savesData.stage;
        }

        void IPurchasedCar.UpgradePower(in ushort power)
        {
            if ((_currentPower + power) < _configCar.maxUpgradePower)
                if (GamePlayerData.SpendMoney(2000))
                    _currentPower += power;

            YandexGame.savesData.carCurrentPower = _currentPower;
        }

        void IPurchasedCar.UpgradeBrakePower(in ushort brakePower)
        {
            if ((_currentPower + brakePower) < _configCar.maxUpgradeBrakePower)
                if (GamePlayerData.SpendMoney(2000))
                    _currentBrakePower += brakePower;

            YandexGame.savesData.carCurrentBrakePower = _currentBrakePower;
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


                YandexGame.savesData.stage = (int)_stage;
                Debug.Log((Stage)PlayerPrefs.GetInt("{_configCar}stage"));
                YandexGame.savesData.carCurrentPower = _currentPower;
                YandexGame.savesData.carMaxSpeed = _maxSpeed;
                Debug.Log($"After stage: stage: {_stage} / power: {_currentPower} / maxSpeed: {_maxSpeed}");
            }
        }
    }
}
