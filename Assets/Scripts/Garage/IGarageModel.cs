using Garage.PlayerCar.Purchased;

namespace Garage
{
    public interface IGarageModel
    {
        void SellCar(in IPurchasedCar car);
    }
}
