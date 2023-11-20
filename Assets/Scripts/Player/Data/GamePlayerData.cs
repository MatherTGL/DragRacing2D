using System;
using Save;
using UnityEngine;

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
            PlayerPrefs.SetInt("Money", _money);
        }

        public static bool SpendMoney(in int sum)
        {
            if ((_money - sum) > 0)
            {
                _money -= sum;
                PlayerPrefs.SetInt("Money", _money);
                return true;
            }
            return false;
        }

        public static double GetAmountMoney() => _money;

        void ISaveSystem.Init()
        {
            if (PlayerPrefs.HasKey("Money"))
                _money = PlayerPrefs.GetInt("Money");
            else
                _money = 5_000;

            Debug.Log(_money);
        }
    }
}
