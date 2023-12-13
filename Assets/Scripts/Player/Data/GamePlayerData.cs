using System;
using Save;
using UnityEngine;
using YG;

namespace Player.Data
{
    public sealed class GamePlayerData : ISaveSystem
    {
        private static readonly GamePlayerData _gamePlayerData = new GamePlayerData();
        public static GamePlayerData gamePlayerData => _gamePlayerData;

        private static int _money;


        private GamePlayerData() { }

        public static void AddMoney(in int sum)
        {
            _money += sum;
            YandexGame.savesData.money = _money;
            YandexGame.SaveProgress();
        }

        public static bool SpendMoney(in int sum)
        {
            if ((_money - sum) > 0)
            {
                _money -= sum;
                YandexGame.savesData.money = _money;
                YandexGame.SaveProgress();
                return true;
            }
            return false;
        }

        public static double GetAmountMoney() => _money;

        void ISaveSystem.Init()
        {
            if (YandexGame.savesData.money == 0)
            {
                _money = 5_000;
                YandexGame.savesData.money = _money;
                YandexGame.SaveProgress();
            }
            else
            {
                _money = YandexGame.savesData.money;
            }
        }
    }
}
