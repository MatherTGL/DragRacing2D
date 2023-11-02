using Config;
using Garage.PlayerCar;

namespace Garage
{
    public interface IGarageControl
    {
        ConfigCarEditor GetCurrentCar(); //TODO: after return some car class

        TuningPlayerCar GetTuning();
    }
}
