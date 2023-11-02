using Garage.PlayerCar.Purchased;

namespace Showroom
{
    public sealed class AutomobileShowroomView : IShowroomView
    {
        private IShowroomControl _IshowroomControl;


        public AutomobileShowroomView(in IShowroomControl showroomControl)
        {
            _IshowroomControl = showroomControl;
        }

        void IShowroomView.BuyCar()
        {
            throw new System.NotImplementedException();
        }
    }
}
