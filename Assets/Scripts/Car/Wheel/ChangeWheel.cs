using Boot;
using Garage.PlayerCar;
using Sirenix.OdinInspector;
using UnityEngine;
using YG;

public sealed class ChangeWheel : MonoBehaviour, IBoot
{
    [SerializeField, Required]
    private CarWheel _firstCarWheel;

    [SerializeField, Required]
    private CarWheel _secondCarWheel;

    [SerializeField]
    private Sprite[] _spritesWheel = new Sprite[3];


    [Button("Change wheel")]
    public void SetNewWheel(int indexWheel)
    {
        if (indexWheel >= _spritesWheel.Length)
            throw new System.Exception();

        _firstCarWheel.GetComponent<SpriteRenderer>().sprite = _spritesWheel[indexWheel];
        _secondCarWheel.GetComponent<SpriteRenderer>().sprite = _spritesWheel[indexWheel];
        YandexGame.savesData.idTires[PlayerSelectedCar.selectedCar.config.name] = indexWheel;
        YandexGame.SaveProgress();
    }

    void IBoot.InitAwake()
    {
        _firstCarWheel.GetComponent<SpriteRenderer>().sprite = _spritesWheel[YandexGame.savesData.idTires[PlayerSelectedCar.selectedCar.config.name]];
        _secondCarWheel.GetComponent<SpriteRenderer>().sprite = _spritesWheel[YandexGame.savesData.idTires[PlayerSelectedCar.selectedCar.config.name]];
    }

    (Bootstrap.TypeLoadObject typeLoad, Bootstrap.TypeSingleOrLotsOf singleOrLotsOf) IBoot.GetTypeLoad()
    {
        return (Bootstrap.TypeLoadObject.SimpleImportant, Bootstrap.TypeSingleOrLotsOf.LotsOf);
    }
}
