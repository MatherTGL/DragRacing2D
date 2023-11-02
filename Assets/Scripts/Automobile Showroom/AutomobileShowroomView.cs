using UnityEngine;

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
            Debug.Log("Showroom buy method in view");
        }
    }
}
