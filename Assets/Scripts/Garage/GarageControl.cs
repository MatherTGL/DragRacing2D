using Boot;
using Config;
using Garage.PlayerCar;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Garage
{
    public sealed class GarageControl : MonoBehaviour, IGarageControl, IBoot
    {
        private IGarageModel _IgarageModel;

        private IGarageView _IgarageView;

        [SerializeField, Required]
        private ConfigCarEditor _configCar;

        private TuningPlayerCar _tuningSelectedCar;


        void IBoot.InitAwake()
        {
            _IgarageModel = new GarageModel();
            _IgarageView = new GarageView();
        }

        (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
        {
            return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
        }

        ConfigCarEditor IGarageControl.GetCurrentCar() => _configCar;

        TuningPlayerCar IGarageControl.GetTuning() => _tuningSelectedCar;
    }
}
