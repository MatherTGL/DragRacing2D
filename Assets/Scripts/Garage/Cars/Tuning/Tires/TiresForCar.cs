using UnityEngine;

public sealed class TiresForCar : MonoBehaviour
{
    public enum TypeTires { Sport, Slick, Semi_Slick }

    private TypeTires _typeTires;


    public void SetTires(int typeTires)
    {
        _typeTires = (TypeTires)typeTires;
        Debug.Log(_typeTires);
    }
}
