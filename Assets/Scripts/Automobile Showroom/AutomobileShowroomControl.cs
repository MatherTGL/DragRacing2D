using Boot;
using Config;
using Garage;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Showroom
{
    public sealed class AutomobileShowroomControl : MonoBehaviour, IBoot, IShowroomControl
    {
        [ShowInInspector]
        private const string pathConfigsCarLoad = "Configs/Cars";

        private IGarageControl _IgarageControl;
        IGarageControl IShowroomControl.IgarageControl => _IgarageControl;

        private IShowroomModel _IshowroomModel;

        private IShowroomView _IshowroomView;

        [SerializeField, ReadOnly]
        private ConfigCarEditor[] _availableCarsForPurchase;
        ConfigCarEditor[] IShowroomControl.availableCarsForPurchase => _availableCarsForPurchase;


        void IBoot.InitAwake()
        {
            _IgarageControl = FindObjectOfType<GarageControl>();
            _availableCarsForPurchase = Resources.LoadAll<ConfigCarEditor>(pathConfigsCarLoad);

            _IshowroomModel = new AutomobileShowroomModel(this);
            _IshowroomView = new AutomobileShowroomView(this);
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        [Button("Buy car")]
        public void BuyCar(in byte indexCar)
        {
            _IshowroomModel.BuyCar(indexCar);
            _IshowroomView.BuyCar();
        }
    }
}
