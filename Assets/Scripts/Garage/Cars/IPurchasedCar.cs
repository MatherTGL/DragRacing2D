using Config;
using static Garage.PlayerCar.Purchased.PurchasedCar;

namespace Garage.PlayerCar.Purchased
{
    public interface IPurchasedCar
    {
        ConfigCarEditor config { get; }

        Stage stage { get; }

        ushort maxSpeed { get; }

        ushort mass { get; }

        ushort currentPower { get; }

        ushort currentBrakePower { get; }


        void UpgradePower(in ushort power);

        void UpgradeBrakePower(in ushort brakePower);

        void UpgradeStage();
    }
}
