namespace Player.Data
{
    public struct GamePlayerData
    {
        private static readonly GamePlayerData _gamePlayerData = new GamePlayerData();

        private static double _money;


        public static void AddMoney(in double sum)
        {
            _money += sum;
        }

        public static void SpendMoney(in double sum)
        {
            if ((_money - sum) > 0)
                _money -= sum;
        }
    }
}
