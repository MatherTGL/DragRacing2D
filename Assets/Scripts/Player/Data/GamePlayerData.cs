namespace Player.Data
{
    public class GamePlayerData
    {
        private static readonly GamePlayerData _gamePlayerData = new GamePlayerData();

        private static double _money;


        private GamePlayerData() { }

        public static void AddMoney(in double sum)
        {
            _money += sum;
        }

        public static bool SpendMoney(in double sum)
        {
            if ((_money - sum) > 0)
            {
                _money -= sum;
                return true;
            }
            return false;
        }
    }
}
