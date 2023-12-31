
using System.Collections.Generic;

namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
       public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        // Тестовые сохранения для демо сцены
        // Можно удалить этот код, но тогда удалите и демо (папка Example)
        public int money;                       // Можно задать полям значения по умолчанию
        public string newPlayerName = "Hello!";
        public bool[] openLevels = new bool[3];

        // Ваши сохранения

       public string[] carConfig = new string[20];
        public ushort[] carMass = new ushort[20];
        public ushort[] carMaxSpeed = new ushort[20];
        public ushort[] carCurrentPower = new ushort[20];
        public ushort[] carCurrentBrakePower = new ushort[20];
        public int[] stage = new int[20];
        public bool[] buyed = new bool[20];
        public bool sergeyDialog;
        public bool egorDialog;
        public Dictionary<string, int> idTires = new();

        public float[] color = new float[3];

        public int playerWinnerValue;
        public int playerWinnerRecord;

        // Поля (сохранения) можно удалять и создавать новые. При обновлении игры сохранения ломаться не должны


        // Вы можете выполнить какие то действия при загрузке сохранений
        public SavesYG()
        {
            // Допустим, задать значения по умолчанию для отдельных элементов массива

            openLevels[1] = true;
        }
    }
}
