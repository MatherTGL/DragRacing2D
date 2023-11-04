using Config;

namespace Garage.PlayerCar.Purchased
{
    public interface IPurchasedCar
    {
        ConfigCarEditor config { get; }

        ushort maxSpeed { get; }

        ushort mass { get; }

        ushort currentPower { get; }

        ushort currentBrakePower { get; }


        void UpgradePower(in ushort power);

        void UpgradeBrakePower(in ushort brakePower);
    }
}
