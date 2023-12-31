using Config;
using UnityEngine;
using static Garage.PlayerCar.Purchased.PurchasedCar;

namespace Garage.PlayerCar.Purchased
{
    public interface IPurchasedCar
    {
        ConfigCarEditor config { get; }

        Sprite bodyImage { get; }

        Color bodyColor { get; set; }

        Stage stage { get; }

        ushort maxSpeed { get; }

        ushort mass { get; }

        ushort currentPower { get; }

        ushort currentBrakePower { get; }


        void Init(in ConfigCarEditor config);

        void UpgradePower(in ushort power);

        void UpgradeBrakePower(in ushort brakePower);

        void UpgradeStage();
    }
}
