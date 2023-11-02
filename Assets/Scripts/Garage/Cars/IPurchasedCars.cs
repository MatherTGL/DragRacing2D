namespace Garage.PlayerCar.Purchased
{
    public interface IPurchasedCars
    {
        void AddNewTransportation(in IPurchasedCar car);

        void SellTransportation(in IPurchasedCar car);
    }
}
