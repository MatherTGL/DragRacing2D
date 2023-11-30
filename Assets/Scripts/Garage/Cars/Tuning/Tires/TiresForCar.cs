using Boot;
using Showroom;
using Sirenix.OdinInspector;
using UnityEngine;

public sealed class TiresForCar : MonoBehaviour, IBoot
{
    public enum TypeTires { Sport, Slick, Semi_Slick }

    private TypeTires _typeTires;

    [SerializeField, Required]
    private ShowroomCarPool _carPool;

    private ChangeWheel _carWheels;


    void IBoot.InitAwake()
    {
        for (int i = 0; i < _carPool.poolAllCars.Count; i++)
            if (_carPool.poolAllCars[i].activeInHierarchy)
                _carWheels = _carPool.poolAllCars[i].GetComponent<ChangeWheel>();
    }

    (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
    {
        return (Bootstrap.TypeLoadObject.SuperImportant, Bootstrap.TypeSingleOrLotsOf.Single);
    }

    public void SetTires(int typeTires)
    {
        if (_carWheels == null)
            throw new System.Exception();

        _typeTires = (TypeTires)typeTires;
        _carWheels.SetNewWheel(typeTires);
    }
}
