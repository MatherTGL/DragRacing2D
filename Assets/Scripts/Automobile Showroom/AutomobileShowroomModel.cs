namespace Showroom
{
    public sealed class AutomobileShowroomModel : IShowroomModel
    {
        private IShowroomControl _IshowroomControl;


        public AutomobileShowroomModel(in IShowroomControl showroomControl)
        {
            _IshowroomControl = showroomControl;
        }

        void IShowroomModel.BuyCar()
        {
            throw new System.NotImplementedException();
        }
    }
}
