using static Boot.Bootstrap;

namespace Boot
{
    public interface IBoot
    {
        void InitAwake();

        (TypeLoadObject typeLoad, TypeSingleOrLotsOf singleOrLotsOf) GetTypeLoad();
    }
}
