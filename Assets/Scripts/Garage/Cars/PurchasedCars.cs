using System;
using System.Collections.Generic;
using System.Linq;
using Config;
using Garage.PlayerCar.Tuning;
using UnityEngine;
using YG;

namespace Garage.PlayerCar.Purchased
{
    public sealed class PurchasedCars : IPurchasedCars, IPurchasedCarsTuning
    {
        private List<IPurchasedCar> _listPurchasedCars = new();
        List<IPurchasedCar> IPurchasedCars.listPurchasedCars => _listPurchasedCars;


        public PurchasedCars()
        {
            ConfigCarEditor[] findedConfig = Resources.LoadAll<ConfigCarEditor>("Configs");
            Debug.Log(findedConfig.Length);
            Debug.Log(YandexGame.savesData.carConfig.Length);
            YandexGame.savesData.buyed[0] = true;

            for (int i = 0; i < YandexGame.savesData.carConfig.Length; i++)
            {
                if (YandexGame.savesData.buyed[i] == true)
                {
                    Debug.Log($"{findedConfig[i]} / {_listPurchasedCars.Count}");
                    _listPurchasedCars.Add(new PurchasedCar());
                    _listPurchasedCars[i].Init(findedConfig[i]);
                    Debug.Log("siski");
                }
                
                /*Debug.Log($"IIIIIII BLYAT: {i}");
                if (i == 0)
                    return;

                YandexGame.savesData.carCurrentBrakePower.TryAdd(findedConfig[i].name, findedConfig[i].brakePower);
                YandexGame.savesData.carCurrentPower.TryAdd(findedConfig[i].name, findedConfig[i].basePower);
                YandexGame.savesData.carMass.TryAdd(findedConfig[i].name, findedConfig[i].mass);
                YandexGame.savesData.carMaxSpeed.TryAdd(findedConfig[i].name, findedConfig[i].maxSpeed);
                YandexGame.savesData.stage.TryAdd(findedConfig[i].name, 0);
                YandexGame.savesData.idTires.TryAdd(findedConfig[i].name, 0);
                YandexGame.savesData.carConfig.Add(findedConfig[i].name);*/

            }
            PlayerSelectedCar.SetBasePlayerCar(_listPurchasedCars[0]);
            //Debug.Log($"hui: {YandexGame.savesData.carConfig.Count}");
        }

        void IPurchasedCars.AddNewTransportation(in IPurchasedCar car)
        {
            int index = 0;
            for (int i = 0; i < YandexGame.savesData.buyed.Length; i++)
                if (YandexGame.savesData.buyed[i] == false)
                    index = i;

            Debug.Log(_listPurchasedCars.Count);
            /*YandexGame.savesData.carCurrentBrakePower.TryAdd(car.config.name, car.currentBrakePower);
            YandexGame.savesData.carCurrentPower.TryAdd(car.config.name, car.currentPower);
            YandexGame.savesData.carMass.TryAdd(car.config.name, car.mass);
            YandexGame.savesData.carMaxSpeed.TryAdd(car.config.name, car.maxSpeed);
            YandexGame.savesData.stage.TryAdd(car.config.name, (int)car.stage);
            YandexGame.savesData.idTires.TryAdd(car.config.name, 0);*/
            _listPurchasedCars.Add(car);
            car.Init(car.config);
            YandexGame.savesData.buyed[index] = true;
            for (int i = 0; i < YandexGame.savesData.carConfig.Length; i++)
            {
                Debug.Log($"PIZDA 2: {YandexGame.savesData.carConfig[i]}");
            }
            YandexGame.SaveProgress();
            Debug.Log(_listPurchasedCars.Count);
        }

        IPurchasedCar IPurchasedCarsTuning.GetCar(in byte indexCar)
        {
            if (_listPurchasedCars.Count - 1 >= indexCar && indexCar >= 0)
                return _listPurchasedCars[indexCar];
            return null;
        }

        void IPurchasedCars.SellTransportation(in IPurchasedCar car)
        {
            int index = 0;

            for (int i = 0; i < YandexGame.savesData.carConfig.Length; i++)
                if (YandexGame.savesData.carConfig[i] == car.config.name)
                    index = i;

            _listPurchasedCars.Remove(car);
            YandexGame.savesData.buyed[index] = false;
            /*YandexGame.savesData.carConfig.Remove(car.config.name);
            YandexGame.savesData.carCurrentBrakePower.Remove(car.config.name);
            YandexGame.savesData.carCurrentPower.Remove(car.config.name);
            YandexGame.savesData.carMass.Remove(car.config.name);
            YandexGame.savesData.carMaxSpeed.Remove(car.config.name);
            YandexGame.savesData.idTires.Remove(car.config.name);
            YandexGame.savesData.stage.Remove(car.config.name);*/
        }
    }
}
