using Boot;
using Sirenix.OdinInspector;
using UnityEngine;
using YG;

public sealed class ChangeWheel : MonoBehaviour
{
    [SerializeField, Required]
    private CarWheel _firstCarWheel;

    [SerializeField, Required]
    private CarWheel _secondCarWheel;

    [SerializeField]
    private Sprite[] _spritesWheel = new Sprite[3];


    private void Start()
    {
        _firstCarWheel.GetComponent<SpriteRenderer>().sprite = _spritesWheel[YandexGame.savesData.idTires];
        _secondCarWheel.GetComponent<SpriteRenderer>().sprite = _spritesWheel[YandexGame.savesData.idTires];
    }

    [Button("Change wheel")]
    public void SetNewWheel(int indexWheel)
    {
        if (indexWheel >= _spritesWheel.Length)
            throw new System.Exception();

        _firstCarWheel.GetComponent<SpriteRenderer>().sprite = _spritesWheel[indexWheel];
        _secondCarWheel.GetComponent<SpriteRenderer>().sprite = _spritesWheel[indexWheel];
        YandexGame.savesData.idTires = indexWheel;
        YandexGame.SaveProgress();
    }
}
